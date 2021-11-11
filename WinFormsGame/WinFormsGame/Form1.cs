using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void klopButton_Click(object sender, EventArgs e)
        {
            if(CanGetPredition(AppDomain.CurrentDomain.BaseDirectory + "cdtfkl.xml"))
            {
                pictureBox1.ImageLocation = @"C:\Sveta\NIK\myGame\a.jpg";
                var prediction = LoadPredictionFromFile(AppDomain.CurrentDomain.BaseDirectory + "KlopPrediction.xml");
                label1.Text = prediction.TextOfPrediction;
            }
            else
            {
                MessageBox.Show("Только по одному предсказанию в день от каждого медиума. Забугривайся завтра!", "Важно!", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        bool CanGetPredition(string pathToFile)
        {
            var curentDateTime = DateTime.Now;

            if (!File.Exists(pathToFile))
            {
                File.WriteAllText(pathToFile, curentDateTime.ToString());
                return true;
            }
            var dateFromFile = DateTime.Parse(File.ReadAllText(pathToFile));
            return curentDateTime.Date != dateFromFile.Date;
        }

        private void kachinButton_Click(object sender, EventArgs e)
        {
            if (CanGetPredition(AppDomain.CurrentDomain.BaseDirectory + "cdtfka.xml"))
            {
                pictureBox1.ImageLocation = @"C:\Sveta\NIK\myGame\k.jpg";
                var prediction = LoadPredictionFromFile(AppDomain.CurrentDomain.BaseDirectory + "KachinPrediction.xml");
                label1.Text = prediction.TextOfPrediction;
            }
            else
            {
                MessageBox.Show("Только по одному предсказанию в день от каждого медиума. Давай заавтра ещё поболтаем!", "Важно!", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public static Prediction LoadPredictionFromFile (string pathToFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Prediction>), new XmlRootAttribute("Predictions"));
            FileStream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            var predictions = (List<Prediction>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            var random = new Random();
            var prediction = predictions[random.Next(predictions.Count)];
            return prediction;
        }
    }
}
