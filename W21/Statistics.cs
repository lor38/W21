using System;

namespace W21
{
    public class Statistics
    {
        public float Average { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public char AverageLetter { get; set; }
        public bool IsSupervisor { get; set; }

        public string GetDescription()
        {
            if (IsSupervisor)
            {
                if (Average >= 95) return "Znakomity mentor";
                if (Average >= 80) return "Dobry lider";
                if (Average >= 60) return "Kierownik do poprawy";
                return "Niedostateczny DO ZWOLNIENIA :-(";
            }
            else
            {
                return AverageLetter switch
                {
                    'A' => "Wybitny",
                    'B' => "Bardzo dobry",
                    'C' => "Dobry",
                    'D' => "Dostateczny",
                    _ => "Niedostateczny DO ZWOLNIENIA :-("
                };
            }
        }

        public ConsoleColor GetDescriptionColor()
        {
            if (IsSupervisor)
            {
                if (Average >= 95) return ConsoleColor.DarkGreen;
                if (Average >= 80) return ConsoleColor.Green;
                if (Average >= 60) return ConsoleColor.Yellow;
                return ConsoleColor.Red;
            }
            else
            {
                return AverageLetter switch
                {
                    'A' => ConsoleColor.DarkGreen,
                    'B' => ConsoleColor.Green,
                    'C' => ConsoleColor.Yellow,
                    'D' => ConsoleColor.DarkYellow,
                    _ => ConsoleColor.Red
                };
            }
        }
    }
}
