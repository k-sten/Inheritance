using System;
using System.Collections.Generic;

namespace InheritanceNA20
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class2 c3 = new Class3
            //{
            //    Name = "Kalle",
            //    Age = 45,
            //    Adress = "Blåbärsvägen 3"
            //};

            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new FuelVehicle("ABC123", 100),
                new FuelCar("AAA000", 150){FuelLevel = 100},
                new Moped("BBB111"),
                new Vehicle("CCC222")
            };

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Drive(1));

                Moped moped3 = vehicle as Moped;
                Console.WriteLine(moped3?.DoSound());

                if (vehicle is Moped moped2)
                {
                    Console.WriteLine(moped2.DoSound());
                    Moped moped = (Moped)vehicle;
                    Console.WriteLine(moped.DoSound());
                }
            }



            

            Console.ReadLine();
        }
    }
}