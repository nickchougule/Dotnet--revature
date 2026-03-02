using MyApp;

// create first
var calculator = new Calculator();

// Falsifiable
AddFunctionShouldReturn30ForInputs10And20();
AddFunctionShouldReturn40ForInputs20And20();
AddFunctionShouldReturn50ForInputs25And25();

SubtractFunctionShouldReturn5ForInputs10And5();
MultiplyFunctionShouldReturn20ForInputs10And2();
DivideFunctionShouldReturn5ForInputs10And2();
DivideFunctionShouldThrowExceptionForDivideByZero();

void AddFunctionShouldReturn30ForInputs10And20()
{
    var actualResult = calculator.Add(10, 20);
    var expectedResult = 30;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void AddFunctionShouldReturn40ForInputs20And20()
{
    var actualResult = calculator.Add(20, 20);
    var expectedResult = 40;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void AddFunctionShouldReturn50ForInputs25And25()
{
    var actualResult = calculator.Add(25, 25);
    var expectedResult = 50;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void SubtractFunctionShouldReturn5ForInputs10And5()
{
    var actualResult = calculator.Subtract(10, 5);
    var expectedResult = 5;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void MultiplyFunctionShouldReturn20ForInputs10And2()
{
    var actualResult = calculator.Multiply(10, 2);
    var expectedResult = 20;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void DivideFunctionShouldReturn5ForInputs10And2()
{
    var actualResult = calculator.Divide(10, 2);
    var expectedResult = 5;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    Console.WriteLine(actualResult == expectedResult ? "Test Passed" : "Test Failed");
}

void DivideFunctionShouldThrowExceptionForDivideByZero()
{
    try
    {
        calculator.Divide(10, 0);
        Console.WriteLine("Test Failed");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Divide by zero test passed");
    }
}