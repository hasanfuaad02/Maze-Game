using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Maze_Game
{
    class Game
    {

        private World MyWorld;
        private Player CurrentPlayer;
        public void start()
        {


            //SetCursorPosition(4, 2);
            //Write("x");

            String[,] grid = {
           { "=","=","=","=" ,"=" ,"=","=" },
           { "="," ","="," " ," " ," ","=" },
           { " "," ","="," " ,"=" ," ","=" },
           { "="," ","="," " ,"=" ," ","=" },
           { "="," "," "," " ,"=" ,"X","=" },
           { "=","=","=","=" ,"=" ,"=","=" },


        };
             MyWorld = new World(grid);
             CurrentPlayer = new Player(0,2);
            RunGameLoop();           




          
            ReadKey(true);
        }
        private void DisplyIntro()
        {
            WriteLine("Welcome to the Maze Game !");
            WriteLine("\n Instructions");
            WriteLine(">> Use the arrow keys tom move ");
            Write(">>Try to reach the target, which look like theis: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("x");
            ResetColor();
            WriteLine(">> Press any key to start");
            ReadKey(true);
        }

        private void DisplyOutro()
        {
            Clear();
            WriteLine("You escape!");
            WriteLine("Thanks for playing");
            WriteLine("Press any key to exit...");
            ReadKey(true);

        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y ))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y ))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
                 }

        }
        //run for ever
        private void RunGameLoop()
        {
            DisplyIntro();
            while (true)
            {
                //draw evreything

                DrawFrame();
                // check for player input from the keyboard and move the player
                HandlePlayerInput();

                //check if the player has reached the target and end the game if so
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                 
                    break;
                }
                //todo!



                //give the console a chance to render
                System.Threading.Thread.Sleep(30);
            }
            DisplyOutro();
        }
    }
}
