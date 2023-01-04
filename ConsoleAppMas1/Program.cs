int[] mas = new int[11] { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5 };

for (int i = 0; i < 6; i++)
{
    for (int j = i; j < 6 + i; j++)
    {
        Console.Write(mas[j]);
    }
    Console.WriteLine();
}

