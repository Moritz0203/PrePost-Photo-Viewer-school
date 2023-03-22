using Microsoft.Win32;
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

namespace PrePost_Photo_Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BitmapImage image1;
        private BitmapImage image2;

        private void BrowseButton1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                image1 = new BitmapImage(new Uri(openFileDialog.FileName));
                Image1.Width = image1.Width >= 1050 ? 1050 : image1.Width;
                Image1.Height = image1.Height >= 800 ? 800 : image1.Height;

                Image1.Source = image1;

                sleider.Width = Image1.Width;
                sleider.Maximum = Image1.Width;
            }
        }
        private void BrowseButton2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                image2 = new BitmapImage(new Uri(openFileDialog.FileName));
                Image2.Width = image2.Width >= 1050 ? 1050 : image2.Width;
                Image2.Height = image2.Height >= 800 ? 800 : image2.Height;

                Image2.Source = image2;


            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Sleid.IsChecked == true)
                Image2.Width = sleider.Value;
            else if (Opacity.IsChecked == true)
            {
                Image2.Width = image2.Width >= 1050 ? 1050 : image2.Width;
                double slidervalu = e.NewValue;
                double Opacity = 1 - slidervalu;
                Image1.Opacity = slidervalu;
                Image2.Opacity = Opacity;
            }
        }
    }
}

