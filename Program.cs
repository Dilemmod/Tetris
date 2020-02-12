using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Array tetris = new Menu(20);
            Console.ReadKey();

        }
    }
    class Tetris : Array
    {

        public Tetris()
        {
            Console.Clear();
            getFilledArray();
            game();
        }
        private void setSizeArrey()
        {
            space = new char[22][];
            for (int i = 0; i < space.Length; i++)
            {
                space[i] = new char[space.Length / 2 + 1];
            }
        }
        protected override void getFilledArray()
        {
            setSizeArrey();
            for (int i = 1; i < space.Length; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    space[i][j] = ' ';
                    space[i][0] = 'I';
                    space[i][space.Length / 2] = 'I';
                    space[space.Length - 1][j] = 'X';
                }
            }
        }
        private Boolean stop = false;
        private void setFigure(char figure, int x, int y, ConsoleKey move)
        {
            //XILZT
            char s, e = ' ';
            switch (figure)
            {
                case 'x':
                    s = 'X';
                    space[x][y] = s;
                    space[x][y + 1] = s;
                    space[x - 1][y] = s;
                    space[x - 1][y + 1] = s;
                    stop = (space[x + 1][y + 1] == ' ' ? false : true);
                    switch (move)
                    {
                        case ConsoleKey.A:
                            space[x - 2][y + 2] = e;
                            space[x - 1][y + 2] = e;
                            break;
                        case ConsoleKey.D:
                            space[x - 2][y - 1] = e;
                            space[x - 1][y - 1] = e;
                            break;
                        default:
                            space[x - 2][y] = e;
                            space[x - 2][y + 1] = e;
                            break;
                    }
                    break;
                case 'i':
                    s = 'I';
                    space[x][y] = s;
                    space[x - 1][y] = s;
                    space[x - 2][y] = s;
                    space[x - 3][y] = s;
                    //Stop = (space[x + 2][y + 1] == ' ' ? false : true);
                    switch (move)
                    {
                        case ConsoleKey.A:
                            space[x][y + 1] = e;
                            space[x - 1][y + 1] = e;
                            space[x - 2][y + 1] = e;
                            space[x - 3][y + 1] = e;
                            space[x - 4][y + 1] = e;
                            break;
                        case ConsoleKey.D:
                            space[x][y - 1] = e;
                            space[x - 1][y - 1] = e;
                            space[x - 2][y - 1] = e;
                            space[x - 3][y - 1] = e;
                            space[x - 4][y - 1] = e;
                            break;
                        default:
                            space[x - 4][y] = e;
                            break;
                    }
                    break;
                case 'l':
                    s = 'L';
                    space[x][y] = s;
                    space[x][y + 1] = s;
                    space[x - 1][y] = s;
                    space[x - 2][y] = s;
                    stop = (space[x + 1][y + 1] == ' ' ? false : true);
                    switch (move)
                    {
                        case ConsoleKey.A:
                            space[x][y + 2] = e;
                            space[x - 1][y + 1] = e;
                            space[x - 2][y + 1] = e;
                            space[x - 3][y + 1] = e;
                            space[x - 1][y + 2] = e;
                            break;
                        case ConsoleKey.D:
                            space[x][y - 1] = e;
                            space[x - 1][y - 1] = e;
                            space[x - 2][y - 1] = e;
                            space[x - 3][y - 1] = e;
                            break;
                        default:
                            space[x - 3][y] = e;
                            space[x - 1][y + 1] = e;
                            break;
                    }
                    break;
                case 'z':
                    s = 'Z';
                    space[x][y] = s;
                    space[x][y + 1] = s;
                    space[x - 1][y] = s;
                    space[x - 1][y - 1] = s;
                    stop = (space[x][y - 1] != ' ' | space[x + 1][y + 1] != ' ' ? true : false);
                    switch (move)
                    {
                        case ConsoleKey.A:
                            space[x - 2][y + 1] = e;
                            space[x - 1][y + 2] = e;
                            break;
                        case ConsoleKey.D:
                            space[x][y] = e;
                            space[x - 1][y - 1] = e;
                            space[x - 2][y - 2] = e;
                            break;
                        default:
                            space[x - 2][y] = e;
                            space[x - 2][y - 1] = e;
                            space[x - 1][y + 1] = e;
                            break;
                    }
                    break;
                case 't':
                    s = 'T';
                    space[x][y] = s;
                    space[x - 1][y] = s;
                    space[x - 1][y - 1] = s;
                    space[x - 1][y + 1] = s;
                    stop = (space[x][y - 1] != ' ' | space[x][y + 1] != ' ' ? true : false);
                    switch (move)
                    {
                        case ConsoleKey.A:
                            space[x - 2][y + 2] = e;
                            break;
                        case ConsoleKey.D:
                            space[x - 2][y - 2] = e;
                            break;
                        default:
                            space[x - 2][y] = e;
                            space[x - 2][y - 1] = e;
                            space[x - 2][y + 1] = e;
                            break;
                    }
                    break;
            }
        }
        //Метод для регулеровки поворота
        private bool rightLeft(char f, ConsoleKey rightLeft)
        {
            switch (f)
            {
                case 'x':
                    if (rightLeft == ConsoleKey.D)
                    {
                        if (space[x][y + 2] == ' ' && space[x - 1][y + 2] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (space[x][y - 1] == ' ' && space[x - 1][y - 1] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                case 'i':
                    if (rightLeft == ConsoleKey.D)
                    {
                        if (space[x][y + 1] == ' ' && space[x - 1][y + 1] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (space[x][y - 1] == ' ' && space[x - 1][y - 1] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                case 'l':
                    if (rightLeft == ConsoleKey.D)
                    {
                        if (space[x][y + 2] == ' ' && space[x - 1][y + 2] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (space[x][y - 1] == ' ' && space[x - 1][y - 1] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                case 'z':
                    if (rightLeft == ConsoleKey.D)
                    {
                        if (space[x - 1][y + 2] == ' ' && space[x][y + 2] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (space[x][y - 1] == ' ' && space[x - 1][y - 2] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                case 't':
                    if (rightLeft == ConsoleKey.D)
                    {
                        if (space[x - 1][y + 2] == ' ' && space[x][y + 1] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        if (space[x][y - 1] == ' ' && space[x - 1][y - 2] == ' ')
                        {
                            return true;
                        }
                        else return false;
                    }
                default:
                    return false;
            }
        }
        private bool bonus(int x)
        {
            for (int y = 1, ch = 0; y < 12; y++)
            {
                ch += (space[x][y] != ' ' ? 1 : 0);
                if (ch == 10) return true;
            }
            return false;
        }
        protected override void game()
        {
            ConsoleKeyInfo navigation;
            Random rand = new Random();
            int score = 0;
            char[] figure = { 'x', 'i', 'l', 'z', 't' };
            int primaryTime = 500;
            int temp = 0;
            //Пока не достигнут предел
            Console.WriteLine("\t\t\t\tRULS OF THE GAME");
            Console.WriteLine("\t\t\tThe goal of the game is to collect HORIZONTAL lines of symbols");
            Console.WriteLine("\t\t\tTo speed up, press ONCE S");
            Console.WriteLine("\t\t\tDo not hold down the keys, press once");
            Console.WriteLine("\t\t\tWith each new figure, the game will accelerate");
            Console.WriteLine("\t\t\tGood LUCK");
            Console.ReadKey();
            Console.SetCursorPosition(0, 0);
            while (space[2][5] == ' ')
            {
                int indexFigure = rand.Next(0, figure.Length);
                y = 5;
                x = ((indexFigure == 1 ? 4 : (indexFigure == 2 ? 3 : (indexFigure == 0 || indexFigure == 3 || indexFigure == 4 ? 2 : 0))));
                for (int time = primaryTime; space[x][y] == ' '; x++)
                {
                    if (stop)
                    {
                        stop = false;
                        temp = x;
                        break;
                    }
                    if (Console.KeyAvailable)
                    {
                        navigation = Console.ReadKey(true);
                        switch (navigation.Key)
                        {
                            case ConsoleKey.D:
                                if (rightLeft(figure[indexFigure], ConsoleKey.D))
                                {
                                    y++;
                                    setFigure(figure[indexFigure], x, y, ConsoleKey.D);
                                }
                                break;
                            case ConsoleKey.A:
                                if (rightLeft(figure[indexFigure], ConsoleKey.A))
                                {
                                    y--;
                                    setFigure(figure[indexFigure], x, y, ConsoleKey.A);
                                }
                                break;
                        }
                        time = (navigation.Key == ConsoleKey.S ? 100 : primaryTime);
                    }
                    temp = x;
                    setFigure(figure[indexFigure], x, y, ConsoleKey.Enter);
                    getArrey();
                    Console.SetCursorPosition(0, 0);
                    Thread.Sleep(time);
                }
                if (x != 2 && x != 3 && x != 4)
                {
                    Console.Write(bonus(temp) ? "\t\t\tYour SCORE = " + (score += 100) : "");
                }
                primaryTime -= (primaryTime == 150 ? 0 : 50);
            }
            Console.Clear();
            Console.WriteLine("GAME OWER");
            Console.WriteLine("Your score = " + score);
            Console.ReadLine();
        }
    }
    class Menu : Array
    {
        protected int exit, tetris, length;

        public Menu(int size)
        {
            setSizeArrey(size);
            getFilledArray();
            game();
        }
        protected override void getFilledArray()
        {
            for (int i = 0; i < space.Length; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    space[i][j] = ' ';
                    space[i][0] = 'I';
                    space[i][space.Length - 1] = 'I';
                    space[space.Length - 1][j] = 'X';
                    space[0][j] = 'X';
                    x = space.Length / 2;
                    y = space.Length / 2;
                    space[x][y] = '@';

                    length = space.Length;
                    exit = percent(space.Length, 75);
                    space[exit][space.Length / 2 - 2] = 'E'; space[exit - 1][space.Length / 2 - 2] = '_'; space[exit][space.Length / 2 - 3] = '<';
                    space[exit][space.Length / 2 - 1] = 'X'; space[exit - 1][space.Length / 2 - 1] = '_';
                    space[exit][space.Length / 2] = 'I'; space[exit - 1][space.Length / 2] = '_';
                    space[exit][space.Length / 2 + 1] = 'T'; space[exit - 1][space.Length / 2 + 1] = '_'; space[exit][space.Length / 2 + 2] = '>';

                    tetris = percent(space.Length, 40);
                    space[tetris][space.Length / 2 - 3] = 'T'; space[tetris - 1][space.Length / 2 - 3] = '_'; space[tetris][space.Length / 2 - 4] = '<';
                    space[tetris][space.Length / 2 - 2] = 'E'; space[tetris - 1][space.Length / 2 - 2] = '_';
                    space[tetris][space.Length / 2 - 1] = 'T'; space[tetris - 1][space.Length / 2 - 1] = '_';
                    space[tetris][space.Length / 2] = 'R'; space[tetris - 1][space.Length / 2] = '_';
                    space[tetris][space.Length / 2 + 1] = 'I'; space[tetris - 1][space.Length / 2 + 1] = '_';
                    space[tetris][space.Length / 2 + 2] = 'S'; space[tetris - 1][space.Length / 2 + 2] = '_'; space[tetris][space.Length / 2 + 3] = '>';

                }
            }
        }
        protected override void game()
        {
            ConsoleKeyInfo navigation;
            while (x != -1)
            {
                if (x == exit && (y < length / 2 + 3 && y > length / 2 - 4))
                {
                    break;
                }
                if (x == tetris && (y < length / 2 + 4 && y > length / 2 - 5))
                {
                    Array tetris = new Tetris();
                    break;
                }
                getArrey();
                navigation = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0);
                char temp = space[x][y];
                space[x][y] = '-';
                switch (navigation.Key)
                {
                    case ConsoleKey.NumPad0:
                        navigation = Console.ReadKey(true);
                        Console.Clear();
                        //What size array is needed
                        setSizeArrey(navigation.Key == ConsoleKey.NumPad2 ? 20 : (navigation.Key == ConsoleKey.NumPad3 ? 30 : (navigation.Key == ConsoleKey.NumPad4 ? 40 : 10)));
                        getFilledArray();
                        break;
                    case ConsoleKey.E:
                        x = exit;
                        y = length / 2 + 2;
                        break;
                    case ConsoleKey.D:
                        y = (y == space.Length - 1 ? 0 : y + 1);
                        break;
                    case ConsoleKey.A:
                        y = (y == 0 ? space.Length - 1 : y - 1);
                        break;
                    case ConsoleKey.S:
                        x = (x == space.Length - 1 ? 0 : x + 1);
                        break;
                    case ConsoleKey.W:
                        x = (x == 0 ? space.Length - 1 : x - 1);
                        break;
                }
                space[x][y] = temp;
            }
        }
    }
    abstract class Array
    {
        protected int x, y;
        protected char[][] space;
        protected int percent(int number, int percent)
        {
            return (number * percent) / 100;
        }
        protected abstract void getFilledArray();
        protected abstract void game();
        public virtual void getArrey()
        {
            for (int i = 0; i < space.Length; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    Console.Write(space[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public virtual void setSizeArrey(int s)
        {
            s = (s < 10 ? 10 : (s > 40 ? 40 : s));
            space = new char[s][];
            for (int i = 0; i < space.Length; i++)
            {
                space[i] = new char[s];
            }
        }
    }
}