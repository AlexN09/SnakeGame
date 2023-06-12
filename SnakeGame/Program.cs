using SnakeGame;
using System;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Lifetime;
using System.Security.Claims;
using System.Security.Permissions;
using System.Threading;

namespace ConsoleApp3
{
    internal class Program
    {
        static int direction = 0;
        static int steps = 0;
        static int foods = 0;
        static int life = 3;
        static int goalFoods = 2;
        static int flag = 0;
        static int level = 1;
        static int speed = 80;
        static bool continuee = false;
        static bool continued = false;
        static bool win = false;
        static bool bolean = false;


        static void Main(string[] args)
        {
         
            Thread thread2 = new Thread(thread);
            bool onetap = true;
            thread2.Start();
            Console.WindowWidth = 66;
            Console.WindowHeight = 27;
            System.Reflection.Assembly assembly2 = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream resourceStream7 = assembly2.GetManifestResourceStream(@"SnakeGame.title.wav");
            SoundPlayer player7 = new SoundPlayer(resourceStream7);
            player7.Play();
            Console.CursorVisible = false;
            Console.WriteLine();

            Console.WriteLine("             \r\n           ░██████╗███╗░░██╗░█████╗░██╗░░██╗███████╗\r\n           ██╔════╝████╗░██║██╔══██╗██║░██╔╝██╔════╝\r\n           ╚█████╗░██╔██╗██║███████║█████═╝░█████╗░░\r\n           ░╚═══██╗██║╚████║██╔══██║██╔═██╗░██╔══╝░░\r\n           ██████╔╝██║░╚███║██║░░██║██║░╚██╗███████╗\r\n           ╚═════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");

            Console.SetCursorPosition(27, 10);
            Console.WriteLine("1.Start");
            Console.SetCursorPosition(27, 12);
            Console.WriteLine("2.Help");


            while (true)
            {
                bool exitLoop = false;

                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.KeyChar == '1')
                    {
                        player7.Stop();

                        exitLoop = true;
                        Console.Clear();

                        Console.SetCursorPosition(28, 13);
                        Console.WriteLine("LEVEL " + level);
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.SetCursorPosition(21, 13);
                        Console.WriteLine("COLLECT 10 APPLES TO WIN");
                        Thread.Sleep(2000);

                        Console.Clear();

                        break;
                    }

                    if (keyInfo.KeyChar == '2' && onetap == true)
                    {
                        onetap = false;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("                          Controls: ←↑→");
                        Console.WriteLine("                          O - APPLE");
                        Console.WriteLine("                          $ - BONUS");

                    }
                } while (Console.KeyAvailable);

                if (exitLoop)
                    break;
            }




            while (true)
            {

                int head_x = 0;
                int head_y = 0;
                int last_x = 0;
                int last_y = 0;
                int single_x = 0;
                int single_y = 0;

                bool collisionDetected = false;

                Worm wrm = new Worm();

                Food fd = new Food();
                bonus bonus = new bonus();
                wrm.snake_body.Add((15, 15));





                char[,] field = new char[65, 25];









                int move_x = 17;
                int move_y = 15;
                Console.CursorVisible = false;









                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream resourceStream = assembly.GetManifestResourceStream(@"SnakeGame.one_beep.wav");
                SoundPlayer player1 = new SoundPlayer(resourceStream);


                System.IO.Stream resourceStream2 = assembly.GetManifestResourceStream(@"SnakeGame.videogame-death.wav");
                SoundPlayer player2 = new SoundPlayer(resourceStream);
                player2 = new SoundPlayer(resourceStream2);


                System.IO.Stream resourceStream3 = assembly.GetManifestResourceStream(@"SnakeGame.win_sound.wav");
                SoundPlayer player3 = new SoundPlayer(resourceStream);
                player3 = new SoundPlayer(resourceStream3);



                System.IO.Stream resourceStream4 = assembly.GetManifestResourceStream(@"SnakeGame.coin-collect.wav");
                SoundPlayer player4 = new SoundPlayer(resourceStream);
                player4 = new SoundPlayer(resourceStream4);


                System.IO.Stream resourceStream5 = assembly.GetManifestResourceStream(@"SnakeGame.crash.wav");
                SoundPlayer player5 = new SoundPlayer(resourceStream5);
                player5 = new SoundPlayer(resourceStream5);


                System.IO.Stream resourceStream6 = assembly.GetManifestResourceStream(@"SnakeGame.bonus.wav");
                SoundPlayer player6 = new SoundPlayer(resourceStream6);
                player6 = new SoundPlayer(resourceStream6);










                for (int j = 0; j < 25; j++)
                {
                    for (int i = 0; i < 65; i++)
                    {
                        if (i == 0 || i == 64 || j == 0 || j == 24)
                        {
                            field[i, j] = '@';
                        }
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }








                Random rnd = new Random();
                fd.x = rnd.Next(2, 63);
                fd.y = rnd.Next(2, 23);





                for (int i = 0; i < 65; i++)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }
                foreach (var item in wrm.snake_body)
                {
                    Console.SetCursorPosition(item.Item1, item.Item2);
                    Console.Write('*');
                }

                for (int i = 0; i < 65; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (i == fd.x && j == fd.y)
                        {
                            Console.SetCursorPosition(i, j);

                            Console.Write(fd.smb);
                        }
                    }
                }
                Thread.Sleep(50);
                Console.SetCursorPosition(0, 25);
                Console.Write("Steps: " + steps + "   Foods: " + foods + "    lifes: " + life);





