using System;

namespace Nasa.MarsRover
{
    public class RobotCommandFactory
    {
        public static IRobotCommand CreateRobotCommand(char command, Robot robot)
        {
            if (command.ToString() == RobotAct.L.ToString())
            {
                return new TurnLeftCommand(robot);
            }
            else if (command.ToString() == RobotAct.R.ToString())
            {
                return new TurnRightCommand(robot);
            }
            else if (command.ToString() == RobotAct.M.ToString())
            {
                return new TakeStepCommand(robot);
            }

            throw new ArgumentException();
        }
    }
}
