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
                return Average switch
                {
                    >= 95 => "Znakomity mentor",
                    >= 80 => "Dobry lider",
                    >= 60 => "Kierownik do poprawy",
                    _ => "Niedostateczny DO ZWOLNIENIA :-("
                };
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
                return Average switch
                {
                    >= 95 => ConsoleColor.DarkGreen,
                    >= 80 => ConsoleColor.Green,
                    >= 60 => ConsoleColor.Yellow,
                    _ => ConsoleColor.Red
                };
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
