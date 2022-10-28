using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ExpertSystem.Model;

namespace ExpertSystem.Service
{
    public class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH=path;
        }

        public List<Smartphone> LoadDate()
        {
            if (!File.Exists(PATH))
            {
                File.CreateText(PATH).Dispose();
                return new List<Smartphone>();
            }
            using (var sr = File.OpenText(PATH))
            {
                var fileText = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Smartphone>>(fileText);
            }
        }

        public void SaveDate(object list)
        {
            using (StreamWriter sw = new StreamWriter(PATH))
            {
                string output = JsonConvert.SerializeObject((List<Smartphone>)list);
                sw.WriteLine(output);
            }
        }
    }
}
