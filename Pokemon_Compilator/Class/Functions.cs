using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Compilator.Class
{
    public class Functions
    {
        public string Name { get; set; }
        public List<string> Instructions { get; set; }

        public Functions()
        {
        }

        public Functions(string name, List<string> instructions)
        {
            Name = name;
            Instructions = instructions;
        }

        public override string ToString()
        {
            string fun = "Name:" + Name+"\n";           
            foreach(string s in Instructions) fun += s+"\n";
            return fun;
        }
    }
}
