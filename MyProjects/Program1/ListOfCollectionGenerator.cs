using System.Text;

namespace Program1
{
    public static class ListOfCollectionGenerator
    {
        /// <summary>
        /// Радужный метод расширения для string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="str"></param>
        public static void RainbowString(this string text, string str)
        {
            do
            {
                for (int i = 0; i < 15; i++)
                {
                    if (i == 0)
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else if (i == 1)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (i == 2)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (i == 3)
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    else if (i == 4)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (i == 5)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else if (i == 6)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (i == 7)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (i == 8)
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    else if (i == 9)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (i == 10)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    else if (i == 11)
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (i == 12)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == 13)
                        Console.ForegroundColor = ConsoleColor.Gray;
                    else if (i == 14)
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(str + "\r");

                    Console.CursorVisible = false;

                    Thread.Sleep(100);
                }
            }
            while (!Console.KeyAvailable);
        }
    
        /// <summary>
        /// Cоздаёт список музыкальной коллекции
        /// </summary>
        /// <param name="path">Путь к диску с коллекцией</param>
        /// <param name="destinationFolder">Путь, куда сохраняется файл со списком коллекции</param>
        static void GetCollection(string path, string destinationFolder)
        {
            using StreamWriter writer = new StreamWriter(destinationFolder, false, Encoding.UTF8);
            {
                var directory = new DirectoryInfo(path);

                DirectoryInfo[] directoryInfo = directory.GetDirectories();

                foreach (DirectoryInfo genre in directoryInfo)
                {
                    Console.WriteLine("\n" + genre.Name + " :\n");

                    writer.WriteLine("\n" + genre.Name + " :\n");

                    DirectoryInfo[] directoryInfo2 = genre.GetDirectories();

                    foreach (DirectoryInfo bandName in directoryInfo2)
                    {
                        Console.WriteLine("\t" + bandName.Name);

                        writer.WriteLine("\t" + bandName.Name);

                        DirectoryInfo[] directoryInfo3 = bandName.GetDirectories();

                        if (directoryInfo3.Length < 2)
                        {
                            continue;
                        }

                        foreach (DirectoryInfo albumName in directoryInfo3)
                        {
                            Console.WriteLine("\t\t" + albumName.Name);

                            writer.WriteLine("\t\t" + albumName.Name);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"H:\MUSIC\";

            string destinationFolder = @"C:\Users\User\OneDrive\Рабочий стол\My music collection.txt";

            string str = "Нажмите любую клавишу для создания списка музыкальной коллекции";

            str.RainbowString(str);

            GetCollection(path, destinationFolder);

            Console.WriteLine();

            Console.ReadKey(true);

            str = "Программа создания списка музыкальной коллекции выполнена";

            str.RainbowString(str);
        }
    }
}
