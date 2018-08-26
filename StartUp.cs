using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            var snakeElements = new Queue<Position>();

            var directions = new Position[]
            {
                new Position(0,1), //right
                new Position(0,-1), //left
                new Position(1,0), //down
                new Position(-1,0) //up
            };

            Console.BufferHeight = Console.WindowHeight;
            Random randomNumbers = new Random();

           
           

            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
            var direction=0;

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.Write("*");

            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }

                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;
                    }

                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        direction = 3;
                    }

                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        direction = 2;
                    }


                }
                

                var snakeHead=snakeElements.Last();
                snakeElements.Dequeue();
                var newDirection = directions[direction];

                var newPosition = new Position(snakeHead.Row+newDirection.Row,snakeHead.Col+newDirection.Col);


                snakeElements.Enqueue(newPosition);

                Console.Clear();


                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.Col, position.Row);
                    Console.Write("*");

                }
                

                Thread.Sleep(100);
                
            }



        }
    }
}
