using PlayX_O;

bool SeachVictoryO(char[,] mas)
{
    return mas[0, 0] == 'O' && mas[0, 1] == 'O' && mas[0, 2] == 'O' ||
        mas[1, 0] == 'O' && mas[1, 1] == 'O' && mas[1, 2] == 'O' ||
        mas[2, 0] == 'O' && mas[2, 1] == 'O' && mas[2, 2] == 'O' ||
        mas[0, 0] == 'O' && mas[1, 0] == 'O' && mas[2, 0] == 'O' ||
        mas[0, 1] == 'O' && mas[1, 1] == 'O' && mas[2, 1] == 'O' ||
        mas[0, 2] == 'O' && mas[1, 2] == 'O' && mas[2, 2] == 'O' ||
        mas[0, 0] == 'O' && mas[1, 1] == 'O' && mas[2, 2] == 'O' ||
        mas[0, 2] == 'O' && mas[1, 1] == 'O' && mas[2, 0] == 'O';
};

bool SeachVictoryX(char[,] mas)
{
    return mas[0, 0] == 'X' && mas[0, 1] == 'X' && mas[0, 2] == 'X' ||
        mas[1, 0] == 'X' && mas[1, 1] == 'X' && mas[1, 2] == 'X' ||
        mas[2, 0] == 'X' && mas[2, 1] == 'X' && mas[2, 2] == 'X' ||
        mas[0, 0] == 'X' && mas[1, 0] == 'X' && mas[2, 0] == 'X' ||
        mas[0, 1] == 'X' && mas[1, 1] == 'X' && mas[2, 1] == 'X' ||
        mas[0, 2] == 'X' && mas[1, 2] == 'X' && mas[2, 2] == 'X' ||
        mas[0, 0] == 'X' && mas[1, 1] == 'X' && mas[2, 2] == 'X' ||
        mas[0, 2] == 'X' && mas[1, 1] == 'X' && mas[2, 0] == 'X';
}

void CreateField(char[,] field)
{
    int str = field.GetLength(0);
    int column = field.GetLength(1);

    for (int i = 0; i < str; i++)
    {
        for (int j = 0; j < column; j++)
        {
            field[i, j] = (char)Constants.Star;
        }
    }
}

void DrawingField(char[,] field)
{
    int str = field.GetLength(0);
    int column = field.GetLength(1);

    for (int i = 0; i < str; i++)
    {
        for (int j = 0; j < column; j++)
        {
            Console.Write(field[i, j] + " ");
        }
        Console.WriteLine();
    }
}

bool CheckEndGame(bool countX, bool countO)
{
    return countX && countO == true;
}

void Write(string title)
{
    Console.WriteLine(title);
};

void Move(char[,] field, ref int moveCount, char sign)
{
    int step = int.Parse(Console.ReadLine()) - 1;
    field[step / 3, step % 3] = sign;
    moveCount++;
    Console.Clear();
}

bool CheckDraw(int moveCount, bool countX, bool countO) 
{
    return moveCount > 7 && countX && countO;
}
// ------------------------------------------

bool countX = true;
bool countO = true;
int moveCount = 0;

char[,] field = new char[(int)Constants.str, (int)Constants.column];

CreateField(field);

DrawingField(field);

Write("Введите координату клетки для хода X");
Move(field, ref moveCount, (char)Constants.singX);

while (moveCount < 9 && CheckEndGame(countX, countO))
{
    DrawingField(field);

    Write("Введите координату клетки для хода O");
    Move(field, ref moveCount, (char)Constants.singO);

    if (SeachVictoryO(field))
    {
        Write("Выйграли O");
        DrawingField(field);
        countO = false;
    }

    if (CheckEndGame(countX, countO))
    {
        DrawingField(field);

        Write("Введите координату клетки для хода X");
        Move(field, ref moveCount, (char)Constants.singX);
    }

    if (SeachVictoryX(field))
    {
        Write("Выйграли X");
        DrawingField(field);
        countX = false;
    }
}

if (CheckDraw(moveCount, countX, countO))
{
    Write("Нету выйгрывшых комбинаций");
    DrawingField(field);
    Console.ReadKey();
}