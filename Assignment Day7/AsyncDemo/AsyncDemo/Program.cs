using System.Diagnostics;

// --- MAIN EXECUTION ---
try
{
    Console.WriteLine("--- Starting Exception Demonstration ---");
    await DemonstrateExceptions();

    Console.WriteLine("\n--- Starting Combined Demos ---");
    await Demos();
}
catch (Exception ex)
{
    Console.WriteLine($"Top-level Catch: {ex.Message}");
}

// --- METHODS ---

async Task DemonstrateExceptions()
{
    using var _client = new HttpClient();

    var urls = new[]
    {
        "https://jsonplaceholder.typicode.com/posts/1",    // valid
        "https://this-does-not-exist.invalid/post/1",      // will fail
        "https://this-does-not-exist.invalid/post/2",      // will fail
        "https://jsonplaceholder.typicode.com/posts/3"     // valid
    };

    var tasks = urls.Select(url => _client.GetStringAsync(url)).ToList();

    try
    {
        Console.WriteLine($"Count: {tasks.Count}");

        // FIXED: Removed Task.WaitAll (which returns void and cannot be awaited)
        // FIXED: Only one declaration of the 'results' variable
        string[] results = await Task.WhenAll(tasks);

        Console.WriteLine($"All {results.Length} succeeded.");
    }
    catch (HttpRequestException ex)
    {
        // When using await Task.WhenAll, only the FIRST exception is caught here
        Console.WriteLine($"At least one failed: {ex.Message}");

        // Inspect the tasks list directly to see ALL failures
        foreach (var task in tasks.Where(t => t.IsFaulted))
        {
            Console.WriteLine($"  - Detailed Error: {task.Exception?.InnerException?.Message}");
        }
    }

    foreach (var task in tasks)
    {
        if (task.IsCompletedSuccessfully)
        {
            Console.WriteLine($"Success: {task.Result.Length} chars");
        }
        else if (task.IsFaulted)
        {
            Console.WriteLine($"Failed Status: {task.Exception?.InnerException?.Message}");
        }
    }
}

async Task<int> Demos()
{
    await TaskParallelDemoAsync();
    await TaskDemoAsync();
    ThreadDemo();

    return 0; // Simplified return
}

async Task TaskParallelDemoAsync()
{
    using var _client = new HttpClient();
    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine("\nStarting Parallel Tasks...");

    var downloadTasks = urls.Select(async url =>
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;
        string content = await _client.GetStringAsync(url);
        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"Thread {threadBefore} -> {threadAfter} | Downloaded {url} ({content.Length} chars)");
        return content;
    });

    string[] results = await Task.WhenAll(downloadTasks);

    stopwatch.Stop();
    Console.WriteLine($"Parallel Total time: {stopwatch.ElapsedMilliseconds}ms");
}

async Task TaskDemoAsync()
{
    using var _client = new HttpClient();
    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine("\nStarting Sequential Async Tasks...");

    foreach (var url in urls)
    {
        var threadBefore = Thread.CurrentThread.ManagedThreadId;
        string content = await _client.GetStringAsync(url);
        var threadAfter = Thread.CurrentThread.ManagedThreadId;

        Console.WriteLine($"[Thread {threadBefore} -> {threadAfter}] Fetching {url}... done.");
    }

    stopwatch.Stop();
    Console.WriteLine($"Sequential Async Total time: {stopwatch.ElapsedMilliseconds}ms");
}

void ThreadDemo()
{
    using var _client = new HttpClient();
    var urls = Enumerable.Range(1, 10)
        .Select(i => $"https://jsonplaceholder.typicode.com/posts/{i}")
        .ToList();

    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine("\nStarting Blocking Thread Demo...");

    foreach (var url in urls)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;

        // .Result blocks the current thread until the task is finished
        var response = _client.GetAsync(url).Result;
        var content = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine($"[Thread {threadId}] Blocked Fetching {url}... done.");
    }

    stopwatch.Stop();
    Console.WriteLine($"Blocking Thread Total time: {stopwatch.ElapsedMilliseconds}ms");
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
}