using Sample.ConsoleApp;

CallStack.Do();
Recursive(1_000_000);
Console.ReadKey();


void Recursive(int loop)
{
    if (loop <= 0) return;

    Recursive(loop - 1);
}