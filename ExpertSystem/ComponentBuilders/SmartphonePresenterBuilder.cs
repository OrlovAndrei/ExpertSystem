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

            for (int i = 0; i<propList.GetLength(0); i++)
            {
                TextBlock propName = new TextBlock()
                {
                    Text = propList[i, 0],
                    Padding = new Thickness(10.0, 0.0, 10.0, 0.0),
                };
                Grid.SetRow(propName, i+1);
                Grid.SetColumn(propName, 1);
                grid.Children.Add(propName);

                TextBlock propValue = new TextBlock()
                {
                    Text = propList[i, 1],
                    Padding = new Thickness(10.0, 0.0, 10.0, 0.0),
                };
                Grid.SetRow(propValue, i+1);
                Grid.SetColumn(propValue, 2);
                grid.Children.Add(propValue);
            }

            return grid;
        }
    }
}
