using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LessonOop
{
    public class Lesson9
    {

        private readonly string path;
        private readonly string maskFile;
        private readonly string text;


        public Lesson9(string path, string maskFile, string text)
        {
            this.path = path;
            this.maskFile = maskFile;
            this.text = text;

        }
        public static void FindFile(object? obj)
        {

            if (obj is Lesson9 l9)
            {
                foreach (string fn in Directory.GetFiles(l9.path, l9.maskFile, SearchOption.AllDirectories))
                {
                    if (fn != null)
                    {
                        Console.WriteLine($"Найден файл соответствующий маске ({l9.maskFile}) - {fn}");

                        Thread rf = new Thread(() =>
                        {
                            string txt = File.ReadAllText(fn);
                            if (txt.ToLower().Contains(l9.text.ToLower()))
                                Console.WriteLine($"Слово ({l9.text}) есть в файле {fn}" );
                            else
                                Console.WriteLine($"Слово ({l9.text}) не найдено совпадений в файле {fn}");
                        });
                        rf.Start();
                        rf.Join();
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
