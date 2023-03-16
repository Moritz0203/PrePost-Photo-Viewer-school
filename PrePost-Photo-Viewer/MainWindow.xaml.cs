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
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                image1 = new BitmapImage(new Uri(openFileDialog.FileName));
                Image1.Source = image1;
            }
        }
        private void BrowseButton2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                image2 = new BitmapImage(new Uri(openFileDialog.FileName));
                Image2.Source = image2;
            }
        }
        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            if (image1 != null && image2 != null)
            {
                if (image1.Width == image2.Width && image1.Height == image2.Height)
                {
                    int pixelCount = image1.PixelWidth * image1.PixelHeight;
                    int differentPixels = 0;
                    byte[] pixels1 = new byte[pixelCount * 4];
                    image1.CopyPixels(pixels1, image1.PixelWidth * 4, 0);
                    byte[] pixels2 = new byte[pixelCount * 4];
                    image2.CopyPixels(pixels2, image2.PixelWidth * 4, 0);
                    for (int i = 0; i < pixelCount * 4; i++)
                    {
                        if (pixels1[i] != pixels2[i])
                        {
                            differentPixels++;
                        }
                    }
                    double differencePercentage = (double)differentPixels / (double)pixelCount * 100;
                    MessageBox.Show($"The images differ in {differencePercentage}% of their pixels.", "Image Comparison Result", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("The images have different dimensions and cannot be compared.", "Image Comparison Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select two images to compare.", "Image Comparison Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

