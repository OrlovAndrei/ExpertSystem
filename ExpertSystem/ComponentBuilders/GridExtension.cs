using ExpertSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ExpertSystem.ComponentBuilders
{
    internal static class GridExtension
    {
        public static Grid DefineColumns(this Grid grid)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Margin = new Thickness(15.0, 15.0, 15.0, 10.0);
            return grid;
        }

        public static Grid AddProperties(this Grid grid, Smartphone smartphone)
        {
            TextBlock name = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(10.0, 5.0, 10.0, 5.0),
                FontWeight = FontWeights.Bold,
                FontSize = 20.0,
                Text = smartphone.Name,
            };
            Grid.SetRow(name, 0);
            Grid.SetColumn(name, 0);
            Grid.SetColumnSpan(name, 3);

            grid.Children.Add(name);

            var props = smartphone
                .GetType()
                .GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(LabelAttribute)));
            var j = 0;

            foreach (var prop in props)
            {
                grid.RowDefinitions.Add(new RowDefinition());

                var attribute = prop.GetCustomAttributes(true).OfType<LabelAttribute>().First();

                TextBlock propName = new TextBlock()
                {
                    Text = attribute.LabelText,
                    Padding = new Thickness(10.0, 0.0, 10.0, 0.0),
                };
                Grid.SetRow(propName, j+1);
                Grid.SetColumn(propName, 1);
                grid.Children.Add(propName);

                TextBlock propValue = new TextBlock()
                {
                    Padding = new Thickness(10.0, 0.0, 10.0, 0.0),
                };

                if (prop.GetValue(smartphone) is bool)
                    propValue.Text = (bool)prop.GetValue(smartphone) ? "Есть" : "Нет";
                else
                    propValue.Text = prop.GetValue(smartphone).ToString() + attribute.Symbol;

                Grid.SetRow(propValue, j+1);
                Grid.SetColumn(propValue, 2);
                grid.Children.Add(propValue);

                j++;
            }

            return grid;
        }

        public static Grid AddPhoto(this Grid grid, Smartphone smartphone)
        {
            var image = new Image();
            Grid.SetRow(image, 1);
            Grid.SetRowSpan(image, grid.RowDefinitions.Count-1);
            Grid.SetColumn(image, 0);

            image.Source = new BitmapImage(new Uri("Resources\\" + smartphone.Image, UriKind.Relative));
            grid.Children.Add(image);

            return grid;
        }
    }
}
