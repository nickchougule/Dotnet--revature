// var array=new int[]{1,2,3,4,5};
// var item=array[7];


// string message=null;
// Console.WriteLine(message.ToUpper());


// try
// {
//     var numerator=10;
//     var denominator=0;

//     var result=numerator/denominator;
//     Console.WriteLine($"result:{result}");

// }
// catch(DivideByZeroException ex)
// {
//     Console.WriteLine("cant divide by zero provide a valid denominator");
//     Console.WriteLine($"{ex.Message}");
//     Console.WriteLine($"{ex.StackTrace}");
// }


// try
// {
//     first();
// }catch(DivideByZeroException ex)
// {
//     Console.WriteLine("Cant divide by zero");
//     Console.WriteLine($"{ex.Message}");
//     Console.WriteLine($"{ex.StackTrace}");
// }catch(Exception ex)
// {
//     Console.WriteLine("Cant divide by zero");
//     Console.WriteLine($"{ex.Message}");
//     Console.WriteLine($"{ex.StackTrace}");
// }

// void first()
// {
//     second();
// }

// void second()
// {
//     third();
// }

// void third()
// {

//     int numerator=10;
//     int denominator=0;

//     int result=numerator/denominator;
// }


try
{
    int numerator=10;
    int denominator=0;

    int result=numerator/denominator;
}catch(Exception ex)
{
    Console.WriteLine($"{ex.Message}");
    throw;
}





