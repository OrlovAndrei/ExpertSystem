using System.Windows.Controls;

namespace ExpertSystem.Service
{
    static internal class FilterService
    {
        static public bool Filter(int prop, TextBox min, TextBox max)
        {
            if(int.Parse(min.Text) + int.Parse(max.Text) == 0) return true;
            return prop >= int.Parse(min.Text) && prop <= int.Parse(max.Text);
        }

        static public bool Filter(double prop, TextBox min, TextBox max)
        {
            if (int.Parse(min.Text) + int.Parse(max.Text) == 0) return true;
            return prop >= double.Parse(min.Text) && prop <= double.Parse(max.Text);
        }

        static public bool Filter(string prop, ListBox listBox)
        {
            if(listBox.SelectedItems.Count == 0) return true;
            var isContain = true;
            foreach (TextBlock elem in listBox.SelectedItems)
            {
                if (!prop.Contains(elem.Text))
                {
                    isContain = false;
                    break;
                }
            }
            return isContain;
        }

        static public bool Filter(string prop, ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null) return true;
            var selectedBlock = (TextBlock)comboBox.SelectedItem;
            return prop == selectedBlock.Text;
        }

        static public bool Filter(string prop, TextBox textBox)
        {
            return prop.ToLower().Contains(textBox.Text.ToLower());
        }

        static public bool Filter(bool prop, CheckBox checkBox)
        {
            return prop == checkBox.IsChecked;
        }
    }
}
