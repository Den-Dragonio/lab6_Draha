using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_6._2__1_
{
    public interface IRecordable
    {
        void Record();
        void Pause();
        void Stop();
    }

    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }

    public interface IMedia
    {
        static string name;
        static string path;
    }

    class MkvFile : IPlayable
    {
        public void Pause() { }
        public void Play() { }
        public void Stop() { }
    }

    class MP3File : IRecordable
    {
        public void Pause() { }
        public void Record() { }
        public void Stop() { }
    }

    class WavFile : IRecordable, IPlayable
    {
        void IRecordable.Pause() { }
        void IRecordable.Record() { }
        void IRecordable.Stop() { }
        void IPlayable.Pause() { }
        void IPlayable.Play() { }
        void IPlayable.Stop() { }
    }

    class PlayerItem : IMedia
    {
        public PlayerItem()
        {
            DisplayInfo();
        }
        public static void DisplayInfo()
        {
            Console.WriteLine("Директория файла: " + IMedia.path);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string pathMkvFile = @"D:\PROJECTS\Visual studio back-end\Лабораторна 6\курс 2 лаб 6\lab 6.2 (1)\media\MkvFile.Mkv";
            string pathMP3File = @"D:\PROJECTS\Visual studio back-end\Лабораторна 6\курс 2 лаб 6\lab 6.2 (1)\media\MP3File.mp3";
            string pathWavFile = @"D:\PROJECTS\Visual studio back-end\Лабораторна 6\курс 2 лаб 6\lab 6.2 (1)\media\WavFile.wav";
            string nameMkv = "MkvFile";
            string nameMP3 = "MP3File";
            string nameWav = "WavFile";

            if (File.Exists(pathMkvFile))
            {
                File.Delete(pathMkvFile);
            }
            if (File.Exists(pathMP3File))
            {
                File.Delete(pathMP3File);
            }
            if (File.Exists(pathWavFile))
            {
                File.Delete(pathWavFile);
            }
            File.Create(pathMkvFile).Dispose();
            File.Create(pathMP3File).Dispose();
            File.Create(pathWavFile).Dispose();
            Console.WriteLine("Файлы в папке Медиа: ");
            string[] massiveDirectories = new string[] { nameMkv, nameMP3, nameWav };
            foreach (string item in massiveDirectories)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("Введите название файла, для дальнейшей операции с ним!");
            IMedia.name = Console.ReadLine();
            if (IMedia.name == "MkvFile")
            {
                IMedia.path = pathMkvFile;
            }
            else if (IMedia.name == "MP3File")
            {
                IMedia.path = pathMP3File;
            }
            else if (IMedia.name == "WavFile")
            {
                IMedia.path = pathWavFile;
            }
            PlayerItem pi = new PlayerItem();
        }
    }
}
