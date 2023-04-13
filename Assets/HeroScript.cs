using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public string Question(int heroNumber)
    {
        switch (heroNumber)
        {
            case 0://Lepry
                return "LEPRY PERY give you maney!";

            case 1://Ninja
                return "NINJA............NINJA";
    
            case 2://Dark
                return "Hello I am DARK DARK DARK!";

            default:
                return "Vse po pizde poshlo";


        }

    }

    public string Answer(int heroNumber, bool answer)
    {
        switch (heroNumber)
        {
            case 0://Lepry
                if (answer) return "LEPRY очень доволено отетом ДА!"; else return "LEPRY зол и рассержен ведь ты сказал НЕТ";


            case 1://Ninja
                if (answer) return "NINJA uhhuuuuu YES"; else return "NINJA :( :(: :{ NOOOO";


            case 2://Dark
                if (answer) return "DARK is ready for YES always"; else return "А не прихуел ли ты отвечть мне NO?";


            default:
                return "Vse po pizde poshlo";


        }

    }

}