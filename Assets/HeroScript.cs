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
                break;

            case 1://Ninja
                return "NINJA............NINJA";
                break;

            case 2://Dark
                return "Hello I am DARK DARK DARK!";
                break;

            default:
                return "Vse po pizde poshlo";
                break;

        }

    }

    public string Question(int heroNumber)
    {
        switch (heroNumber)
        {
            case 0://Lepry
                return "LEPRY PERY give you maney!";
                break;

            case 1://Ninja
                return "NINJA............NINJA";
                break;

            case 2://Dark
                return "Hello I am DARK DARK DARK!";
                break;

            default:
                return "Vse po pizde poshlo";
                break;

        }

    }

}