using System.Windows.Controls;
using ExpertSystem.Model;

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
