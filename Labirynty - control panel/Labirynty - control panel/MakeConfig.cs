using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Labirynty___control_panel
{
	class MakeConfig
	{
		public string[] ConfigString { get; set; }
		public Button button;
		
		
		public string RandomId(int signsNumber)
		{
			int random;
			char[] randomSigns = new char[signsNumber];
			Random rnd = new Random();
			for (int i = 0; i < signsNumber; i++)
			{
				random = rnd.Next(35) + 65;
				if (random > 90) random -= 42;
				randomSigns[i] = Convert.ToChar(random);  //48 + 10
			}

			return new String(randomSigns);
		}
		private void RunMaze()
		{
			Process labProc = new Process();
			labProc.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "/labFinalBeta/labFinalBeta.exe";
			labProc.EnableRaisingEvents = true;
			labProc.Exited += new EventHandler(labProc_Exited);
			labProc.Start();
			
		}

		private void labProc_Exited(object sender, EventArgs e)
		{
			//MessageBox.Show("Próba " + ConfigString[2].ToString() + " ukończona.","Labirynt", MessageBoxButtons.OK, MessageBoxIcon.Information);
			button.Enabled = true;
		}
		
		

		public void SaveConfig()
		{
			System.IO.File.WriteAllLines(Path.GetDirectoryName(Application.ExecutablePath)+"/labFinalBeta/maze_config.txt", ConfigString);
			RunMaze();
		}
		
	}
}
