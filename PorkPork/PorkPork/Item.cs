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
        Color color;
        Google.Cloud.Vision.V1.Image image;
        public Item()
        {

        }
        public Item(string[] tag, Color color, Google.Cloud.Vision.V1.Image image)
        {
            this.tag = tag;
            this.color = color;
            this.image = image;
        }
    }
}
