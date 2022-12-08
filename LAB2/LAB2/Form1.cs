using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Security.Cryptography;

namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Size size;
            string fileName,str;
            int size1,size2;
            float dx, dy;
            string name = null;
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files (*.BMP;*.JPG;*.GIF,*.TIF;*.PNG;*.PCX)|*.BMP;*.JPG;*.GIF,*.TIF;*.PNG;*.PCX|All files (*.*)|*.*";
            DialogResult result = of.ShowDialog();
            int i = 0, j = 0;
           if (result == DialogResult.OK){
                string file = of.FileName;
                try{
                    Image image1 = Image.FromFile(file);
                    FileInfo inf = new FileInfo(file);
                    size1 = image1.Height;
                    size2 = image1.Width;   
                    fileName = Path.GetFileName(file);
                    dx = image1.HorizontalResolution;
                    dy = image1.VerticalResolution;
                    str = image1.PixelFormat.ToString();
                    int depth = Int32.Parse(Regex.Match(str, @"\d+").Value);
                    Console.WriteLine(inf.Length/1000);
                    string[] data = { fileName, size1.ToString()+"x"+size2.ToString(),dx.ToString(),depth.ToString()};
                    dataGridView1.Rows.Add(data);
                }
                catch (IOException){
                }
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
