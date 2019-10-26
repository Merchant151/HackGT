using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Google.Cloud.Vision.V1;

namespace PorkPork
{
    
    class Item
    {
        string[] tag;
        string imageName;
        Color color;
        Google.Cloud.Vision.V1.Image image;
        public Item()
        {

        }

        public Item(AnnotateImageResponse response,string imageName)
        {
            this.imageName = imageName;
            
        }

        public Item(string[] tag, Color color, string imageName)
        {
            this.tag = tag;
            this.color = color;
            this.imageName = imageName;
            this.image = Google.Cloud.Vision.V1.Image.FromFile("DatabaseIMG/"+imageName);
        }
        public Item(string line)
        {
            var l = line.Split('\t');

            image = Google.Cloud.Vision.V1.Image.FromFile(l[0]);
            imageName = l[0];
            color = Color.FromArgb(
                int.Parse(l[1]), 
                int.Parse(l[2]),
                int.Parse(l[3]));

            for (int i = 4; i < l.Length; i++)
            {
                tag[i-4] = l[i];
            }
        }             

        public string getCVSline()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(imageName+'\t');
            sb.Append(color.R + '\t');
            sb.Append(color.G + '\t');
            sb.Append(color.B + '\t');
            foreach (var item in tag)
            {
               sb.Append(item + '\t');
            }

            return sb.ToString();
        }

        //Returns the name which is the highest Label score or a combo
        public string getName()
        {
            if (tag.Length > 1) return tag[0] + " " + tag[1];
            return tag[0];
        }
    }
}
