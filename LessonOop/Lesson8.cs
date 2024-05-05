using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonOop
{
    public class Lesson8
    {
        public static string[] FindFile(string path, string fileFormat)
        {              
            return Directory.GetFiles(path, fileFormat, SearchOption.AllDirectories); 
        }
        public static List<string> ReaderFile(string[] strings, string text)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < strings.Length; i++)
            {
                string txt = File.ReadAllText(strings[i]);

                if (txt.ToLower().Contains(text.ToLower()))
                    result.Add(strings[i]);
                    //Console.WriteLine($"Слово ({text}) есть в файле {strings[i]}" );
            }

            return result;
        }
    }
}
