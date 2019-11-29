using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Compilator
{
    public partial class Starter : Form
    {
        Thread thread;


        public Starter()
        {
            InitializeComponent();
            
        }

        private void Start_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Interval = 1;
            timer1.Enabled = true;
            
            PrivateFontCollection collection = new PrivateFontCollection();
            string pathToResource = System.Configuration.ConfigurationSettings.AppSettings["PathToCompilerResources"];
            collection.AddFontFile(@""+pathToResource+@"\PokemonGB.ttf");
            label1.Font = new Font((FontFamily)collection.Families[0], 22);
            label2.Font = new Font((FontFamily)collection.Families[0], 18, FontStyle.Bold);
            button1.Font = new Font((FontFamily)collection.Families[0], 8);
            buttonChangeLog.Font = new Font((FontFamily)collection.Families[0], 8);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(compilerstart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void compilerstart(object obj)
        {
            Application.Run(new Form1());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void buttonChangeLog_Click(object sender, EventArgs e)
        {
            thread = new Thread(changelog);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void changelog(object obj)
        {
            Application.Run(new Changelog());
        }
    }
}
