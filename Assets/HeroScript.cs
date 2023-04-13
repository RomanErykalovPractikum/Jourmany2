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
                return LepryQuestion();

            case 1://Ninja
                return NinjaQuestion();
    
            case 2://Dark
                return DarkQuestion();

            default:
                return "Vse po pizde poshlo";


        }

    }

    string LepryQuestion()
    {
        return "LEPRY PERY give you maney!";
    }

    string NinjaQuestion()
    {
        return "NINJA............NINJA";
    }

    string DarkQuestion()
    {
        return "Hello I am DARK DARK DARK!";
    }



    public string Answer(int heroNumber, bool answer)
    {
        switch (heroNumber)
        {
            case 0://Lepry
                if (answer) return "LEPRY ����� �������� ������ ��!"; else return "LEPRY ��� � ��������� ���� �� ������ ���";


            case 1://Ninja
                if (answer) return "NINJA uhhuuuuu YES"; else return "NINJA :( :(: :{ NOOOO";


            case 2://Dark
                if (answer) return "DARK is ready for YES always"; else return "� �� ������� �� �� ������� ��� NO?";


            default:
                return "Vse po pizde poshlo";


        }

    }

}