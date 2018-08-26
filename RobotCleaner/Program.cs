using System;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //First Input: the number of commands to be exceuted
            int numberOfCommands = 0;
            int.TryParse(Console.ReadLine(),out numberOfCommands);

            //Second Input: the initial coodinates of the robot
            int xCoodinate = 0, yCoodinate = 0;
            var coodinates = Console.ReadLine().Split(" ");

            int.TryParse(coodinates[0], out xCoodinate);
            int.TryParse(coodinates[1], out yCoodinate);

            //Third Input: the commands
            (string direction, int steps) GetCommand()
            {
                string direction;
                int steps;

                var commandInput = Console.ReadLine().Split(" ");
                direction = commandInput[0];
                int.TryParse(commandInput[1], out steps);

                return (direction, steps);
            }

            Console.ReadLine();

        }
    }
}
