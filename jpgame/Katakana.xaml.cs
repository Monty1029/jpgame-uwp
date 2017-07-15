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
    public sealed partial class Katakana : Page
    {
        private List<string> katakanaCharacters = new List<string>
        {
        "\u30A2","\u30A4","\u30A6","\u30A8","\u30AA","\u30AB","\u30AC","\u30AD","\u30AE","\u30AF",

        "\u30B0","\u30B1","\u30B2","\u30B3","\u30B4","\u30B5","\u30B6","\u30B7","\u30B8","\u30B9","\u30BA","\u30BB","\u30BC","\u30BD","\u30BE","\u30BF",

        "\u30C0","\u30C1","\u30C4","\u30C5","\u30C6","\u30C7","\u30C8","\u30C9","\u30CA","\u30CB","\u30CC","\u30CD","\u30CE","\u30CF",

        "\u30D0","\u30D1","\u30D2","\u30D3","\u30D4","\u30D5","\u30D6","\u30D7","\u30D8","\u30D9","\u30DA","\u30DB","\u30DC","\u30DD","\u30DE","\u30DF",

        "\u30E0","\u30E1","\u30E2","\u30E4","\u30E6","\u30E8","\u30E9","\u30EA","\u30EB","\u30EC","\u30ED","\u30EF",

        "\u30F2","\u30F3","\u30F4", "\u30F7", "\u30FA"
        };

        private List<string> romajiCharacters = new List<string>
        {
        "a","i","u","e","o","ka","ga","ki","gi","ku",

        "gu","ke","ge","ko","go","sa","za","shi","ji","su","zu","se","ze","so","zo","ta",

        "da","chi","tsu","dzu","te","de","to","do","na","ni","nu","ne","no","ha",

        "ba","pa","hi","bi","pi","fu","bu","pu","he","be","pe","ho","bo","po","ma","mi",

        "mu","me","mo","ya","yu","yo","ra","ri","ru","re","ro","wa",

        "wo","nn","vu", "va", "vo"
        };

        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";

        private bool option1Finish = false;

        private HiraKataLogic hkl;

        public Katakana()
        {
            this.InitializeComponent();

            hkl = new HiraKataLogic(option1, option2, option3, option4, katakanaCharacters, romajiCharacters);

            SetQuestionText();
            SetButtonText();
        }

        private void SetQuestionText()
        {
            string questionText = hkl.GetQuestionText();
            if (questionText.Equals("done", StringComparison.Ordinal))
            {
                katakana_char.Text = "";
                option1.Content = "Finish";
                option1Finish = true;
                option2.Visibility = Visibility.Collapsed;
                option3.Visibility = Visibility.Collapsed;
                option4.Visibility = Visibility.Collapsed;
            }
            else
            {
                katakana_char.Text = questionText;
            }

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

        private void UniversalButtonClick()
        {
            hkl.ResetButtonSet();
            SetQuestionText();
            if (option1Finish == false)
            {
                SetButtonText();
            }
        }

        private void Option1_Click(object sender, RoutedEventArgs e)
        {
            if (option2.Visibility == Visibility.Collapsed)
            {
                this.Frame.Navigate(typeof(LevelSelect));
            }
            else
            {
                UpdateScore(hkl.GetScore(romajiCharacter1));
                UniversalButtonClick();
            }

        }

        private void Option2_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter2));
            UniversalButtonClick();
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter3));
            UniversalButtonClick();
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter4));
            UniversalButtonClick();
        }
    }
}
