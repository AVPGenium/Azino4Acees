using System;
using System.Text;

// Далее ваши библиотеки
using Newtonsoft.Json;
using System.IO;

namespace AzinoCore
{
    class AzinoProperties
    {
        public static AzinoProperties Load(string path)
        {
            return JsonConvert.DeserializeObject<AzinoProperties>(File.ReadAllText(path));
        }

        public int SpinCost { get; set; }
        public int SmallSpinCost { get; set; }
        public int StartBalance { get; set; }
        public int Prize1 { get; set; }
        public int Prize2 { get; set; }
        public int Prize3 { get; set; }
        public int Prize4 { get; set; }
        public int Prize5 { get; set; }
    }
}
