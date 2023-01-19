using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExpertSystem.Model
{
    public class Smartphone : INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Label("Компания:", "")]
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        [Label("Цена:", "$")]
        [JsonProperty(PropertyName = "price")]
        public int Price { get; set; }

        [Label("Сеть:", "")]
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [Label("OS:", "")]
        [JsonProperty(PropertyName = "os")]
        public string OS { get; set; }

        [Label("Оперативная память:", "GB")]
        [JsonProperty(PropertyName = "ram")]
        public int RAM { get; set; }

        [Label("Память:", "GB")]
        [JsonProperty(PropertyName = "storage")]
        public int Storage { get; set; }

        [Label("Разрешение экрана:", "")]
        [JsonProperty(PropertyName = "resolution")]
        public string Resolution { get; set; }

        [Label("Размер:", "\"")]
        [JsonProperty(PropertyName = "creationDate")]
        public double Size { get; set; }

        [Label("Камера:", "")]
        [JsonProperty(PropertyName = "isCamera")]
        public bool IsCamera { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
