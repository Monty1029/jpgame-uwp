using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace jpgame
{
    class HiraKataLogic
    {        

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        List<string> japaneseText;
        List<string> englishText;

        private int correct = 0;
        private int incorrect = 0;

        private string hirakanaCharacter = "";
        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";

        private Button[] buttons = new Button[4];

        private bool[] optionButtonSet = new bool[] { false, false, false, false };

        public HiraKataLogic(Button option1, Button option2, Button option3, Button option4, List<string>japaneseText, List<string>englishText)
        {

            this.japaneseText = japaneseText;
            this.englishText = englishText;

            for (int i = 0; i < japaneseText.Count; i++)
            {
                dictionary.Add(japaneseText.ElementAt(i), englishText.ElementAt(i));
            }

            buttons[0] = option1;
            buttons[1] = option2;
            buttons[2] = option3;
            buttons[3] = option4;
        }

        public string GetQuestionText()
        {
            if (japaneseText.Count == 0)
            {
                return "done";
            }
            Random random = new Random();
            int hiragana_index = random.Next(japaneseText.Count);
            hirakanaCharacter = japaneseText[hiragana_index];
            japaneseText.RemoveAt(hiragana_index);
            return hirakanaCharacter;
        }

        public string[] GetButtonText()
        {
            Random random = new Random();

            int button_index = random.Next(buttons.Length);
            buttons[button_index].Content = dictionary[hirakanaCharacter];
            if (button_index == 0)
            {
                romajiCharacter1 = dictionary[hirakanaCharacter];
            }
            else if (button_index == 1)
            {
                romajiCharacter2 = dictionary[hirakanaCharacter];
            }
            else if (button_index == 2)
            {
                romajiCharacter3 = dictionary[hirakanaCharacter];
            }
            else if (button_index == 3)
            {
                romajiCharacter4 = dictionary[hirakanaCharacter];
            }
            optionButtonSet[button_index] = true;

            int romaji_index = random.Next(englishText.Count);
            if (optionButtonSet[0] == false)
            {
                romajiCharacter1 = englishText[romaji_index];
                buttons[0].Content = romajiCharacter1;
                optionButtonSet[0] = true;
            }

            if (optionButtonSet[1] == false)
            {
                romaji_index = random.Next(englishText.Count);
                romajiCharacter2 = englishText[romaji_index];
                while (romajiCharacter2.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter2.Equals(romajiCharacter3, StringComparison.Ordinal) || romajiCharacter2.Equals(romajiCharacter4, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(englishText.Count);
                    romajiCharacter2 = englishText[romaji_index];
                }
                buttons[1].Content = romajiCharacter2;
                optionButtonSet[1] = true;
            }

            if (optionButtonSet[2] == false)
            {
                romaji_index = random.Next(englishText.Count);
                romajiCharacter3 = englishText[romaji_index];
                while (romajiCharacter3.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter3.Equals(romajiCharacter2, StringComparison.Ordinal) || romajiCharacter3.Equals(romajiCharacter4, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(englishText.Count);
                    romajiCharacter3 = englishText[romaji_index];
                }
                buttons[2].Content = romajiCharacter3;
                optionButtonSet[2] = true;
            }

            if (optionButtonSet[3] == false)
            {
                romaji_index = random.Next(englishText.Count);
                romajiCharacter4 = englishText[romaji_index];
                while (romajiCharacter4.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter4.Equals(romajiCharacter2, StringComparison.Ordinal) || romajiCharacter4.Equals(romajiCharacter3, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(englishText.Count);
                    romajiCharacter4 = englishText[romaji_index];
                }
                buttons[3].Content = romajiCharacter4;
                optionButtonSet[3] = true;
            }
            string[] buttonText = new string[] { romajiCharacter1, romajiCharacter2, romajiCharacter3, romajiCharacter4 };
            return buttonText;

        }

        public string GetScore(string romajiCharacter)
        {
            if (romajiCharacter.Equals(dictionary[hirakanaCharacter], StringComparison.Ordinal))
            {
                correct++;
                return "c" + correct.ToString();
            }
            else
            {
                incorrect++;
                return "i" + incorrect.ToString();
            }
        }

        public void ResetButtonSet()
        {
            for (int i = 0; i < optionButtonSet.Length; i++)
            {
                optionButtonSet[i] = false;
            }
        }
    }
}
