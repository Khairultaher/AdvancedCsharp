
Console.WriteLine("------------i++-------------");
int res = 0;
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(res++);
}

Console.WriteLine("----------++i---------------");
res = 0;
for (int i = 0; i < 5; ++i)
{
    Console.WriteLine(++res);
}
Console.ReadLine();
