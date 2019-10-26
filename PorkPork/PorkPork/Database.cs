using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkPork
{
    class Database
    {
        const string path = "DatabaseIMG/data.cvs";

        public static Item[] GetItems()
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            Item[] items = new Item[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                items[i] = new Item(lines[i]);
            }

            return null;
        }
        public static void appendItem(Item item)
        {
            var io = System.IO.File.AppendText(path);
            io.WriteLine(item.getCVSline());
        }
    }
}
