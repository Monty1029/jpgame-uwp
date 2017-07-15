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
        private List<string> hiraganaCharacters = new List<string>
        {
        "\u3042","\u3044","\u3046","\u3048","\u304A","\u304B","\u304C","\u304D","\u304E","\u304F",

        "\u3050","\u3051","\u3052","\u3053","\u3054","\u3055","\u3056","\u3057","\u3058","\u3059","\u305A","\u305B","\u305C","\u305D","\u305E","\u305F",

        "\u3060","\u3061","\u3064","\u3065","\u3066","\u3067","\u3068","\u3069","\u306A","\u306B","\u306C","\u306D","\u306E","\u306F",

        "\u3070","\u3071","\u3072","\u3073","\u3074","\u3075","\u3076","\u3077","\u3078","\u3079","\u307A","\u307B","\u307C","\u307D","\u307E","\u307F",

        "\u3080","\u3081","\u3082","\u3084","\u3086","\u3088","\u3089","\u308A","\u308B","\u308C","\u308D","\u308F",

        "\u3092","\u3093","\u3094"
        };

        private List<string> romajiCharacters = new List<string>
        {
        "a","i","u","e","o","ka","ga","ki","gi","ku",

        "gu","ke","ge","ko","go","sa","za","shi","ji","su","zu","se","ze","so","zo","ta",

        "da","chi","tsu","dzu","te","de","to","do","na","ni","nu","ne","no","ha",

        "ba","pa","hi","bi","pi","fu","bu","pu","he","be","pe","ho","bo","po","ma","mi",

        "mu","me","mo","ya","yu","yo","ra","ri","ru","re","ro","wa",

        "wo","nn","vu"
        };

        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";
        
        private HiraKataLogic hkl;

        public Hiragana()
        {
            this.InitializeComponent();

            hkl = new HiraKataLogic(option1, option2, option3, option4, hiraganaCharacters, romajiCharacters);

            SetQuestionText();
            SetButtonText();
        }

        private void SetQuestionText()
        {
            hiragana_char.Text = hkl.GetQuestionText();
        }

        private void SetButtonText()
        {
            string[] buttonText = hkl.GetButtonText();
            romajiCharacter1 = buttonText[0];
            romajiCharacter2 = buttonText[1];
            romajiCharacter3 = buttonText[2];
            romajiCharacter4 = buttonText[3];

            option1.Content = romajiCharacter1;
            option2.Content = romajiCharacter2;
            option3.Content = romajiCharacter3;
            option4.Content = romajiCharacter4;
        }

        private void UpdateScore(string answerResult)
        {
            if (answerResult.StartsWith("c"))
            {
                answerResult = answerResult.Substring(1);
                Correct.Text = "\u2714: " + answerResult;
            }
            else if (answerResult.StartsWith("i"))
            {
                answerResult = answerResult.Substring(1);
                Incorrect.Text = "\u2718: " + answerResult;
            }
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter1)); 
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter2));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter3));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter4));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }
    }
}
