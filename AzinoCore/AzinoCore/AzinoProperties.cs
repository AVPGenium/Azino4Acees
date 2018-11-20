using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
// Далее ваши библиотеки
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class PropertiesHolder
    {
        static string DEFAULT_PATH = "Packages/default-properties.json"

        public PropertiesHolder()
        {

        }

        string serialize(Properties properties)
        {
            return JsonConvert.SerializeObject(properties);
        }

        Properties deserialize(string properties)
        {
            return JsonConvert.DeserializeObject<Properties>(properties);
        }

        void saveFile(string json, string path)
        {
            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(json);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }

        string readFile(string path)
        {
            using (FileStream fstream = File.OpenRead(@path))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("Текст из файла: {0}", textFromFile);
            }
        }
    }



    class Properties
    {
        public int score5=1000 { get; set; }
        public int score4=30 { get; set; }
        public int score3=10 { get; set; }
        public int score2=0 { get; set; }
        public int score1=-10 { get; set; }

        public int additionalRound=100 { get; set; }
        public int round=5 { get; set; }

   }
}
