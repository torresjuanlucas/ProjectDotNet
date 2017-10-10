using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class Employee
    {
        private string _name;
        private int _age;
        private double _height;

        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException("Name must be between 2 and 50 characters long");
                }
                _name = value;
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 1 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 150");
                }
                _age = value;
            }
        }
        public string AgeStr
        {
            set
            {
                int ageTemp;
                if (int.TryParse(value, out ageTemp))
                {
                    Age = ageTemp;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age must be an integer value");
                }
            }
        }


        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0.3 || value > 3)
                {
                    throw new ArgumentOutOfRangeException("Height must be between 0.3 and 3.0 meters");
                }
                _height = value;
            }
        }

        public override String ToString()
        {
            return String.Format("{0}: {1} is {2} y/o, {3:F2}m tall", Id, Name, Age, Height);
        }
    }
}
