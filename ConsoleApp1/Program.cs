Random rn = new Random();
int str = rn.Next(4, 6);
int colomn = rn.Next(4, 6);
int[,] mas = new int[str, colomn];
int temp, polStr;

polStr = str / 2;

for (int i = 0; i < str; i++)
{
    for (int j = 0; j < colomn; j++)
    {
        mas[i, j] = rn.Next(1, 9 + 1);
        Console.Write(mas[i, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("");

for (int i = 0; i < polStr; i++)
{
    for (int j = 0; j < colomn; j++)
    {
        temp = mas[i, j];
        mas[i, j] = mas[str - 1 - i, j];
        mas[str - 1 - i, j] = temp;
    }
}

for (int i = 0; i < str; i++)
{
    for (int j = 0; j < colomn; j++)
    {
        Console.Write(mas[i, j] + " ");
    }
    Console.WriteLine();
}