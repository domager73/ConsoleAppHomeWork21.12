int[,] train = new int[3, 4];
Random rn = new Random();
int count = 0;

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        train[i, j] = rn.Next(0, 1 + 1);
        Console.Write(train[i, j] + " ");
    }
    Console.WriteLine();
}

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 4; j++)
    {
        if (train[i, j] == 0)
        {
            count++;
        }
    }
    Console.WriteLine($"В {i+1} вагоне {count} свободных мест");
    count = 0;
}
