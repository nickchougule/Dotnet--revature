Ibutton button = CreateButton("Windows");

Console.WriteLine($"name={button.name}");
button.click();


Ibutton CreateButton(string os)
{
    return os switch
    {
        "Windows"=>new WindowsButton(),
        "Macos"=>new MacOs(),
        _=>throw new ArgumentException("Invalid os")
    };
}

interface Ibutton
{
    string name{get; set;}

    void click();
}

class WindowsButton: Ibutton
{
    public string name{get;set;}="Windows";

    public void click()
    {
        Console.WriteLine("Windows Button clicked.");
    }
}

class MacOs: Ibutton
{
    public string name{get;set;}="Mac Os";

    public void click()
    {
        Console.WriteLine("MacOs Button clicked.");
    }
}