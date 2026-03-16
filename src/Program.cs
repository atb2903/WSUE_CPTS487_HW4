class Program
{
    static List<Zombie.ZombieComponent> zombies = new List<Zombie.ZombieComponent>();
    static Zombie.ZombieSpawner spawner = new Zombie.ZombieSpawner();

    static void Main(string[] args)
    {
        Console.WriteLine("PvZ Zombie Builder-Composite Demo");
        Console.WriteLine();
        bool executing = true;

        while(executing)
        {
            Console.WriteLine("1. Create Zombies");
            Console.WriteLine("2. Simulate Game");
            Console.WriteLine("3. Reset");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Current Zombies: " + BuildZombieString());
            Console.Write("Select an option: ");
            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine("Select Zombie Type:");
                    Console.WriteLine("1. Regular");
                    Console.WriteLine("2. Cone");
                    Console.WriteLine("3. Bucket");
                    Console.WriteLine("4. Screen Door");
                    Console.Write("Select a type: ");
                    string? typeInput = Console.ReadLine();
                    Zombie.ZombieType type;
                    switch(typeInput)
                    {
                        case "1":
                            type = Zombie.ZombieType.Regular;
                            break;
                        case "2":
                            type = Zombie.ZombieType.Cone;
                            break;
                        case "3":
                            type = Zombie.ZombieType.Bucket;
                            break;
                        case "4":
                            type = Zombie.ZombieType.ScreenDoor;
                            break;
                        default:
                            Console.WriteLine("Invalid type. Defaulting to Regular.");
                            type = Zombie.ZombieType.Regular;
                            break;
                    }
                    zombies.Add(spawner.SpawnZombie(type));
                    break;
                case "2":
                    bool simulating = true;
                    int round = 0;
                    while(simulating)
                    {
                        Console.WriteLine("Round " + round + ": " + BuildZombieString());
                        Shoot(25);
                        round++;
                        if(LivingZombieCount() == 0)
                        {
                            simulating = false;
                        }
                    }
                    Console.WriteLine("Round " + round + ": " + BuildZombieString());
                    zombies.Clear(); // remove the dead zombies to reset for next simulation
                    break;
                case "3":
                    zombies.Clear();
                    Console.WriteLine("Zombies reset.");
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    executing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Exeuction finished. Press any key to exit.");
        Console.ReadKey();
    }

    private static string BuildZombieString()
    {
        string result = "[";
        foreach(Zombie.ZombieComponent zombie in zombies)
        {
            if(zombie.IsAlive())
            {
                switch(zombie.GetZombieType())
                {
                    case Zombie.ZombieType.Regular:
                        result += "R";
                        break;
                    case Zombie.ZombieType.Cone:
                        result += "C";
                        break;
                    case Zombie.ZombieType.Bucket:
                        result += "B";
                        break;
                    case Zombie.ZombieType.ScreenDoor:
                        result += "S";
                        break;
                }
                result += "/";
                result += zombie.GetHealth().ToString();
                if(zombie != zombies.Last())
                {
                    result += ", ";
                }
            }
        }
        result += "]";
        return result;
    }

    private static int LivingZombieCount()
    {
        int count = 0;
        foreach(Zombie.ZombieComponent zombie in zombies)
        {
            if(zombie.IsAlive())
            {
                count++;
            }
        }
        return count;
    }

    private static void Shoot(int damage)
    {
        foreach(Zombie.ZombieComponent zombie in zombies)
        {
            if(zombie.IsAlive())
            {
                zombie.TakeDamage(damage);
                return; // Shoot one zombie at a time
            }
        }
    }
}