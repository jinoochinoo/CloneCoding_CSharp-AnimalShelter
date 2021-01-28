using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    class Pet
    {
        public int PetId;
        public string Name;
        public string Color;
        public string Gender;
        public string Description;

        public Pet(int petId, string name, string color, string gender)
        {
            this.PetId = petId;
            this.Name = name;
            this.Color = color;
            this.Gender = gender;
        }

        public virtual string MakeSound()
        {
            return "";
        }
    }
}
