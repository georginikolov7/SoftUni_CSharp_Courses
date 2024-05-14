using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Car
    {
		
		private string make	;
		private string model;
		private int hp;
		private string regNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make
		{
			get { return make; }
			set { make = value; }
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public int HorsePower
		{
			get { return hp; }
			set { hp = value; }
		}

		public string RegistrationNumber
		{
			get { return regNumber; }
			set { regNumber = value; }
		}
        public override string ToString()
        {
			StringBuilder sb = new();
			sb.AppendLine($"Make: {Make}");
			sb.AppendLine($"Model: {Model}");
			sb.AppendLine($"HorsePower: {HorsePower}");
            sb.AppendLine($"RegistrationNumber: {RegistrationNumber}");
            return sb.ToString().Trim();
        }
    }
}
