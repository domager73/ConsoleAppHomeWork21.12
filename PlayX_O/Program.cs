int column = 3;
int str = 3;
int stepX, stepY, step;
int count = 0;
int countO = 0;
int countX = 0;
int vonO, vonX;


string[,] mas = new string[str, column];

for (int i = 0; i < str; i++)
{
    for (int j = 0; j < column; j++)
    {
        mas[i, j] = "*";
    }
}

for (int k = 0; k < str; k++)
{
    for (int j = 0; j < column; j++)
    {
        Console.Write(mas[k, j] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("Введите координату клетки для хода X");
step = int.Parse(Console.ReadLine()) - 1;
mas[step / 3, step % 3] = "X";
Console.Clear();

while (countX + countO < 8)
{
    for (int k = 0; k < str; k++)
    {
        for (int j = 0; j < column; j++)
        {
            Console.Write(mas[k, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("Введите координату клетки для хода X");
    step = int.Parse(Console.ReadLine()) - 1;
    countO++;
    mas[step / 3, step % 3] = "O";
    Console.Clear();
    if (mas[0, 0] == "O" && mas[0, 1] == "O" && mas[0, 2] == "O" ||
        mas[1, 0] == "O" && mas[1, 1] == "O" && mas[1, 2] == "O" ||
        mas[2, 0] == "O" && mas[2, 1] == "O" && mas[2, 2] == "O" ||
        mas[0, 0] == "O" && mas[1, 0] == "O" && mas[2, 0] == "O" ||
        mas[0, 1] == "O" && mas[1, 1] == "O" && mas[2, 1] == "O" ||
        mas[0, 2] == "O" && mas[1, 2] == "O" && mas[2, 2] == "O" ||
        mas[0, 0] == "O" && mas[1, 1] == "O" && mas[2, 2] == "O" ||
        mas[0, 2] == "O" && mas[1, 1] == "O" && mas[2, 0] == "O")
    {
        Console.WriteLine("Выйграли O");
        countO += 5;
        for (int k = 0; k < str; k++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write(mas[k, j] + " ");
            }
            Console.WriteLine();
        }
    }

    if (countO + countX <= 8)
    {
        for (int k = 0; k < str; k++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write(mas[k, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Введите координату клетки для хода O");
        step = int.Parse(Console.ReadLine()) - 1;
        mas[step / 3, step % 3] = "X";
        Console.Clear();
    }

    if (countO + countX <= 8)
    {
        for (int k = 0; k < str; k++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write(mas[k, j] + " ");
            }
            Console.WriteLine();
        }
        countX++;
        Console.Clear();
    }

    if (mas[0, 0] == "X" && mas[0, 1] == "X" && mas[0, 2] == "X" ||
        mas[1, 0] == "X" && mas[1, 1] == "X" && mas[1, 2] == "X" ||
        mas[2, 0] == "X" && mas[2, 1] == "X" && mas[2, 2] == "X" ||
        mas[0, 0] == "X" && mas[1, 0] == "X" && mas[2, 0] == "X" ||
        mas[0, 1] == "X" && mas[1, 1] == "X" && mas[2, 1] == "X" ||
        mas[0, 2] == "X" && mas[1, 2] == "X" && mas[2, 2] == "X" ||
        mas[0, 0] == "X" && mas[1, 1] == "X" && mas[2, 2] == "X" ||
        mas[0, 2] == "X" && mas[1, 1] == "X" && mas[2, 0] == "X")
    {
        Console.WriteLine("Выйграли X");
        countX += 5;
        for (int k = 0; k < str; k++)
        {
            for (int j = 0; j < column; j++)
            {
                Console.Write(mas[k, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

if (countX + countO == 8)
{
    Console.WriteLine("Нету выйгрывшых комбинаций");
    for (int k = 0; k < str; k++)
    {
        for (int j = 0; j < column; j++)
        {
            Console.Write(mas[k, j] + " ");
        }
        Console.WriteLine();
    }
    Console.ReadLine();
}