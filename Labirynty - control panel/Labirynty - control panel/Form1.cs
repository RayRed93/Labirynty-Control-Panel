using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Labirynty___control_panel
{
	public partial class Form1 : Form
	{
		MakeConfig mc = new MakeConfig();
		string savePath = Path.GetDirectoryName(Application.ExecutablePath)+@"\Logs"; //TODO
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(comboBox1.Text) && !String.IsNullOrEmpty(comboBox2.Text) && !String.IsNullOrEmpty(savePath))
			{	
			    mc.ConfigString = new String[6];
				mc.ConfigString[0] = textBox1.Text;
				mc.ConfigString[1] = comboBox1.Text; //(string)comboBox1.SelectedValue;
				mc.ConfigString[2] = comboBox2.Text;
				mc.ConfigString[3] = radioButton1.Checked.ToString();
				mc.ConfigString[4] = savePath;
				mc.ConfigString[5] = numericUpDown1.Value.ToString();
				mc.SaveConfig();
				button1.Enabled = false;
				mc.button = button1;

			}
			 
			else MessageBox.Show("Uzupełnij wszystkie pola.","Labirynt",MessageBoxButtons.OK,MessageBoxIcon.Warning);

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			radioButton2.Checked = !radioButton1.Checked;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			radioButton1.Checked = !radioButton2.Checked;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();
			if(result == DialogResult.OK) savePath = fbd.SelectedPath;

		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Text = mc.RandomId(7);
		}
	}
}
