using TotalWar;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("|  Battle simulator - TotalWar  |");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        while (true)
        {
            List<string> team1 = DefineTeam(1);
            List<string> team2 = DefineTeam(2);

            Battle battle = new Battle();

            int result = battle.SimulateBattle(team1, team2);

            if (result == 1)
            {
                Console.WriteLine("Победила первая команда");
            }
            else if (result == 2)
            {
                Console.WriteLine("Победила вторая команда");
            }
            else
            {
                Console.WriteLine("Error");
            }

            Console.Write("Продолжить (y/n): ");

            var answer = Console.ReadLine();

            if(answer != "y")
            {
                break;
            }
        }
    }

    private static List<string> DefineTeam(int teamNumber)
    {
        int count;

        while (true)
        {
            Console.Write("Введите количество персонажей " + (teamNumber == 1 ? "первой" : "второй") + " команды: ");

            var answer = Console.ReadLine();

            if (answer != null && int.TryParse(answer, out count))
            {
                break;
            }
        }

        List<string> team = new List<string>();

        for (int i = 0; i < count; i++)
        {
            while (true)
            {
                Console.Write("Введите тип персонажа команды (Elf, Gnome): ");
                var answer = Console.ReadLine();

                if (answer == "Elf" || answer == "Gnome")
                {
                    team.Add(answer);
                    break;
                }
            }
        }

        return team;
    }
}