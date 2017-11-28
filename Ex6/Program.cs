using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex6
{
public class MyValue
{
    private int myvalue = 0;

    private event EventHandler valueChanged;

    public event EventHandler ValueChanged
    {
        add { valueChanged += value; }
        remove { valueChanged -= value; }
    }

    protected void OnValueChanged(ValueChangedEventArgs args)
    {
        if (valueChanged != null)
        {
            valueChanged(this, args);
        }
    }

    public int Value
    {
        get { return myvalue; }

        set
        {
            ValueChangedEventArgs args = new ValueChangedEventArgs(myvalue, value);
            myvalue = value;
            OnValueChanged(args);
        }
    }
}




    public class ValueChangedEventArgs : EventArgs
    {
        public readonly int OldValue, NewValue;

        public ValueChangedEventArgs(int oldTemp, int newTemp)
        {
            OldValue = oldTemp;
            NewValue = newTemp;
        }
    }
 //   public delegate void ValueChangedEventHandler(Object sender, EventArgs args);

    public class ValueChangeObserver
    {
        public ValueChangeObserver(MyValue t)
        {
            t.ValueChanged += this.ValueChangeFunc;
        }

        public void ValueChangeFunc(Object sender, EventArgs e)
        {
            if (!(e is ValueChangedEventArgs))
                return;
            ValueChangedEventArgs temp = (ValueChangedEventArgs)e;
            Console.WriteLine("ChangeObserver: Old={0}, New={1}, Change={2}",
                temp.OldValue, temp.NewValue,
                temp.NewValue - temp.OldValue);
        }
    }
    public class ValueAverageObserver
    {
        private int sum = 0, count = 0;
        public ValueAverageObserver(MyValue t)
        {
            t.ValueChanged += this.ValueChangeFunc;
        }
        public void ValueChangeFunc(Object sender, EventArgs e)
        {
            if (e is ValueChangedEventArgs)
            {
                ValueChangedEventArgs temp = (ValueChangedEventArgs)e;

                count++;
                sum += temp.NewValue;

                Console.WriteLine("AverageObserver: Average={0:F}", (double)sum / (double)count);
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            MyValue t = new MyValue();

            new ValueChangeObserver(t);
            new ValueAverageObserver(t);
           
            t.Value = 100;
            t.Value = 99;
            t.Value = 88;
            t.Value = 77;
        }
    }
}
