using Pokemon_Compilator.Compilers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_Compilator
{
	public partial class Form1 : Form
	{
        Compiler print;

		public Form1()
		{
			InitializeComponent();
            
		}

        public bool inputNotOK = false;

        Thread thread;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PrivateFontCollection collection = new PrivateFontCollection();
            string pathToResource = System.Configuration.ConfigurationSettings.AppSettings["PathToCompilerResources"];
            collection.AddFontFile(@"" + pathToResource + @"\PokemonGB.ttf");
            label1.Font = new Font((FontFamily)collection.Families[0], 12);
            label2.Font = new Font((FontFamily)collection.Families[0], 12);
            label3.Font = new Font((FontFamily)collection.Families[0], 10);
            label4.Font = new Font((FontFamily)collection.Families[0], 10);
            menuStrip1.Font = new Font((FontFamily)collection.Families[0], 8);
            nowyToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            otwórzToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            zapiszToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            zapiszJakoToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            zamknijToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            cofnijToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            powtórzToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            wytnijToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            kopiujToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            wklejToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            zaznaczWszystkoToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            dataIGodzinaToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            oProgramieToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            codingHelpToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);
            kompilacjaToolStripMenuItem.Font = new Font((FontFamily)collection.Families[0], 8);

            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)  
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                treeView1.Nodes.Add(node);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                  
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                          
                            node.Tag = dir;

                   
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
               
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Clear();
            richTextBox2.Clear();
            this.Text = "New pika file";
		}

		private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Pika Document(*.pika)|*.pika|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                richTextBox2.Clear();
            }
			this.Text = op.FileName;
		}

		private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog op = new SaveFileDialog();
			op.Filter = "Pika Document(*.pika)|*.pika";
			if (op.ShowDialog() == DialogResult.OK)
				richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
			this.Text = op.FileName;
		}

		private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog op = new SaveFileDialog();
			op.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
			if (op.ShowDialog() == DialogResult.OK)
				richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
			this.Text = op.FileName;
		}

		private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}

		private void powtórzToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Redo();
		}

		private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Cut();
		}

		private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}

		private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}

		private void zaznaczWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}

		private void dataIGodzinaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = System.DateTime.Now.ToString();
		}

		private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
		{
            thread = new Thread(about);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void about(object obj)
        {
            Application.Run(new About());
        }

        private void helper(object obj)
        {
            Application.Run(new Helper());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			int index = richTextBox1.Text.Length;
			int line = richTextBox1.GetLineFromCharIndex(index)+1;
			int firstChar = richTextBox1.GetFirstCharIndexFromLine(line);
			int column = index - firstChar;
			label1.Text = "Line: " + line + " Go Go More!";
            AddLineNumbers();
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void kompilacjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Text.Split('$');
            richTextBox2.Clear();
            richTextBox2.Text = "Poki Compiler v.1.0 - Compiling start...\n";
            print = new Compiler(this);
            interaction(lines);
            
        }

        private void interaction(string[] l)
        {
            if (l[0] == "")
            {
                richTextBox2.Text += "Error. Compiling failed. Empty file.";
            }
            else
            {
                foreach (string line in l)
                {
                    string output = print.compile(line);
                    string[] checkError = output.Split('$');                 
                    richTextBox2.Text += "\n" + output;
                    if (checkError[0].Equals("Error")) break;
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox2.Focus();
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
          
        }

        private void codingHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thread = new Thread(helper);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public void buttonEnterOK_Click(object sender, EventArgs e)
        {
            inputNotOK = true;
        }

        public void AddLineNumbers()
        {
            Point pt = new Point(0, 0);
            int First_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox1.GetLineFromCharIndex(First_Index);
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int Last_Index = richTextBox1.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox1.GetLineFromCharIndex(Last_Index);
            richLine.SelectionAlignment = HorizontalAlignment.Center;
            richLine.Text = "";
            for (int i = First_Line; i <= Last_Line; i++)
            {
                richLine.Text += i + 1 + "\n";
            }
        }

        public string getValueInput()
        {
            return textEnterValue.Text;
        }

        public void showInput()
        {
            panelEnter.Visible = true;
        }

        public void closeInput()
        {
            panelEnter.Visible = false;
            textEnterValue.Text = "";
        }
    }
}