                while (true)
                {



                    if (direction == 1)
                    {

                        steps++;



                        wrm.snake_body.Insert(0, (move_x, move_y));
                        move_x++;
                        last_x = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item1;
                        last_y = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item2;
                        head_x = wrm.snake_body.ElementAt(0).Item1;
                        head_y = wrm.snake_body.ElementAt(0).Item2;
                        Console.SetCursorPosition((int)last_x, (int)last_y);
                        Console.Write(' ');
                        wrm.snake_body.RemoveAt(wrm.snake_body.Count - 1);




                        foreach (var item in wrm.snake_body)
                        {
                            Console.SetCursorPosition(item.Item1, item.Item2);
                            Console.Write('*');
                        }
                        Thread.Sleep(speed);






                        if (head_x == fd.x && head_y == fd.y)
                        {


                            wrm.snake_body.Add((last_x, last_y));
                            Thread.Sleep(3);
                            player4.Play();
                            foods++;
                            fd.x = rnd.Next(2, 63);
                            fd.y = rnd.Next(2, 23);


                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (fd.x == i && fd.y == j)
                                    {

                                        Console.SetCursorPosition(i, j);
                                        Console.Write(fd.smb);
                                    }
                                }

                            }
                            if (level == 3 && foods == 30)
                            {
                                win = true;
                                break;
                            }
                        }



