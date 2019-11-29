using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Compilator
{
    public partial class Changelog : Form
    {
        public Changelog()
        {
            InitializeComponent();
            this.textChangelog.Text = @"Changelog
-----------------------------------------------------------
last update 27.01.2019 by SylverWolf DW
- added pokedex method with 
    * set
    * get
    * all
    * release all
    * release var
- added changelog
- added evolution method as function
- added battle go method as function start
- richtextbox solved problem
- add line numbers (not work so good now)
- added swift calculation with var
- added input
    * pokedex input show$
    * pokedex input hide$
    * pokedex input save variable
-----------------------------------------------------------
update 26.01.2019 by SylverWolf DW
- added pokedex method in part
- added print
    * print pocket var
    * print pocket text
- added go when (if) with <, <=, >, >=, !=, =
- added go attack var (or number)
- added pokeball varname varvalue
    * changed from swift
- added Helper
- GUI changes
-----------------------------------------------------------
update 25.01.2019 by SylverWolf DW
- added swift calculation
- added swift calculation with var initialize
-------------------------------
update 24.01.2019 by SylverWolf DW
- added swift in part
-----------------------------------------------------------
update 3.01.2019 by SylverWolf DW
- added Starter
- added Authors
- GUI changes
- panel changes
-----------------------------------------------------------
update 22.12.2018 by SylverWolf DW
- create project
- GUI
- panel with saving as file .pika, compile text, exit, copy, paste, etc.
-----------------------------------------------------------
";
        }
    }
}
