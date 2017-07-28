using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HoppyButton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static Random rand = new Random();

        static Button but1 = new Button { Content = "but1", IsEnabled = true };

        static TextBox t3 = new TextBox { Text = "mmmmm" };

        public MainPage()
        {
            this.InitializeComponent();

            stackPanel1.Children.Add(but1);

            stackPanel3.Children.Add(t3);

            but1.PointerMoved += Mm;
            but1.Click += But1Clicked;

            stackPanel3.PointerExited += GoodBye;
            stackPanel3.PointerEntered += Welcome;
        }

        static void Mm(object sender, PointerRoutedEventArgs e)
        {
            var number = rand.Next() % 200;
            but1.Margin = new Thickness(number, rand.Next() % 200, rand.Next() % 200, rand.Next() % 200);
            but1.Content = number;

        }

        static void But1Clicked(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.Content = "Hey You got me";

        }

        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Cheese.Margin = new Thickness(rand.Next() % 200, rand.Next() % 200, rand.Next() % 200, rand.Next() % 200);

            Cheese.Content = rand.Next() % 200;
        }

        private void Cheese_Click(object sender, RoutedEventArgs e)
        {
            Words.Text = e.ToString();

        }

        private void GoodBye(object sender, PointerRoutedEventArgs e)
        {
            t3.Text = "Goodbye";

            if (stackPanel3.Children.Count > 2)
            {
                stackPanel3.Children.RemoveAt(stackPanel3.Children.Count - 1);
            }
        }

        private void stackPanel3_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            t3.Text = "Welcome";

        }

        private async void Welcome(object sender, PointerRoutedEventArgs e)
        {
            Button b4 = new Button { Content = $"Mozy {e.ToString()}" };

            if (stackPanel3.Children.Count < 3)
            {
                
                stackPanel3.Children.Add(b4);
            }
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                b4.Margin = new Thickness(i*10);
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 10; i++)
            {
                int[] mar = { rand.Next(50), rand.Next(50), rand.Next(50), rand.Next(50) };

                Button but = new Button { Content = $"{mar[0]} {mar[1]} {mar[2]} {mar[3]}", Padding = new Thickness(mar[0], mar[1], mar[2], mar[3]) };
                stackPanel3.Children.Add(but);
            }
        }

        private void stackPanel2_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            GetCatPhoto(); 
        }

        private async void GetCatPhoto()
        {
            Uri photoUri = new Uri("http://thecatapi.com/api/images/get?type=gif");
            try
            {
                using (var client = new HttpClient())
                {
                    var photoResult = await client.GetAsync(photoUri);
                    using (var imageStream = await photoResult.Content.ReadAsStreamAsync())
                    {
                        BitmapImage image = new BitmapImage();
                        using (var randomStream = imageStream.AsRandomAccessStream())
                        {
                            await image.SetSourceAsync(randomStream);
                            catPhoto.Source = image;
                        }
                    }
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString()); 
            }
        }
    }
}
