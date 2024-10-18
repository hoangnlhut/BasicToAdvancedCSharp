using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part29_Reflection.Basics
{
    [Custom("This is a custom attribute")]
    public class DemoClass
    {
        public int DemoField;
        public string? DemoProperty { get; set; }
        public event EventHandler DemoEvent;

        public DemoClass(int value)
        {
            Console.WriteLine($"Constructor called with value: {value}");
        }

        public void DemoMethod(int value, string message)
        {
            Console.WriteLine($"DemoMethod called with value: {value} and message: {message}");
        }

        public void DemoMethod(string message)
        {
            Console.WriteLine($"DemoMethod called with message: {message}");
        }

       

        public void RaiseEvent(string message)
        {
            DemoEvent?.Invoke(this, new DemoEventArgs(message));
        }
    }
}
