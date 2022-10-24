
int counter = 0;

while(true)
{
    counter++;
    Console.WriteLine(counter);
    await Task.Delay(1000);
}
