using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class EventHandler
    {
        public class Button
        {
            public event Action OnClick;
            public void Click()
            {
                Console.WriteLine("Button was clicked!");
                OnClick?.Invoke();
            }
        }
        public EventHandler()
        {
            Button button = new Button();
            button.OnClick += () => Console.WriteLine("Button click event handled!");
            button.OnClick += () => Console.WriteLine("Another handler for the button click event!");
            button.Click();
        }
    }
}
