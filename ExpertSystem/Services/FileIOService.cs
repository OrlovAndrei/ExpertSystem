using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ExpertSystem.Model;
using System;
using System.Threading.Tasks;

namespace ExpertSystem.Service
{
    public class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH=path;
        }

        public Task<List<Smartphone>> LoadDate()
        {
            var task = new Task<List<Smartphone>>(() =>
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
            );
            task.Start();
            return task;
        }

        public Task<bool> SaveDate(object list)
        {
            var task = new Task<bool>(() =>
            {
                using (StreamWriter sw = new StreamWriter(PATH))
                {
                    string output = JsonConvert.SerializeObject((List<Smartphone>)list);
                    sw.WriteLine(output);
                }
                return true;
            });
            task.Start();
            return task;
        }
    }
}
