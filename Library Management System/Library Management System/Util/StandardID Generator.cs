using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Util
{
    public static class StandardID_Generator
    {
        public static string bookstring = "BKI";
        public static Int32 idExtractorGenerator(string id) {

            Int32 sub = Int32.Parse(id.Substring(3));
            Console.WriteLine("Substring:", sub);

            return sub;
        }
    }
}
