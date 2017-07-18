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
        "\u9ED2\u3044\n\uFF08\u304F\u308D\u3044\uFF09", //Black
        "\u767D\u3044\n\uFF08\u3057\u308D\u3044\uFF09", //White
        "\u8D64\u3044\n\uFF08\u3042\u304B\u3044\uFF09", //Red
        "\u9EC4\u8272\n\uFF08\u304D\u3044\u308D\uFF09", //Yellow
        "\u9752\u3044\n\uFF08\u3042\u304A\u3044\uFF09", //Blue
        "\u7DD1\n\uFF08\u307F\u3069\u308A\uFF09", //Green
        "\u7D2B\n\uFF08\u3080\u3089\u3055\u304D\uFF09", //Purple
        "\u30AA\u30EC\u30F3\u30B8", //Orange
        "\u6843\u8272\n\uFF08\u3082\u3082\u3044\u308D\uFF09", //Pink
        "\u7070\u8272\n\uFF08\u306F\u3044\u3044\u308D\uFF09" //Grey
        };

        private List<string> colorsEnglish = new List<string>
        {
            "Black", "White", "Red", "Yellow", "Blue", "Green", "Purple", "Orange", "Pink", "Grey"
        };

        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";

        private bool option1Finish = false;

        private HiraKataLogic hkl;

        public Colors()
        {
            this.InitializeComponent();
            hkl = new HiraKataLogic(option1, option2, option3, option4, colorsJapanese, colorsEnglish);

            SetQuestionText();
            SetButtonText();
        }

        private void SetQuestionText()
        {
            string questionText = hkl.GetQuestionText();
            if (questionText.Equals("done", StringComparison.Ordinal))
            {
                color_question.Text = "";
                option1.Content = "Finish";
                option1Finish = true;
                option2.Visibility = Visibility.Collapsed;
                option3.Visibility = Visibility.Collapsed;
                option4.Visibility = Visibility.Collapsed;
            }
            else
            {
                color_question.Text = questionText;
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
