using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sdsds.Models
{
    public class Character
    {
        public int Id {get; set;}

        public string Name {get; set;} = "Frodo";
        public int HitPoinst { get; set;} = 100;
        public int Strength {get; set;} = 10;
        public int Defense { get; set;} = 10;
        public int Intelligence {get; set;} = 10;



        public RpgClass Class {get; set;} = RpgClass.Knight;

        public Users? User {get; set;}


          public Character(int id, string name, int strength, int intelligence) 
        {
            this.Id = id;
            this.Name = name;
              this.Strength = strength;
             this.Intelligence = intelligence;
   
        }
 
        public Character() 
        {
            
              
        }


        
    }
}