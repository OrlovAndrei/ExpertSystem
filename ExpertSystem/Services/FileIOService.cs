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
                try
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
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    return new List<Smartphone>();
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
                try
                {
                    using (StreamWriter sw = new StreamWriter(PATH))
                    {
                        string output = JsonConvert.SerializeObject((List<Smartphone>)list);
                        sw.WriteLine(output);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    return false;
                }
            });
            task.Start();
            return task;
        }
    }
}
