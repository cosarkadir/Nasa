using System;
using System.Linq;

namespace Nasa.MarsRover
{
    /// <summary>
    /// Komutlara göre robotun hareketini sağlayan sınıf
    /// </summary>
    public class MarsRoverAction
    {
        private readonly string _marsPlateau;
        private readonly string _robot1Position;
        private readonly string _robot1Command;
        private readonly string _robot2Position;
        private readonly string _robot2Command;

        /// <summary>
        /// Robot hareketlerini sağlayan metod
        /// </summary>
        /// <param name="marsPlateau">Mars yüzeyi input değeri</param>
        /// <param name="robot1Position">Robot1'in X koordinatı input değeri</param>
        /// <param name="robot1Command">Robot1'nin komutları</param>
        /// <param name="robot2Position">Robot2'in Y koordinatı input değeri</param>
        /// <param name="robot2Command">Robot2'nin komutları</param>
        public MarsRoverAction(string marsPlateau, string robot1Position, string robot1Command, string robot2Position, string robot2Command)
        {
            _marsPlateau = marsPlateau; 
            _robot1Position = robot1Position;
            _robot1Command = robot1Command;
            _robot2Position = robot2Position;
            _robot2Command = robot2Command;
        }

        public string Action()
        {
            CheckInput();
            ActionInputModel input = CheckInputValues();

            Invoker invoker = new Invoker(input.MarsPlateauX, input.MarsPlateauY);
            Robot robot1 = new Robot(input.Robot1PositionX, input.Robot1PositionY, input.Robot1Direction);
            foreach (char command in _robot1Command.ToCharArray())
            {
                IRobotCommand robotCommand = RobotCommandFactory.CreateRobotCommand(command, robot1);
                invoker.AddCommand(robotCommand);
            }

            Robot robot2 = new Robot(input.Robot2PositionX, input.Robot2PositionY, input.Robot2Direction);
            foreach (char command in _robot2Command.ToCharArray())
            {
                IRobotCommand robotCommand = RobotCommandFactory.CreateRobotCommand(command, robot2);
                invoker.AddCommand(robotCommand);
            }

            invoker.ExecuteAll();

            return $"{robot1.X} {robot1.Y} {robot1.Direction}{Environment.NewLine}{robot2.X} {robot2.Y} {robot2.Direction}";
        }

        /// <summary>
        /// Input zorunlu alan kontrollerini yapar.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void CheckInput()
        {
            if (string.IsNullOrEmpty(_marsPlateau))
            {
                throw new ArgumentException("Mars yüzeyi input değeri boş olamaz!");
            }
            if (string.IsNullOrEmpty(_robot1Position))
            {
                throw new ArgumentException("Robot1'in posizyon bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(_robot1Command))
            {
                throw new ArgumentException("Robot1'in komut bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(_robot2Position))
            {
                throw new ArgumentException("Robot2'in pozisyon bilgileri boş olamaz!");
            }
            if (string.IsNullOrEmpty(_robot2Command))
            {
                throw new ArgumentException("Robot2'in komut bilgileri boş olamaz!");
            }
        }

        /// <summary>
        /// Input değerlerini kontrol eder
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private ActionInputModel CheckInputValues()
        {
            string[] marsPlateauArray = _marsPlateau.Split(' ');
            string[] robot1PositionArray = _robot1Position.Split(' ');
            string[] robot2PositionArray = _robot2Position.Split(' ');

            //Mars yüzeyi input değerleri kontrolü
            //X ve Y koordinatları olmak üzere 2 integer değer olmalı. Aralarında 1 boşluk olmalı.
            if (marsPlateauArray.Length != 2 || !int.TryParse(marsPlateauArray[0], out int marsPlateauX) || !int.TryParse(marsPlateauArray[1], out int marsPlateauY))
            {
                throw new ArgumentException("Mars yüzeyi input değerleri hatalı!");
            }
            if (robot1PositionArray.Length != 3 || !int.TryParse(robot1PositionArray[0], out int robot1PositionX) || !int.TryParse(robot1PositionArray[1], out int robot1PositionY) || !Enum.IsDefined(typeof(Direction), robot1PositionArray[2])
                )
            {
                throw new ArgumentException("Robot1 pozisyon input değerleri hatalı!");
            }
            if (robot2PositionArray.Length != 3 || !int.TryParse(robot2PositionArray[0], out int robot2PositionX) || !int.TryParse(robot2PositionArray[1], out int robot2PositionY) || !Enum.IsDefined(typeof(Direction), robot2PositionArray[2]))
            {
                throw new ArgumentException("Robot2 pozisyon input değerleri hatalı!");
            }
            if (_robot1Command.Any(x => x.ToString() != RobotAct.L.ToString() && x.ToString() != RobotAct.R.ToString() && x.ToString() != RobotAct.M.ToString()))
            {
                throw new ArgumentException("Robot1 komut değerleri hatalı!");
            }
            if (_robot2Command.Any(x => x.ToString() != RobotAct.L.ToString() && x.ToString() != RobotAct.R.ToString() && x.ToString() != RobotAct.M.ToString()))
            {
                throw new ArgumentException("Robot2 komut değerleri hatalı!");
            }

            ActionInputModel response = new ActionInputModel
            {
                MarsPlateauX = marsPlateauX,
                MarsPlateauY = marsPlateauY,
                Robot1PositionX = robot1PositionX,
                Robot1PositionY = robot1PositionY,
                Robot2PositionX = robot2PositionX,
                Robot2PositionY = robot2PositionY,
                Robot1Direction = (Direction)Enum.Parse(typeof(Direction), robot1PositionArray[2]),
                Robot2Direction = (Direction)Enum.Parse(typeof(Direction), robot2PositionArray[2])
            };

            return response;

        }
    }
}
