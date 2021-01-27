using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class Customer
    {
        public string FirstName;
        public string LastName;
        private DateTime _Birthday;
        private bool _IsQualified;
        public string Address;
        public string Description;

        private Cat _MyCat;
        public Cat MyCat
        {
            get { return _MyCat;  }
        }

        public bool Adopt(Cat cat)
        {
            if (_IsQualified)
            {
                _MyCat = cat;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Dog _MyDog;
        public Dog MyDog
        {
            get { return _MyDog; }
        }

        public bool Adopt(Dog dog)
        {
            if (_IsQualified)
            {
                _MyDog = dog;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer(string firstName, string lastName, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this._Birthday = birthday;
            this._IsQualified = DateTime.Now.Year - birthday.Year >= 18;
        }

        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
                _IsQualified = DateTime.Now.Year - value.Year >= 18;
            }
        }

        public int Age
        {
            get { return DateTime.Now.Year - _Birthday.Year; }
        }

        public bool IsQualified
        {
            get { return _IsQualified; }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
