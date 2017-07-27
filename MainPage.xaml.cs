using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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

        static Button but1 = new Button { Content = "but1", IsEnabled = true, Margin=new Thickness(10) }; 

        public MainPage()
        {
            this.InitializeComponent();

            stackPanel1.Children.Add(but1);

            but1.PointerMoved += mm;
            but1.Click += but1Clicked; 
        }

        static void mm(object sender, PointerRoutedEventArgs e)
        {
            but1.Margin = new Thickness(rand.Next() % 200); 
           
        }

        static void but1Clicked(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            b.Content = "Hey You got me"; 
        }
        
        private void Button_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Cheese.Margin = new Thickness(rand.Next() % 200 ); 
        }

        private void Cheese_Click(object sender, RoutedEventArgs e)
        {
            Words.Text = e.ToString();

        }

        private void stackPanel1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
        }
    }
}
