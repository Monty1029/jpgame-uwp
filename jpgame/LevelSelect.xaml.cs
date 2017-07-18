using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace jpgame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LevelSelect : Page
    {
        public LevelSelect()
        {
            this.InitializeComponent();
        }

        private void Hiragana_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Hiragana));
        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Charts));
        }

        private void Colors_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Colors));
        }

        private void Katakana_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Katakana));
        }
    }
}
