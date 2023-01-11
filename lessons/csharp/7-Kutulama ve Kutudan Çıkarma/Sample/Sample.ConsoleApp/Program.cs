
Sample1();
Sample2();
Sample3();

Console.ReadKey();

void Sample1()
{
    int i = 10;
    object o = i;//boxing
    int j = (int)o;//unboxing

    o = 20;
    o = 30;
}

void Sample2()
{
    object o = -1;
    for (int i = 0; i < 100_000_000; i++)
    {
        o = i;
    }
}

void Sample3()
{
    for (int i = 0; i < 100_000_000; i++)
    {
        WithObject(i);
        WithGeneric(i);
    }
}

void WithObject(object o)
{

}

void WithGeneric<T>(T o)
{

}