using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_UsedCars
{
    public class Car
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        //public static List<Car> carsForSale = new List<Car>();


        public Car(string make, string model, int year, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Price = price;
        }

        public Car()
        {

        }

        public string CarInfoString(Car c)
        {
            string[] carInfo = new string[3];
            
            carInfo[0] = "\nPrinting Car Details";
            carInfo[1] = "---------------------------";
            carInfo[2] = $"Make: {c.Make} \nModel: {c.Model}\nYear: {c.Year}\nPrice: ${c.Price}";

            string info = string.Join("\n", carInfo);
            return info;

            /*return new string($"\nPrinting Car Details\n---------------\nMake: {c.Make,-10}, Model: {c.Model,-10}, Year: {c.Year,10}, Price: ${c.Price}");*/
        }

        public override string ToString()
        {
            return new string($"\nPrinting Car Details\nMake: {this.Make}\tModel: {this.Model}\tYear: {this.Year}\tPrice: ${this.Price}\n--------------------");
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
