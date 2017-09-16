using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulearn1
{
    class ex9
    {
    	static string GetLastHalf(string text)
        {
            int halfLength = text.Length / 2;     //getting length of string and then half of it
            text = text.Substring(halfLength);    //get new string that begins from half of origin string
            text = text.Replace(" ","");          //replacing spaces
            return text;                          //return needed string
        }


        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}