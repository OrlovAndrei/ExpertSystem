using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExpertSystem.Model
{
    public class Smartphone : INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [JsonProperty(PropertyName = "os")]
        public string OS { get; set; }

        [JsonProperty(PropertyName = "ram")]
        public int RAM { get; set; }

        [JsonProperty(PropertyName = "storage")]
        public int Storage { get; set; }

        [JsonProperty(PropertyName = "resolution")]
        public string Resolution { get; set; }

        [JsonProperty(PropertyName = "creationDate")]
        public double Size { get; set; }

        [JsonProperty(PropertyName = "isCamera")]
        public bool IsCamera { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
