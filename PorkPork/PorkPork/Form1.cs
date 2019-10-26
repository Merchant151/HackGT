using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkPork
{
    public partial class Form1 : Form
    {

        static Task sm;

        public Form1()
        {
            InitializeComponent();

            Task.Factory.StartNew(() =>
            {
                WebServer.ServerMain.server();
            });
        }

        private void ForceSendImage (object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            String file;

            //Gets the filepath
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog.FileName;
            } else { return; }
            
            //Runs the API calls
            var vision = new googleVision();
            var results = vision.AnalyzeImage(Image.FromFile(file));

            foreach (var item in results.LabelAnnotations)
            {
                Console.WriteLine(item.Description);
            }
            
            foreach (var item in results.ImagePropertiesAnnotation.DominantColors.Colors)
            {
                Console.WriteLine(item.Color);   
            }                                 

        }  
    }
}
