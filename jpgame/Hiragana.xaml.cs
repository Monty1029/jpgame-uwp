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
    public sealed partial class Hiragana : Page
    {
        public Hiragana()
        {
            this.InitializeComponent();

            var hiraganaCharacters = new List<string>
            {
            "\u3042",
            "\u3044",
            "\u3046",
            "\u3048",
            "\u304A",
            "\u304B",
            "\u304C",
            "\u304D",
            "\u304E",
            "\u304F",

            "\u3050",
            "\u3051",
            "\u3052",
            "\u3053",
            "\u3054",
            "\u3055",
            "\u3056",
            "\u3057",
            "\u3058",
            "\u3059",
            "\u305A",
            "\u305B",
            "\u305C",
            "\u305D",
            "\u305E",
            "\u305F",

            "\u3060",
            "\u3061",
            "\u3062",
            "\u3064",
            "\u3065",
            "\u3066",
            "\u3067",
            "\u3068",
            "\u3069",
            "\u306A",
            "\u306B",
            "\u306C",
            "\u306D",
            "\u306E",
            "\u306F",

            "\u3070",
            "\u3071",
            "\u3072",
            "\u3073",
            "\u3074",
            "\u3075",
            "\u3076",
            "\u3077",
            "\u3078",
            "\u3079",
            "\u307A",
            "\u307B",
            "\u307C",
            "\u307D",
            "\u307E",
            "\u307F",

            "\u3080",
            "\u3081",
            "\u3082",
            "\u3084",
            "\u3086",
            "\u3088",
            "\u3089",
            "\u308A",
            "\u308B",
            "\u308C",
            "\u308D",
            "\u308F",

            "\u3092",
            "\u3093",
            "\u3094",
            "\u3095",
            "\u3096",
            };

            Random random = new Random();
            int index = random.Next(hiraganaCharacters.Count);
            var hiraganaCharacter = hiraganaCharacters[index];
            hiraganaCharacters.RemoveAt(index);
            hiragana_char.Text = hiraganaCharacter;
        }
    }
}
