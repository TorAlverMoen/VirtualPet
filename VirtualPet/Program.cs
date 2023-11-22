using System;

class VirtualPet
{
    public string petName { get; private set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public bool needsBathroom { get; private set; }
    public int age { get; private set; }  // what is the point of this value??

    public VirtualPet(string petName = "Pikachu", int hunger = 50, int happiness = 50, bool needsBathroom = false, int age = 30)
    {
        this.petName = petName;
        Hunger = hunger;
        Happiness = happiness;
        this.needsBathroom = needsBathroom;
        this.age = age;
    }

    public void feedPet()
    {
        Console.WriteLine($"{petName} er mett og fornøyd");
        Hunger -= 10;
    }

    public void cuddlePet()
    {
        Console.WriteLine($"{petName} smiler");
        Happiness += 10;
    }

    public void doBathroomCheck()
    {
        Console.WriteLine($"Sjekker om {petName} må på do.");
        checkBathroom();

        if ( needsBathroom )
        {
            Console.WriteLine($"{petName} må på do.");
            Hunger = 50;
            needsBathroom = false;
        }
        else
        {
            Console.WriteLine($"{petName} må ikke på do.");
        }
    }

    public void checkBathroom()
    {
        needsBathroom = false;

        if (Hunger < 40)
        {
            needsBathroom = true;
        }
    }
}

class Program
{
    static void Main()
    {
        bool exitApp = false;

        Console.WriteLine("Skriv inn navn på vesenet?");
        string newPet = Console.ReadLine();

        VirtualPet chosenPet = new VirtualPet(newPet);

        while (!exitApp)
        {
            Console.WriteLine($"1. Gi {chosenPet.petName} mat");
            Console.WriteLine($"2. Kos med {chosenPet.petName}");
            Console.WriteLine($"3. Sjekk om {chosenPet.petName} må på do");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    chosenPet.feedPet();
                    break;
                case "2":
                    chosenPet.cuddlePet();
                    break;
                case "3":
                    chosenPet.doBathroomCheck();
                    break;
                case "4":
                    exitApp = true;
                    break;
                default:
                    Console.WriteLine("Syntax error");
                    break;
            }
        }

    }
}