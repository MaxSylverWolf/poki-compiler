using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Compilator
{
    public partial class Keyboard : Form
    {
        public Keyboard()
        {
            InitializeComponent();
            PrivateFontCollection collection = new PrivateFontCollection();
            string pathToResource = System.Configuration.ConfigurationSettings.AppSettings["PathToCompilerResources"];
            collection.AddFontFile(@"" + pathToResource + @"\PokemonGB.ttf");
            label1.Font = new Font((FontFamily)collection.Families[0], 10);
            button1.Font = new Font((FontFamily)collection.Families[0], 8);
            button2.Font = new Font((FontFamily)collection.Families[0], 8);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
