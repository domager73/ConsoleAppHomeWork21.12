using System;

namespace ConsoleApplication55
{
    class Program
    {

        enum Cell
        {
            Empty,
            AliveShip,
            DeadShip,
            Miss
        }
        enum Step
        {
            User,
            Comp
        }
        static void Main(string[] args)
        {

            //Морской бой
            #region Создание игровых полей и сопуствующих переменныхх
            int fieldSize = 10;


            Cell[,] userField = new Cell[fieldSize, fieldSize];
            Cell[,] compField = new Cell[fieldSize, fieldSize];

            int countUserShips = fieldSize;
            int countCompShips = fieldSize;

            Random rnd = new Random();
            int coordI, coordJ;
            bool inputResutCorrdI, inputResutCorrdJ;

            Step currentStep = Step.User;
            Step winner = Step.User;

            bool playGame = true;
            #endregion

            #region Заполнение полей пустотой
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    userField[i, j] = Cell.Empty;
                    compField[i, j] = Cell.Empty;
                }
            }
            #endregion

            #region Рандомная растановка кораблей на полях
            for (int k = 0; k < countUserShips; k++)
            {
                do
                {
                    coordI = rnd.Next(0, fieldSize);
                    coordJ = rnd.Next(0, fieldSize);
                } while (userField[coordI, coordJ] != Cell.Empty);

                userField[coordI, coordJ] = Cell.AliveShip;
            }

            for (int k = 0; k < countCompShips; k++)
            {
                do
                {
                    coordI = rnd.Next(0, fieldSize);
                    coordJ = rnd.Next(0, fieldSize);
                } while (compField[coordI, coordJ] != Cell.Empty);

                compField[coordI, coordJ] = Cell.AliveShip;
            }
            #endregion

            #region Игровой цикл
            while (playGame)
            {

                #region Вывод полей на экран
                Console.Clear();

                Console.WriteLine("USER FIELD");
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        switch (userField[i, j])
                        {
                            case Cell.Empty:
                                Console.Write(".");
                                break;
                            case Cell.AliveShip:
                                Console.Write("K");
                                break;
                            case Cell.DeadShip:
                                Console.Write("X");
                                break;
                            case Cell.Miss:
                                Console.Write("O");
                                break;
                            default:
                                break;
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("COMP FIELD");
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        switch (compField[i, j])
                        {
                            case Cell.Empty:
                                Console.Write(".");
                                break;
                            case Cell.AliveShip:
                                Console.Write(".");
                                break;
                            case Cell.DeadShip:
                                Console.Write("X");
                                break;
                            case Cell.Miss:
                                Console.Write("O");
                                break;
                            default:
                                break;
                        }
                    }
                    Console.WriteLine();
                }
                #endregion

                #region Ввод/рандом координат для выстрела и проверка на попадание и передача хода
                switch (currentStep)
                {
                    case Step.User:
                        Console.WriteLine("USER STEP NOW");
                        do
                        {
                            Console.Write("Input coord I: ");
                            inputResutCorrdI = int.TryParse(Console.ReadLine(), out coordI);

                            Console.Write("Input coord J: ");
                            inputResutCorrdJ = int.TryParse(Console.ReadLine(), out coordJ);

                        } while (inputResutCorrdI == false || inputResutCorrdJ == false || coordI - 1 < 0 || coordI - 1 > fieldSize - 1 || coordJ - 1 < 0 || coordJ - 1 > fieldSize - 1 || compField[coordI - 1, coordJ - 1] == Cell.DeadShip || compField[coordI - 1, coordJ - 1] == Cell.Miss);

                        if (compField[coordI - 1, coordJ - 1] == Cell.AliveShip)
                        {
                            compField[coordI - 1, coordJ - 1] = Cell.DeadShip;
                            countCompShips--;
                        }
                        else if (compField[coordI - 1, coordJ - 1] == Cell.Empty)
                        {
                            compField[coordI - 1, coordJ - 1] = Cell.Miss;
                            currentStep = Step.Comp;
                        }
                        break;
                    case Step.Comp:
                        Console.WriteLine("COMP STEP NOW <Press Enter>");
                        Console.ReadKey();

                        do
                        {
                            coordI = rnd.Next(0, fieldSize);
                            coordJ = rnd.Next(0, fieldSize);
                        } while (userField[coordI, coordJ] == Cell.DeadShip || userField[coordI, coordJ] == Cell.Miss);

                        if (userField[coordI, coordJ] == Cell.AliveShip)
                        {
                            userField[coordI, coordJ] = Cell.DeadShip;
                            countUserShips--;
                        }
                        else if (userField[coordI, coordJ] == Cell.Empty)
                        {
                            userField[coordI, coordJ] = Cell.Miss;
                            currentStep = Step.User;
                        }

                        break;
                }
                #endregion и

                #region Проверка на победу
                if (countUserShips == 0 || countCompShips == 0)
                {
                    playGame = false;
                    winner = currentStep;
                }
                #endregion
            }
            #endregion

            #region Вывод полей на экран
            Console.Clear();

            Console.WriteLine("USER FIELD");
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    switch (userField[i, j])
                    {
                        case Cell.Empty:
                            Console.Write(".");
                            break;
                        case Cell.AliveShip:
                            Console.Write("K");
                            break;
                        case Cell.DeadShip:
                            Console.Write("X");
                            break;
                        case Cell.Miss:
                            Console.Write("O");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("COMP FIELD");
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    switch (compField[i, j])
                    {
                        case Cell.Empty:
                            Console.Write(".");
                            break;
                        case Cell.AliveShip:
                            Console.Write(".");
                            break;
                        case Cell.DeadShip:
                            Console.Write("X");
                            break;
                        case Cell.Miss:
                            Console.Write("O");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
            #endregion

            #region Вывод победителя
            switch (winner)
            {
                case Step.User:
                    Console.WriteLine("User Win!");
                    break;
                case Step.Comp:
                    Console.WriteLine("Comp Win!");
                    break;
            }
            #endregion
        }
    }
}