using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyInjection
{
    class Solid_Principles
    {
        public static void Main()
        {
            // Console.WriteLine("Hello World");

            // var Services= new ServiceCollection();
            // Services.AddScoped<IMessageReader,MessageReader>();
            // Services.AddScoped<IMessagewriter,MessageWriter>();

            // Services.AddScoped<App>();

            // var ServiceProvider= Services.BuildServiceProvider();
            // var app=ServiceProvider.GetService<App>();


            IMessageReader reader=new TwitterMessageReader();
            IMessagewriter writer=new InstagrammessageWriter();

            App app=new App(reader,writer);
            


            app.Run();
            
        }
    }

    class App
    {
        private readonly IMessageReader _reader;
        private readonly IMessagewriter _writer;


        public App(IMessageReader reader,IMessagewriter writer)
        {
            _reader=reader;
            _writer=writer;
        }

        public void Run()
        {
            string message= _reader.ReadMessage();
            _writer.WriteMessage(message);
        }
    }


    public interface IMessagewriter
    {
        void WriteMessage(string message);
    }

    public class MessageWriter:IMessagewriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class InstagrammessageWriter : IMessagewriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"{message} Posted on instagram");
        }
    }


    public interface IMessageReader
    {
        string ReadMessage();
    }

    public class MessageReader:IMessageReader
    {
        public string ReadMessage()
        {
            return "helloWorld";
        }
    }

    public class TwitterMessageReader: IMessageReader
    {
        public string ReadMessage()=>"Hello From Twitter";
    }
}