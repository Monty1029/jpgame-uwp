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
    public sealed partial class Colors : Page
    {
        private List<string> colorsJapanese = new List<string>
        {
        "\u9ED2\u3044 \uFF08\u304F\u308D\u3044\uFF09", //Black
        "\u767D\u3044 \uFF08\u3057\u308D\u3044\uFF09", //White
        "\u8D64\u3044 \uFF08\u3042\u304B\u3044\uFF09", //Red
        "\u9EC4\u8272 \uFF08\u304D\u3044\u308D\uFF09", //Yellow
        "\u9752\u3044 \uFF08\u3042\u304A\u3044\uFF09", //Blue
        "\u7DD1 \uFF08\u307F\u3069\u308A\uFF09", //Green
        "\u7D2B \uFF08\u3080\u3089\u3055\u304D\uFF09", //Purple
        "\u30AA\u30EC\u30F3\u30B8" //Orange
        };

        private List<string> colorsEnglish = new List<string>
        {
            "Black", "White", "Red", "Yellow", "Blue", "Green", "Purple", "Orange"
        };

        public Colors()
        {
            this.InitializeComponent();
        }
    }
}
