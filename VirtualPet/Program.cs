using System;

class VirtualPet
{
    public string PetName { get; private set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public bool NeedsBathroom { get; private set; }
    public int Age { get; private set; }  // what is the point of this value??

    public VirtualPet(string petName = "Pikachu", int hunger = 50, int happiness = 50, bool needsBathroom = false, int age = 30)
    {
        PetName = petName;
        Hunger = hunger;
        Happiness = happiness;
        NeedsBathroom = needsBathroom;
        Age = age;
    }

    public void FeedPet()
    {
        Console.WriteLine($"{PetName} er mett og fornøyd");
        Hunger -= 10;
    }

    public void CuddlePet()
    {
        Console.WriteLine($"{PetName} smiler");
        Happiness += 10;
    }

    public void DoBathroomCheck()
    {
        Console.WriteLine($"Sjekker om {PetName} må på do.");
        CheckBathroom();

        if ( NeedsBathroom )
        {
            Console.WriteLine($"{PetName} må på do.");
            Hunger = 50;
            NeedsBathroom = false;
        }
        else
        {
            Console.WriteLine($"{PetName} må ikke på do.");
        }
    }

    public void CheckBathroom()
    {
        NeedsBathroom = false;

        if (Hunger < 40)
        {
            NeedsBathroom = true;
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
            Console.WriteLine($"1. Gi {chosenPet.PetName} mat");
            Console.WriteLine($"2. Kos med {chosenPet.PetName}");
            Console.WriteLine($"3. Sjekk om {chosenPet.PetName} må på do");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch ( choice )
            {
                case "1":
                    chosenPet.FeedPet();
                    break;
                case "2":
                    chosenPet.CuddlePet();
                    break;
                case "3":
                    chosenPet.DoBathroomCheck();
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