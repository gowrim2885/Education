
using System.ComponentModel;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

internal class InternalDemo
{
    internal readonly int internalValue = 50;
}

class Parent
{
    protected readonly int protectedValue = 100;
}
class Demo : Parent
{
    readonly int normalValue;

    private readonly string privateValue;

    public readonly int publicValue;

    public static readonly double staticValue;

    public readonly List<int> numbers = new List<int>();


    public Demo()
    {
        normalValue = 10;         // allowed
        privateValue = "Hello";   // allowed
        publicValue = 25;         // allowed

        numbers.Add(1); 
    }

    static Demo()
    {
        staticValue = 3.14;  
    }

    public void Show()
    {
        Console.WriteLine(normalValue);    
        Console.WriteLine(privateValue);   
        Console.WriteLine(publicValue);    
        Console.WriteLine(protectedValue);  
        Console.WriteLine(staticValue);    
        Console.WriteLine(numbers[0]);      
    }
}
class Child : Demo
{
    public void Test()
    {
        Console.WriteLine(protectedValue); 
    }
}

// Main program
class Program
{
    static void Main()
    {
        Demo d = new Demo();

        Console.WriteLine(d.publicValue);   
        // Console.WriteLine(d.privateValue);  error
        // Console.WriteLine(d.normalValue);  error

        Console.WriteLine(Demo.staticValue); //  static access

        InternalDemo i = new InternalDemo();
        Console.WriteLine(i.internalValue); //  same assembly
    }
}





//const vs readonly vs static readonly
//Reference type with readonly


/*
    readonly normally --> inside the constructor assign like act as a private data
    private readonly -->within the class
    public readonly --> outside of the class
    protected readonly --> InheritanceAttribute use case 
    internal readonly --> same project
    static readonly  --> Runtime assign the value

*/