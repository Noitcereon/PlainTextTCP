using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class Car
    {
        public String Model { get; set; }
        public String Color { get; set; }
        public String RegistrationNumber { get; set; }

        public Car(String model, String color, String registrationNumber)
        {
            Model = model;
            Color = color;
            RegistrationNumber = registrationNumber;
        }
        public Car() { }

        public override string ToString()
        {
            return $"{Model}, {Color}, {RegistrationNumber}";
        }
    }
}
