using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceNA20
{
    public interface IDrive
    {
        public string Drive(double distance);
    }
    abstract class AbstractVehicle : IDrive
    {
        public virtual string Drive(double distance) => $"Vehicle wants to drive for {distance}";
        public abstract string Turn();
    }

    class Bicycle : AbstractVehicle
    {
        public string FrameNumber { get; }
        public Bicycle(string frmenumber)
        {
            FrameNumber = frmenumber;
        }

        public override string Turn()
        {
            return "Bicycle turns";
        }
    }

    class Vehicle:AbstractVehicle
    {
        public string RegNo { get; set; }

        public Vehicle(string RegNo)
        {
            this.RegNo = RegNo;
        }

        public override string Turn()
        {
            return "Vehicle turns";
        }

        //public virtual string Drive(double distance) =>
        //    distance > 0 ? $"Vehicle wants to drive for {distance}" : "Negative distance is assumed to be 0";
    }

    class Moped:Vehicle
    {
        public Moped(string regNo) : base(regNo)
        {
        }

        public string DoSound() => "Burnnnnnn";

        public override string Drive(double distance)
        {
            return $"Moped starts for {distance}";
        }
    }

    class FuelVehicle : Vehicle
    {


        private double fuelLevel;
        public double FuelCapacity { get; }

        public double FuelLevel
        {
            get
            {
                return fuelLevel;
            }
            set
            {
                double newLevel = Math.Max(0, value);
                fuelLevel = Math.Min(newLevel, FuelCapacity);
            }
        }
        public FuelVehicle(string regNo, double fuelCapacity) : this(regNo)
        {
            FuelCapacity = fuelCapacity;
        }

        public FuelVehicle(string regNo) : base(regNo)
        {

        }

        public new string Turn()
        {
            return "Vehicle turns";
        }

    }

    class FuelCar : FuelVehicle
    {
        private const double fuelConsumption = 0.5;
        private double maxDistance => FuelLevel / fuelConsumption;

        public double Milage { get; private set; }

        public FuelCar(string regNo, double fuelCapacity) : base(regNo, fuelCapacity)
        { }

        public override string Drive(double distance)
        {
            var result = new StringBuilder();
            result.AppendLine(base.Drive(distance));

            if (distance < 0)
            {
                distance = 0;
                result.AppendLine($"Negative distance is assumed to be 0");
            }

            FuelLevel -= distance * fuelConsumption;

            result.AppendLine($"RegNo {RegNo} drove {distance} km");

            return result.ToString();
            //return base.Drive(distance);
        }


    }
}