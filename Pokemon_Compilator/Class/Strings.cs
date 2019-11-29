using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Compilator.Class
{
    public class Strings
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Double Attack { get; set; }
        public Double Health { get; set; }
        public string TypePocket { get; set; }

        public Strings(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Attack = 1.00;
            this.Health = 1.00;
            this.TypePocket = "normal";
        }

        public Strings(string name, string value, string typo)
        {
            this.Name = name;
            this.Value = value;
            this.Attack = 1.00;
            this.Health = 1.00;
            this.TypePocket = typo;
        }

        public Strings(string name, string value, double attack, double health, string typePocket)
        {
            Name = name;
            Value = value;
            Attack = attack;
            Health = health;
            TypePocket = typePocket;
        }

        public Strings()
        {
        }

        public override string ToString()
        {
            return "Name: "+Name+", Value: "+Value+", Attack: "+Attack+", Health: "+Health+", TypePocket: "+TypePocket;
        }

    }
}
