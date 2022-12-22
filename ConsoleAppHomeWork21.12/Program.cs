Random rn = new Random();
int str = rn.Next(4,6);
int colomn = rn.Next(4,6);
int[,] mas = new int[str, colomn];
int temp, polColomn;
polColomn = colomn / 2 ;

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

for (int i = 0; i < str; i++)
{
    for (int j = 0; j < polColomn; j++)
    {
        temp = mas[i, j];
        mas[i, j] = mas[i, colomn - 1 - j];
        mas[i, colomn - 1 - j] = temp;
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