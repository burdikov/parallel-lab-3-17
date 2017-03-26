using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prlel_lab_3_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var worker = new BackgroundWorker(); // Создаём воркера для считывания
            worker.DoWork += CallFileRead; // экземпляров из файла с помощью метода
            worker.RunWorkerAsync(); // из класса Algorythm
        }

        // метод, вызываемый в воркере
        private void CallFileRead(object sender, DoWorkEventArgs e)
        {
            toolStripStatusLabel1.Text = "Экземпляры загружаются...";
            try
            {
                int x = Algorythm.ReadInstancesFromFile(textBox1.Text);
                toolStripStatusLabel1.Text = "Экземпляров: " + x;
            }
            catch (Exception ee)
            {
                toolStripStatusLabel1.Text = "Экземпляры не загружены.";
                MessageBox.Show(ee.ToString());
            }
        }
    }
}
