﻿namespace Sample.ConsoleApp;

public class CSharpCalculator
{
    public int Add(int n1, int n2)
    {
        return checked(n1 + n2);
    }
}
