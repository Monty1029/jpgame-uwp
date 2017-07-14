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

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private int correct = 0;
        private int incorrect = 0;

        private string hiraganaCharacter = "";
        private string romajiCharacter1 = "";
        private string romajiCharacter2 = "";
        private string romajiCharacter3 = "";
        private string romajiCharacter4 = "";

        private Button[] buttons = new Button[4];

        private bool[] optionButtonSet = new bool[] { false, false, false, false };

        public HiraKataLogic(Button option1, Button option2, Button option3, Button option4)
        {

            for (int i = 0; i < hiraganaCharacters.Count; i++)
            {
                dictionary.Add(hiraganaCharacters.ElementAt(i), romajiCharacters.ElementAt(i));
            }

            buttons[0] = option1;
            buttons[1] = option2;
            buttons[2] = option3;
            buttons[3] = option4;
        }

        public string GetQuestionText()
        {
            Random random = new Random();
            int hiragana_index = random.Next(hiraganaCharacters.Count);
            hiraganaCharacter = hiraganaCharacters[hiragana_index];
            hiraganaCharacters.RemoveAt(hiragana_index);
            return hiraganaCharacter;
        }

        public string[] GetButtonText()
        {
            Random random = new Random();

            int button_index = random.Next(buttons.Length);
            buttons[button_index].Content = dictionary[hiraganaCharacter];
            if (button_index == 0)
            {
                romajiCharacter1 = dictionary[hiraganaCharacter];
            }
            else if (button_index == 1)
            {
                romajiCharacter2 = dictionary[hiraganaCharacter];
            }
            else if (button_index == 2)
            {
                romajiCharacter3 = dictionary[hiraganaCharacter];
            }
            else if (button_index == 3)
            {
                romajiCharacter4 = dictionary[hiraganaCharacter];
            }
            optionButtonSet[button_index] = true;

            int romaji_index = random.Next(romajiCharacters.Count);
            if (optionButtonSet[0] == false)
            {
                romajiCharacter1 = romajiCharacters[romaji_index];
                buttons[0].Content = romajiCharacter1;
                optionButtonSet[0] = true;
            }

            if (optionButtonSet[1] == false)
            {
                romaji_index = random.Next(romajiCharacters.Count);
                romajiCharacter2 = romajiCharacters[romaji_index];
                while (romajiCharacter2.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter2.Equals(romajiCharacter3, StringComparison.Ordinal) || romajiCharacter2.Equals(romajiCharacter4, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(romajiCharacters.Count);
                    romajiCharacter2 = romajiCharacters[romaji_index];
                }
                buttons[1].Content = romajiCharacter2;
                optionButtonSet[1] = true;
            }

            if (optionButtonSet[2] == false)
            {
                romaji_index = random.Next(romajiCharacters.Count);
                romajiCharacter3 = romajiCharacters[romaji_index];
                while (romajiCharacter3.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter3.Equals(romajiCharacter2, StringComparison.Ordinal) || romajiCharacter3.Equals(romajiCharacter4, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(romajiCharacters.Count);
                    romajiCharacter3 = romajiCharacters[romaji_index];
                }
                buttons[2].Content = romajiCharacter3;
                optionButtonSet[2] = true;
            }

            if (optionButtonSet[3] == false)
            {
                romaji_index = random.Next(romajiCharacters.Count);
                romajiCharacter4 = romajiCharacters[romaji_index];
                while (romajiCharacter4.Equals(romajiCharacter1, StringComparison.Ordinal) || romajiCharacter4.Equals(romajiCharacter2, StringComparison.Ordinal) || romajiCharacter4.Equals(romajiCharacter3, StringComparison.Ordinal))
                {
                    romaji_index = random.Next(romajiCharacters.Count);
                    romajiCharacter4 = romajiCharacters[romaji_index];
                }
                buttons[3].Content = romajiCharacter4;
                optionButtonSet[3] = true;
            }
            string[] buttonText = new string[] { romajiCharacter1, romajiCharacter2, romajiCharacter3, romajiCharacter4 };
            return buttonText;

        }

        public string GetScore(string romajiCharacter)
        {
            if (romajiCharacter.Equals(dictionary[hiraganaCharacter], StringComparison.Ordinal))
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
