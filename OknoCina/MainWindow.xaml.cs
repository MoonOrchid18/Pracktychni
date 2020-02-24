using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OknoCina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double price = 0;
            double width = Convert.ToDouble(textBoxWidth.Text);
            double height = Convert.ToDouble(textBoxHeight.Text);


            if ((bool)radioButtonOneCam.IsChecked && comboBoxMaterial.SelectedIndex == 0)
            {
                price = Math.Pow(width * 0.25, 2) + Math.Pow(height * 0.25, 2);
            }

            if ((bool)radioButtonOneCam.IsChecked && comboBoxMaterial.SelectedIndex == 1)
            {
                price = Math.Pow(width * 0.05, 2) + Math.Pow(height * 0.05, 2);
            }

            if ((bool)radioButtonOneCam.IsChecked && comboBoxMaterial.SelectedIndex == 2)
            {
                price = Math.Pow(width * 0.15, 2) + Math.Pow(height * 0.15, 2);
            }

            if ((bool)radioButtonTwoCam.IsChecked && comboBoxMaterial.SelectedIndex == 0)
            {
                price = Math.Pow(width * 0.3, 2) + Math.Pow(height * 0.3, 2);
            }

            if ((bool)radioButtonTwoCam.IsChecked && comboBoxMaterial.SelectedIndex == 1)
            {
                price = Math.Pow(width * 0.1, 2) + Math.Pow(height * 0.1, 2);
            }

            if ((bool)radioButtonTwoCam.IsChecked && comboBoxMaterial.SelectedIndex == 2)
            {
                price = Math.Pow(width * 0.2, 2) + Math.Pow(height * 0.2, 2);
            }

            if ((bool)checkBoxWindowsill.IsChecked)
            {
                price += 35;
            }

            labelPrice.Content = "Вартість: " + price + "грн";
        }
    }
}
