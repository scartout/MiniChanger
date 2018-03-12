using System;
using System.Windows;
using System.IO;

namespace MiniChanger
{
    public partial class MainWindow : Window
    { 

        public MainWindow()
        {
            InitializeComponent();
            Text1.Text = Directory.GetCurrentDirectory();
            Radio3.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Text1.Text.EndsWith("\\") ? Text1.Text : Text1.Text+"\\";
            int i = Int32.Parse(Text2.Text);
            int j = Int32.Parse(Text3.Text);
            string pattern = Text4.Text;
            string extension = Text5.Text.StartsWith(".") ? Text5.Text : "."+Text5.Text;

            string[] fileArray = Directory.GetFiles(path);

            foreach (string element in fileArray)
            {
                if (extension.Equals(".")) extension = Path.GetExtension(element);
                if (Radio1.IsChecked == true) System.IO.File.Move(element, path + pattern + i.ToString() + extension);
                else if (Radio2.IsChecked == true) System.IO.File.Move(element, path + i.ToString() + pattern + extension);
                else System.IO.File.Move(element, path + i.ToString() + extension);
                i = (int) i + (int) j;
            }
            MessageBox.Show("Operation successfully completed!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string filePath = dialog.SelectedPath;
            Text1.Text = filePath;
        }

    }
}
