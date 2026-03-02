using PalindromeCheck;

namespace Palindrome
{
    public class Class1
{
    public static void InputString()
    {
        
        Console.WriteLine("Enter aString:");
        var str=Console.ReadLine() ?? string.Empty;


        bool result=str.isPalindrome();

        Console.WriteLine(result? "The string is a Palindrome.": "The string is NOT a Palindrome.");


    }



}
}




namespace PalindromeCheck
{
    public static class PalindromeVariable
    {
        public static bool isPalindrome(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
