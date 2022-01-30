using System;

namespace HbCaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string firstPosition = "1 2 N";
            string moves = "LMLMLMLMM";
            Direct(firstPosition, moves);

            string firstPosition2 = "3 3 E";
            string moves2 = "MMRMMRMRRM";

            Direct(firstPosition2, moves2);
            Console.ReadLine();
        }

        private static void Direct(string firstPosition, string moves)
        {
            RoverPosition roverPosition = new RoverPosition();
            firstPosition = firstPosition.Replace(" ", "");

            setRoverPosition(roverPosition, firstPosition);

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].ToString() == "L")
                {
                    ToLeft(roverPosition);
                }
                if (moves[i].ToString() == "R")
                {
                    ToRight(roverPosition);
                }
                if (moves[i].ToString() == "M")
                {
                    Goforward(roverPosition);
                }
            }

            Console.Write(roverPosition.X + " ");
            Console.Write(roverPosition.Y + " ");
            Console.Write(Enum.GetName(typeof(DirectEnum), roverPosition.Compass) + Environment.NewLine);
        }

        // c# ın mod için operatoru tam çalışmıyor onun yerine internetden aşağıdaki çözümü aldım(negative sayılar için doğru sonuç vermiyor.)
        private static void ToLeft(RoverPosition roverPosition)
        {
            roverPosition.Compass--;
            //roverPosition.Compass = roverPosition.Compass % 4;
            roverPosition.Compass = (roverPosition.Compass % 4 + 4) % 4;
        }
        private static void ToRight(RoverPosition roverPosition)
        {
            roverPosition.Compass++;
            roverPosition.Compass = roverPosition.Compass % 4;
        }
        private static void Goforward(RoverPosition roverPosition)
        {
            if (roverPosition.Compass.ToString() == "0")
            {
                roverPosition.Y++;
            }
            if (roverPosition.Compass.ToString() == "2")
            {
                roverPosition.Y--;
            }
            if (roverPosition.Compass.ToString() == "1")
            {
                roverPosition.X++;
            }
            if (roverPosition.Compass.ToString() == "3")
            {
                roverPosition.X--;
            }
        }

        // burda rover ın ilk durduğu yerin objeye ataması yapıldı.
        private static void setRoverPosition(RoverPosition roverPosition, string firstPosition)
        {
            if (firstPosition.Length < 3)
            {
                //hataver
            }

            roverPosition.X = (int)Char.GetNumericValue(firstPosition[0]);
            roverPosition.Y = (int)Char.GetNumericValue(firstPosition[1]);

            if (firstPosition[2].ToString() == "N")
            {
                roverPosition.Compass = 0;
            }
            else if (firstPosition[2].ToString() == "E")
            {
                roverPosition.Compass = 1;
            }
            else if (firstPosition[2].ToString() == "S")
            {
                roverPosition.Compass = 2;
            }
            else if (firstPosition[2].ToString() == "W")
            {
                roverPosition.Compass = 3;
            }
            else
            {
                //hataver
            }
        }
    }

    public class RoverPosition
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Compass { get; set; }
    }

    public enum DirectEnum
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }
}
