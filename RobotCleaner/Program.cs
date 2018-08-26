using System;
using System.Collections;
using System.Collections.Generic;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {       

            /*****  ROBOT INPUT COLLECTION    *****/

            //First Input: the number of commands to be exceuted
            int numberOfCommands = 0;
            int.TryParse(Console.ReadLine(),out numberOfCommands);

            //Second Input: the initial coodinates of the robot
            int xCoordinate = 0, yCoordinate = 0;
            var coordinates = Console.ReadLine().Split(" ");

            int.TryParse(coordinates[0], out xCoordinate);
            int.TryParse(coordinates[1], out yCoordinate);

            //Third Input: the cleaning commands
            (string direction, int steps) GetCommand()
            {
                string direction;
                int steps;

                var commandInput = Console.ReadLine().Split(" ");
                direction = commandInput[0];
                int.TryParse(commandInput[1], out steps);

                return (direction, steps);
            }

            //collect all input commands to be executed by the robot
            var commands = new List<(string direction, int steps)>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                commands.Add(GetCommand());
            }


            /*****  ROBOT CLEANING OPERATION    *****/

            var uniquePlaces = new HashSet<(int x, int y)>();

            uniquePlaces.Add((xCoordinate, yCoordinate));

            foreach (var command in commands)
            {
                switch (command.direction)
                {
                    case "E":
                        {
                            //x++
                            int x = xCoordinate;
                            int stopPlace = xCoordinate + command.steps;

                            for (; x <= 100_000 && x <= stopPlace; x++)
                            {
                                uniquePlaces.Add((x, yCoordinate));
                            }
                            //update the current coordinates on the robot
                            xCoordinate = x - 1;
                            break;
                        }

                    case "W":
                        {
                            //x--
                            int x = xCoordinate;
                            int stopPlace = xCoordinate - command.steps;

                            for (; x >= -100_000 && x >= stopPlace; x--)
                            {
                                uniquePlaces.Add((x, yCoordinate));
                            }
                            //update the current coordinates on the robot
                            xCoordinate = x + 1;
                            break;
                        }

                    case "N":
                        {
                            //y++
                            int y = yCoordinate;
                            int stopPlace = yCoordinate + command.steps;

                            for (; y <= 100_000 && y <= stopPlace; y++)
                            {
                                uniquePlaces.Add((xCoordinate, y));
                            }
                            //update the current coordinates on the 
                            yCoordinate = y - 1;
                            break;
                        }

                    case "S":
                        {
                            //y--
                            int y = yCoordinate;
                            int stopPlace = yCoordinate - command.steps;

                            for (; y >= -100_000 && y >= stopPlace; y--)
                            {
                                uniquePlaces.Add((xCoordinate, y));
                            }
                            //update the current coordinates on the robot
                            yCoordinate = y + 1;
                            break;
                        }

                    default:
                        break;
                }
            }


            /*****  ROBOT CLEANING REPORT    *****/
            Console.WriteLine($"=> Cleaned: {uniquePlaces.Count}");

            Console.ReadLine();
        }
    }
}
