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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PrivateFontCollection collection = new PrivateFontCollection();
            string pathToResource = System.Configuration.ConfigurationSettings.AppSettings["PathToCompilerResources"];
            collection.AddFontFile(@"" + pathToResource + @"\PokemonGB.ttf");
            label1.Font = new Font((FontFamily)collection.Families[0], 12);
            label2.Font = new Font((FontFamily)collection.Families[0], 12);
            label3.Font = new Font((FontFamily)collection.Families[0], 12);          
            button1.Font = new Font((FontFamily)collection.Families[0], 12);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
