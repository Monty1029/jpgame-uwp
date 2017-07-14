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
        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";
        
        private HiraKataLogic hkl;

        public Hiragana()
        {
            this.InitializeComponent();

            hkl = new HiraKataLogic(option1, option2, option3, option4);

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
                Correct.Text = "Correct: " + answerResult;
            }
            else if (answerResult.StartsWith("i"))
            {
                answerResult = answerResult.Substring(1);
                Incorrect.Text = "Incorrect: " + answerResult;
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
            UpdateScore(hkl.GetScore(romajiCharacter1));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }

        private void Option3_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter1));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }

        private void Option4_Click(object sender, RoutedEventArgs e)
        {
            UpdateScore(hkl.GetScore(romajiCharacter1));
            hkl.ResetButtonSet();
            SetQuestionText();
            SetButtonText();
        }
    }
}
