using System;
using System.IO;
using System.Windows;

namespace MultipurposeApp
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

        private void LoadingButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(urlTextBox.Text) && !string.IsNullOrEmpty(fileNameTextBox.Text) && !string.IsNullOrEmpty(fileExtensionTextBox.Text)
               && !string.IsNullOrWhiteSpace(urlTextBox.Text) && !string.IsNullOrWhiteSpace(fileNameTextBox.Text) && !string.IsNullOrWhiteSpace(fileExtensionTextBox.Text))
            {
                string url = urlTextBox.Text;
                string fileName = fileNameTextBox.Text + "." + fileExtensionTextBox.Text;

                var domain = AppDomain.CreateDomain("Another Download Domain Area");
                domain.ExecuteAssembly(domain.BaseDirectory + "DownloadApp.exe", new string[] { url, fileName });

                AppDomain.Unload(domain);
            }
            else
            {
                MessageBox.Show("Один или несколько полей пустые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            int numb;
            if(int.TryParse(numbTextBox.Text, out numb))
            {
                var domain = AppDomain.CreateDomain("Another Factorial Domain Area");
                domain.ExecuteAssembly(domain.BaseDirectory + "FactorialApp.exe", new string[] { numb.ToString() });

                AppDomain.Unload(domain);

                using(var reader = new StreamReader("factorial.txt"))
                {
                    factorialTextBox.Text = reader.ReadLine();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели недопустимое значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                numbTextBox.Text = string.Empty;
                factorialTextBox.Text = string.Empty;
            }
        }
    }
}
