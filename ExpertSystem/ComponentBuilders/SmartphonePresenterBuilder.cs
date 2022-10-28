using System.Windows;
using System.Windows.Controls;
using ExpertSystem.Model;
using System.Windows.Media.Imaging;
using System;

namespace ExpertSystem.ComponentBuilders
{
    internal class SmartphonePresenterBuilder
    {
        static public Grid Build(Smartphone smartphone)
        {
            var grid = new Grid();
            for (int i = 0; i < 10; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.Margin = new Thickness(15.0, 15.0, 15.0, 10.0);

            TextBlock name = new TextBlock();
            Grid.SetRow(name, 0);
            Grid.SetColumn(name, 0);
            Grid.SetColumnSpan(name, 3);
            name.HorizontalAlignment = HorizontalAlignment.Center;
            name.VerticalAlignment = VerticalAlignment.Center;
            name.Padding = new Thickness(10.0, 5.0, 10.0, 5.0);
            name.FontWeight = FontWeights.Bold;
            name.FontSize = 20.0;
            name.Text = smartphone.Name;
            grid.Children.Add(name);

            var image = new Image();
            Grid.SetRow(image, 1);
            Grid.SetRowSpan(image, 9);
            Grid.SetColumn(image, 0);

            image.Source = new BitmapImage(new Uri("Resources\\" + smartphone.Image, UriKind.Relative));
            grid.Children.Add(image);

            var isCamera = smartphone.IsCamera ? "Есть" : "Нет";
            string[,] propList =
            {
                { "Цена:", $"{smartphone.Price}$" },
                { "Компания:", $"{smartphone.Company}" },
                { "Сеть:", $"{smartphone.Network}" },
                { "OS:", $"{smartphone.OS}" },
                { "Оперативная память:", $"{smartphone.RAM}GB" },
                { "Память:", $"{smartphone.Storage}GB" },
                { "Разрешение экрана:", $"{smartphone.Resolution}" },
                { "Размер:", $"{smartphone.Size}\"" },
                { "Камера:", $"{isCamera}" }
            };

            for (int i = 0; i < propList.GetLength(0); i++)
            {
                TextBlock propName = new TextBlock();
                Grid.SetRow(propName, i+1);
                Grid.SetColumn(propName, 1);
                propName.Text = propList[i, 0];
                propName.Padding = new Thickness(10.0, 0.0, 10.0, 0.0);
                grid.Children.Add(propName);

                TextBlock propValue = new TextBlock();
                Grid.SetRow(propValue, i+1);
                Grid.SetColumn(propValue, 2);
                propValue.Text = propList[i, 1];
                propValue.Padding = new Thickness(10.0, 0.0, 10.0, 0.0);
                grid.Children.Add(propValue);
            }

            return grid;
        }
    }
}
