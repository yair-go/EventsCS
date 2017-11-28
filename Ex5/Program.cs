using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex5
{
public interface Iobserver
{
    void doSomething();
}

public class Printer
{
    List<Iobserver> observerList = new List<Iobserver>();

    public void addObserver(Iobserver obs)
    {
        observerList.Add(obs);
    }
    public bool removeObserver(Iobserver obs)
    {
        return observerList.Remove(obs);
    }

    public void Invoke()
    {
        foreach (Iobserver item in observerList)
        {
            item.doSomething();
        }
    }
    public void Print(int pageNumber)
    {
        Invoke();
    }
}

public class User1 : Iobserver
{
    public void doSomething()
    {
        Console.WriteLine("user 1 do something...");
    }
}


    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer();
            User1 u1 = new User1();
            p.addObserver(u1);
           
            Console.WriteLine("enter page of copy :");
            int x = int.Parse(Console.ReadLine());
            p.Print(x);
        }
    }
}
