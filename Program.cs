using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;

namespace Cars_UsedCars
{
    public class Program
    {
        
            public static List<Car> carsForSale = new List<Car>() { new Car("Honda", "Civic", 2016, 19500), new Car("Toyota", "Avalon", 1996, 25750), new Car("Kia", "Sonata", 2020, 14225), new Used_Car("Chevrolet","Silverado", 1990, 1999, 250000), new Used_Car("Mercedes", "Benz", 2014, 21200, 35000), new Used_Car("Jaguar", "XJ8", 2021, 45666, 25000) };
            
        public static List<Car> carsSold = new List<Car>();

        public static int indexSelected { get; set; }
        static void Main(string[] args)
        {
            /*List<Car> carsForSale = new List<Car>();
            carsForSale.Add(new Car("Honda", "Civic", 2016, 19500));
            carsForSale.Add(new Car("Toyota", "Avalon", 1996, 25750));
            carsForSale.Add(new Car("Kia", "Sonata", 2020, 14225));
            carsForSale.Add(new Used_Car("Chevrolet", "Silverado", 1990, 1999, 250000));
            carsForSale.Add(new Used_Car("Mercedes", "Benz", 2014, 21200, 35000));
            carsForSale.Add(new Used_Car("Jaguar", "XJ8", 2021, 45666, 25000));*/
            
            //which method of adding cars to a list is better: in program or in main (adding one at a time)?

            bool goOn = true;

            Console.WriteLine("Welcome to \"Berger's\" Dealership.");

            while (goOn)
            {
                DisplayCarsForSale(carsForSale);
                while (true)
                {
                    Console.WriteLine("\nWhich car would you like to purchase? Please select by index:");

                    try
                    {
                        indexSelected = int.Parse(Console.ReadLine());

                        if (indexSelected < 0 || indexSelected > carsForSale.Count)
                        {
                            //throw new Exception("You must select an index within the display options panel:");//why does this line end my program with an exception error? I thought throwing a new exception would prevent program from exiting
                            Console.WriteLine("You must select an index within the display options panel:");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        //throw;//what does this "throw" do?
                        continue;
                    }
                }

                PurchaseCar(indexSelected);

                DisplayCarsForSale(carsForSale);

                if (!Continue())
                {
                    break;
                }

                else
                {
                    continue;//unnecessary
                }
            }

            
        }    
        
        public static void DisplayCarsForSale(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"\nID - {i}{cars[i].ToString()}");
            }
        }

        public static string DisplayCarInformation(Car c)
        {
            return $"\nCar information\n" + c.ToString();
        }

        //I dont have a use for RemoveCar function; instead, the PurchaseCar function is used in its place
        public static void RemoveCar(int index)
        {
            Console.WriteLine($"\n--------------------\n{carsForSale[index].Make.ToUpper()} successfully removed from list.\n--------------------\n");
            carsForSale.RemoveAt(index);
        }

        //must writeline to console before adding/removing from lists
        //add car purchased to "carsSold" list
        //car purchased is removed from "carsForSale" list
        public static void PurchaseCar(int index)
        {
            Console.WriteLine($"\n--------------------\n{carsForSale[index].Make.ToUpper()} purchased!!! Thank you for shopping with us today.\n--------------------\n");
            carsSold.Add(carsForSale[index]);
            carsForSale.RemoveAt(index);
        }

        //must writeline to console before adding/removing from lists
        //add returned car back to "carsForSale" list
        //removes returned car from "carSold" list
        public static void SellCar(int index)
        {
            Console.WriteLine($"{carsSold[index]} successfully sold back to dealership.");
            carsForSale.Add(carsSold[index]);
            carsSold.RemoveAt(index);
        }

        //asks user to contine; if no, break out of loop
        public static bool Continue()
        {
            Console.WriteLine("\nWould you like to view options again Y/N");

            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "Y" || input == "YES")
            {
                return true;
            }
            else if (input == "N" || input == "NO")
            {
                Console.WriteLine("\nExiting program. Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine($"\n\"{input}\" is an invalid command. Try again.");
                return Continue();
            }
        }
    }
    
}

/*What will the application do?
Display a set of at least 6 cars (at least 3 new and 3 used)
Let the user select one of the cars to purchase.
Print out details of the car they chose, remove it from the list, and print the whole list again.

Build Specifications
Create a class named Car(5 points) to store the data about a car. This class should contain:
Data members for car details
A string for the make
A string for the model
An int for the year
A decimal for the price
A no - arguments constructor that sets data members to default values(blanks or your choice)
A constructor with four arguments matching the order above
A ToString() method returning a formatted string with the car details.
Create a subclass of Car named UsedCar(3 points).UsedCar should contain:
Data member for used car details:
A double for mileage.
Constructor: Takes five arguments and calls the four - argument constructor for Car and saves the mileage argument
ToString: Returns a formatted string with the used car details
Create an instance of List < Car > that can hold instances of Car and any class derived from Car.Make this list a public static member of Car.
In your main, create at least three Car instances and at least three UsedCar instances and add these six instances to the list
Add a public static method to Car called ListCars that loops through the list and prints out each member and its index in the list. (Hint: Use a regular for loop, not a foreach loop so you  can print out the index.)
Add a public static method to Car called Remove which takes an integer parameter and removes the car whose index is that parameter
In your main, print out the list (by calling the ListCar method). Then ask the user which car they would like to buy, by number (the index of the car).
Print out the details for the chosen car. (Think about how to print out this information: You’ll access the item in the list by index, and call Console.WriteLine.)
Remove the chosen car from the list
List all the cars again

Hints:
Use the right access modifiers (public/private/protected)!
You can just use \t tab escape characters to line things up, or if you want to get fancier, look up text formatters. 

Extra Challenges:
Think about other methods which might be useful for your Car such as “BuyBack” where you can add a used car to the list. Implement them and modify your app to take advantage of them. 
Create an Admin mode which lets the user edit cars.
Provide search features:
View all cars of an entered make.
View all cars of an entered year.
View all cars of an entered price or less.
View only used cars or view only new cars.*/
