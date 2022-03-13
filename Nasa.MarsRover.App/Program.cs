using System;

namespace Nasa.MarsRover.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Mars Yüzey Bilgisini Girin(Örn: 5 5): ");
                string marsPlateau = Console.ReadLine();
                Console.Write("Robot 1 Pozisyon Bilgisini Girin(Örn: 1 2 N): ");
                string robot1Position = Console.ReadLine();
                Console.Write("Robot 1 Komutlarını Bilgisini Girin(Örn: LMLMLMLMM): ");
                string robot1Command = Console.ReadLine();
                Console.Write("Robot 2 Pozisyon Bilgisini Girin(Örn: 3 3 E): ");
                string robot2Position = Console.ReadLine();
                Console.Write("Robot 2 Komutlarını Bilgisini Girin(Örn: MMRMMRMRRM): ");
                string robot2Command = Console.ReadLine();

                MarsRoverAction action = new MarsRoverAction(marsPlateau, robot1Position, robot1Command, robot2Position, robot2Command);
                string result = action.Action();
                Console.WriteLine(string.Format("Output: {0}{1}", Environment.NewLine , result));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(string.Format("Girilen Parametreleri Kontrol Ediniz: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Hata: {0}", ex.Message));
            }

            Console.ReadKey();  
        }
    }
}
