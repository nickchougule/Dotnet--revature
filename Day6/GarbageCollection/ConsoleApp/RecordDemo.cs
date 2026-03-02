namespace Day6
{
    public class TempClass
    {
        public int ID{get;set;}
        public string Name{get;set;}


        public TempClass(int Id,string name)
        {
            ID=ID;
            Name=name;

        }

    }

    public record Temp
    {
        public int ID{get;set;}
        public string Name{get;set;}

    }


    public struct TempStruct
    {
        public int ID{get;set;}
        public string name{get;set;}
    }
    
}