                        if (foods == flag + 5 && life != 3)
                        {

                            flag += 5;
                            bonus.bonus_x = rnd.Next(2, 63);
                            bonus.bonus_y = rnd.Next(2, 23);

                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (i == bonus.bonus_x && j == bonus.bonus_y)
                                    {
                                        Console.SetCursorPosition(i, j);

                                        Console.Write(bonus.bonusSmb);

                                    }
                                }


                            }

                        }
                        if (head_x == bonus.bonus_x && head_y == bonus.bonus_y)
                        {
                            bonus.bonus_x = -1;
                            bonus.bonus_y = -1;
                            player6.Play();
                            life++;
                        }

                        if (head_x + 1 == 64)
                        {
                            bolean = true;
                            life--;
                            break;
                        }
                        if (foods == goalFoods)
                        {

                            if (level < 3)
                            {
                                foods = 0;
                                direction = 0;
                                continuee = true;
                                speed -= 25;
                                level++;
                                goalFoods += 10;

                                Console.Clear();
                                Console.SetCursorPosition(28, 13);
                                Console.WriteLine("LEVEL " + level);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.SetCursorPosition(21, 13);
                                Console.WriteLine("COLLECT " + goalFoods + " APPLES TO WIN");
                                Thread.Sleep(2000);

                                Console.Clear();
                                break;
                            }
                            if (level > 3)
                            {
                                win = true;
                                break;
                            }
                        }
                        collisionDetected = false;
                        for (int i = 2; i < wrm.snake_body.Count; i++)
                        {
                            single_x = wrm.snake_body[i].Item1;
                            single_y = wrm.snake_body[i].Item2;
                            if (single_x == head_x && single_y == head_y)
                            {
                                bolean = true;
                                life--;
                                collisionDetected = true;
                                break;

                            }
                        }
                        if (collisionDetected)
                        {
                            break;
                        }



                        Console.SetCursorPosition(0, 25);
                        Console.Write("Steps: " + steps + "   Foods: " + foods + "    lifes: " + life);
                    }
                    if (direction == 2)
                    {
                        wrm.snake_body.Insert(0, (move_x, move_y));
                        move_x--;
                        last_x = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item1;
                        last_y = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item2;
                        head_x = wrm.snake_body.ElementAt(0).Item1;
                        head_y = wrm.snake_body.ElementAt(0).Item2;
                        Console.SetCursorPosition((int)last_x, (int)last_y);
                        Console.Write(' ');
                        wrm.snake_body.RemoveAt(wrm.snake_body.Count - 1);
                        steps++;
                        if (level == 3 && foods == 30)
                        {
                            win = true;
                            break;
                        }


                        foreach (var item in wrm.snake_body)
                        {
                            Console.SetCursorPosition(item.Item1, item.Item2);
                            Console.Write('*');
                        }
                        Thread.Sleep(speed);

                        Console.SetCursorPosition(0, 25);
                        Console.Write("Steps: " + steps + "   Foods: " + foods + "    lifes: " + life);


                        if (head_x == 1)
                        {
                            bolean = true;
                            life--;
                            break;
                        }

                        if (head_x == fd.x && head_y == fd.y)
                        {

                            wrm.snake_body.Add((last_x, last_y));
                            Thread.Sleep(3);
                            player4.Play();
                            foods++;
                            fd.x = rnd.Next(2, 63);
                            fd.y = rnd.Next(2, 23);


                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (fd.x == i && fd.y == j)
                                    {

                                        Console.SetCursorPosition(i, j);
                                        Console.Write(fd.smb);
                                    }
                                }

                            }
                            if (level == 3 && foods == 30)
                            {
                                win = true;
                                break;
                            }
                        }


                        if (foods == flag + 5 && life != 3)
                        {

                            flag += 5;
                            bonus.bonus_x = rnd.Next(2, 63);
                            bonus.bonus_y = rnd.Next(2, 23);

                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (i == bonus.bonus_x && j == bonus.bonus_y)
                                    {
                                        Console.SetCursorPosition(i, j);
                                        Console.Write(bonus.bonusSmb);
                                    }
                                }


                            }

                        }
                        if (head_x == bonus.bonus_x && head_y == bonus.bonus_y)
                        {
                            bonus.bonus_x = -1;
                            bonus.bonus_y = -1;
                            player6.Play();
                            life++;
                        }
                        if (foods == goalFoods)
                        {

                            if (level < 3)
                            {
                                foods = 0;
                                direction = 0;
                                continuee = true;
                                speed -= 25;
                                level++;
                                goalFoods += 10;

                                Console.Clear();
                                Console.SetCursorPosition(28, 13);
                                Console.WriteLine("LEVEL " + level);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.SetCursorPosition(21, 13);
                                Console.WriteLine("COLLECT " + goalFoods + " APPLES TO WIN");
                                Thread.Sleep(2000);

                                Console.Clear();
                                break;
                            }
                            if (level > 3)
                            {
                                win = true;
                                break;
                            }
                        }














                        collisionDetected = false;
                        for (int i = 2; i < wrm.snake_body.Count; i++)
                        {
                            single_x = wrm.snake_body[i].Item1;
                            single_y = wrm.snake_body[i].Item2;
                            if (single_x == head_x && single_y == head_y)
                            {
                                bolean = true;
                                life--;
                                collisionDetected = true;
                                break;

                            }
                        }
                        if (collisionDetected)
                        {
                            break;
                        }



                    }


                    if (direction == 3)
                    {
                        steps++;


                        wrm.snake_body.Insert(0, (move_x, move_y));
                        move_y--;
                        last_x = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item1;
                        last_y = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item2;
                        head_x = wrm.snake_body.ElementAt(0).Item1;
                        head_y = wrm.snake_body.ElementAt(0).Item2;
                        Console.SetCursorPosition((int)last_x, (int)last_y);
                        Console.Write(' ');
                        wrm.snake_body.RemoveAt(wrm.snake_body.Count - 1);



                        foreach (var item in wrm.snake_body)
                        {
                            Console.SetCursorPosition(item.Item1, item.Item2);
                            Console.Write('*');
                        }
                        Thread.Sleep(speed);



                        if (head_y == 1)
                        {
                            bolean = true;
                            life--;
                            break;
                        }



                        if (head_x == fd.x && head_y == fd.y)
                        {

                            wrm.snake_body.Add((last_x, last_y));
                            Thread.Sleep(3);
                            player4.Play();
                            foods++;
                            fd.x = rnd.Next(2, 63);
                            fd.y = rnd.Next(2, 23);


                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (fd.x == i && fd.y == j)
                                    {

                                        Console.SetCursorPosition(i, j);
                                        Console.Write(fd.smb);
                                    }
                                }

                            }
                            if (level == 3 && foods == 30)
                            {
                                win = true;
                                break;
                            }
                        }

                        if (foods == goalFoods)
                        {

                            if (level < 3)
                            {
                                foods = 0;
                                direction = 0;
                                continuee = true;
                                speed -= 25;
                                level++;
                                goalFoods += 10;

                                Console.Clear();
                                Console.SetCursorPosition(28, 13);
                                Console.WriteLine("LEVEL " + level);
                                Thread.Sleep(2000);

                                Console.Clear();
                                Console.SetCursorPosition(21, 13);
                                Console.WriteLine("COLLECT " + goalFoods + " APPLES TO WIN");
                                Thread.Sleep(2000);

                                Console.Clear();
                                break;
                            }
                            if (level > 3)
                            {
                                win = true;
                                break;
                            }
                        }


                        if (foods == flag + 5 && life != 3)
                        {

                            flag += 5;
                            bonus.bonus_x = rnd.Next(2, 63);
                            bonus.bonus_y = rnd.Next(2, 23);

                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (i == bonus.bonus_x && j == bonus.bonus_y)
                                    {
                                        Console.SetCursorPosition(i, j);
                                        Console.Write(bonus.bonusSmb);
                                    }
                                }


                            }

                        }
                        if (head_x == bonus.bonus_x && head_y == bonus.bonus_y)
                        {
                            bonus.bonus_x = -1;
                            bonus.bonus_y = -1;
                            player6.Play();
                            life++;
                        }

                        collisionDetected = false;
                        for (int i = 2; i < wrm.snake_body.Count; i++)
                        {
                            single_x = wrm.snake_body[i].Item1;
                            single_y = wrm.snake_body[i].Item2;
                            if (single_x == head_x && single_y == head_y)
                            {
                                bolean = true;
                                life--;
                                collisionDetected = true;
                                break;

                            }
                        }
                        if (collisionDetected)
                        {
                            break;
                        }



                        Console.SetCursorPosition(0, 25);
                        Console.Write("Steps: " + steps + "   Foods: " + foods + "    lifes: " + life);
                    }
                    if (direction == 4)
                    {
                        steps++;
                        wrm.snake_body.Insert(0, (move_x, move_y));
                        move_y++;
                        last_x = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item1;
                        last_y = wrm.snake_body.ElementAt(wrm.snake_body.Count - 1).Item2;
                        head_x = wrm.snake_body.ElementAt(0).Item1;
                        head_y = wrm.snake_body.ElementAt(0).Item2;
                        Console.SetCursorPosition((int)last_x, (int)last_y);
                        Console.Write(' ');
                        wrm.snake_body.RemoveAt(wrm.snake_body.Count - 1);
                        steps++;



                        foreach (var item in wrm.snake_body)
                        {
                            Console.SetCursorPosition(item.Item1, item.Item2);
                            Console.Write('*');
                        }
                        Thread.Sleep(speed);






                        if (head_y == 23)
                        {
                            bolean = true;
                            life--;
                            break;
                        }
                        if (head_x == fd.x && head_y == fd.y)
                        {

                            wrm.snake_body.Add((last_x, last_y));
                            Thread.Sleep(3);
                            player4.Play();
                            foods++;
                            fd.x = rnd.Next(2, 63);
                            fd.y = rnd.Next(2, 23);


                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (fd.x == i && fd.y == j)
                                    {

                                        Console.SetCursorPosition(i, j);
                                        Console.Write(fd.smb);
                                    }
                                }

                            }
                            if (level == 3 && foods == 30)
                            {
                                win = true;
                                break;
                            }
                        }

                        Console.SetCursorPosition(0, 25);
                        Console.Write("Steps: " + steps + "   Foods: " + foods + "    lifes: " + life);



                        if (foods == flag + 5 && life != 3)
                        {

                            flag += 5;
                            bonus.bonus_x = rnd.Next(3, 62);
                            bonus.bonus_y = rnd.Next(3, 22);

                            for (int i = 0; i < 65; i++)
                            {
                                for (int j = 0; j < 25; j++)
                                {
                                    if (i == bonus.bonus_x && j == bonus.bonus_y)
                                    {
                                        Console.SetCursorPosition(i, j);
                                        Console.Write(bonus.bonusSmb);
                                    }
                                }


                            }

                        }
                        if (head_x == bonus.bonus_x && head_y == bonus.bonus_y)
                        {
                            bonus.bonus_x = -1;
                            bonus.bonus_y = -1;
                            player6.Play();
                            life++;
                        }
                        if (foods == goalFoods)
                        {

                            if (level < 3)
                            {
                                foods = 0;
                                direction = 0;
                                continuee = true;
                                speed -= 25;
                                level++;
                                goalFoods += 10;

                                Console.Clear();

                                Console.SetCursorPosition(28, 13);
                                Console.WriteLine("LEVEL " + level);
                                Thread.Sleep(2000);
                                Console.Clear();

                                Console.SetCursorPosition(21, 13);
                                Console.WriteLine("COLLECT " + goalFoods + " APPLES TO WIN");
                                Thread.Sleep(2000);

                                Console.Clear();
                                break;
                            }
                            if (level > 3)
                            {
                                win = true;
                                break;
                            }
                        }


                    }

                    collisionDetected = false;
                    for (int i = 2; i < wrm.snake_body.Count; i++)
                    {
                        single_x = wrm.snake_body[i].Item1;
                        single_y = wrm.snake_body[i].Item2;
                        if (single_x == head_x && single_y == head_y)
                        {
                            bolean = true;
                            life--;
                            collisionDetected = true;
                            break;

                        }
                    }
                    if (collisionDetected)
                    {
                        break;
                    }
                }
                if (life > 0 && bolean == true)
                {
                    player5.Play();
                    flag = foods;
                    Console.Clear();
                    direction = 0;
                    bolean = false;
                    continue;
                }
                if (life == 0)
                {
                    player2.Play();
                    Console.Clear();
                    Console.SetCursorPosition(27, 13);
                    Console.WriteLine("GAME OVER");
                    Thread.Sleep(2000);
                    Console.Clear();
                    player7.Play();
                    Console.CursorVisible = false;
                    Console.WriteLine();
                    Console.WriteLine("             \r\n           ░██████╗███╗░░██╗░█████╗░██╗░░██╗███████╗\r\n           ██╔════╝████╗░██║██╔══██╗██║░██╔╝██╔════╝\r\n           ╚█████╗░██╔██╗██║███████║█████═╝░█████╗░░\r\n           ░╚═══██╗██║╚████║██╔══██║██╔═██╗░██╔══╝░░\r\n           ██████╔╝██║░╚███║██║░░██║██║░╚██╗███████╗\r\n           ╚═════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝");
                    direction = 0;
                    bool exitLoop = false;
                    steps = 0;
                    foods = 0;
                    life = 3;
                    goalFoods = 10;
                    flag = 0;
                    level = 1;
                    speed = 80;
                    continuee = false;
                    win = false;
                    bolean = false;
                    Console.SetCursorPosition(27, 10);
                    Console.WriteLine("1.Start");
                    Console.SetCursorPosition(27, 12);
                    Console.WriteLine("2.Help");

                    while (true)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        if (keyInfo.KeyChar == '1')
                        {
                            player7.Stop();
                            exitLoop = true;
                            Console.Clear();
                            Console.SetCursorPosition(28, 13);
                            Console.WriteLine("LEVEL " + level);
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.SetCursorPosition(21, 13);
                            Console.WriteLine("COLLECT 10 APPLES TO WIN");
                            Thread.Sleep(2000);
                            bolean = false;
                            Console.Clear();
                            continued = true;
                            exitLoop = true;
                            break;
                        }
                        else if (keyInfo.KeyChar == '2' && onetap == true)
                        {
                            onetap = false;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("                          Controls: ←↑→");
                            Console.WriteLine("                          O - APPLE");
                            Console.WriteLine("                          $ - BONUS");
                        }

                        if (exitLoop)
                        {
                            break;
                        }
                    }
                }
                else if (continued)
                {
                    Console.Clear();
                    continue;
                }

                if (win)
                {
                    player3.Play();
                    Console.Clear();
                    Console.SetCursorPosition(27, 13);
                    Console.WriteLine("YOU WON");
                    break;
                }

                if (continuee)
                {
                    Console.Clear();
                    continue;
                }











            }




        }
        static void thread()
        {
            ConsoleKeyInfo keyInfo;
            do
            {


                while (!Console.KeyAvailable) // Ожидание нажатия клавиши
                {
                    // Здесь может быть выполнение других операций
                }

                keyInfo = Console.ReadKey(true);


                if (keyInfo.Key == ConsoleKey.RightArrow)
                {

                    if (direction != 2)
                    {
                        Thread.Sleep(1);
                        direction = 1;
                    }



                }
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != 1)
                    {
                        Thread.Sleep(1);
                        direction = 2;
                    }



                }


                if (keyInfo.Key == ConsoleKey.DownArrow)
                {

                    if (direction != 3)
                    {
                        Thread.Sleep(1);
                        direction = 4;
                    }


                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (direction != 4)
                    {
                        Thread.Sleep(1);
                        direction = 3;
                    }



                }



            } while (keyInfo.Key != ConsoleKey.Escape);
        }









    }
}

