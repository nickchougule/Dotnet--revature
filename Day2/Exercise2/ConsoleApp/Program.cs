using System.Text;

namespace Day2
{
    public class Program
    {
        static void Main()
        {
            StringDemo();
            StringBuilderDemo();

        }

        static void StringDemo()
        {
            string name1="Nikhil";
            string name2="Chougule";

            Execute(ref name1,ref name2);


        }

        static void  Execute(ref string name1,ref string name2)
        {
            Console.WriteLine(name1+name2);
        }

        static void StringBuilderDemo()
        {
            StringBuilder sb=new StringBuilder();

            sb.Append("Nikhil");
            sb.Append(" ");
            sb.Append("Chougule");

            ExecuteStringBuilder(sb.ToString());
        }

        static void ExecuteStringBuilder(string Fullname)
        {
            Console.WriteLine(Fullname);
        }



    }
}
