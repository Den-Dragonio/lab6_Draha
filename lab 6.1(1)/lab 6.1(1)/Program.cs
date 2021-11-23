using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace lab_6._1_1_
{
    class AbstractHandler 
    {
        public static int a = 1;
        public static string path = @"D:\\PROJECTS\\Visual studio back-end\\Лабораторна 6\\курс 2 лаб 6\\lab 6.1(1)\\new_doc.txt";

        public static void CreateNewDoc()
        {
            using (File.Create(path)) 
            Console.WriteLine("Новый документ был создан!");
        }
        public static void OpenDoc()
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст документа: {textFromFile}");
            }
        }
        public static void EditDoc()
        {
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                Console.WriteLine("Введите, что вы хотитие записать:");
                string text = Console.ReadLine();
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                fstream.Write(array, 0, array.Length);
                Console.WriteLine("- Это было записано!");
            }
        }
    }

    class Program : AbstractHandler
    {
        public static bool b = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Что б создать новый документ - нажмите 1!");
            Console.WriteLine("Что бы открыть документ - нажмите 2!");
            Console.WriteLine("Что бы провести изменения в документе - нажмите 3!");

            while (b == true)
            {
                int button = Convert.ToInt32(Console.ReadLine());
                if (button == 1)
                {
                    CreateNewDoc();
                }
                else if (button == 2)
                {
                    OpenDoc();
                }
                else if (button == 3)
                {
                    EditDoc();
                }
            }
        }
    }
}
