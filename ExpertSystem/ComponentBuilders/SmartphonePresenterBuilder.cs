using System.Windows;
using System.Windows.Controls;
using ExpertSystem.Model;
using System.Windows.Media.Imaging;
using System;
using System.Linq;

namespace ExpertSystem.ComponentBuilders
{
    internal class SmartphonePresenterBuilder
    {
        static public Grid Build(Smartphone smartphone)
        {
            var grid = new Grid();
            return grid
                .DefineColumns()
                .AddProperties(smartphone)
                .AddPhoto(smartphone);
        }
    }
}
