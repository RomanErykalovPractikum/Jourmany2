using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class HeroScript : MonoBehaviour
{

    public CharacterQuestion Question(int heroNumber)
    {
        switch (heroNumber)
        {
            case 0: return GameObject.Find("RobotKind").GetComponent<RobotKind>().RobotKindQuestion(); 
            case 1: return GameObject.Find("RobotSloppy").GetComponent<RobotSloppy>().RobotSloppyQuestion();
            case 2: return GameObject.Find("RobotWar").GetComponent<RobotWar>().RobotWarQuestion();
            case 3: return GameObject.Find("PetCat").GetComponent<PetCat>().PetCatQuestion();
            case 4: return GameObject.Find("PetDog").GetComponent<PetDog>().PetDogQuestion();
            case 5: return GameObject.Find("PetCatDog").GetComponent<PetCatDog>().PetCatDogQuestion();
            case 6: return GameObject.Find("DonSnitch").GetComponent<DonSnitch>().DonSnitchQuestion();
            case 7: return GameObject.Find("DonSand").GetComponent<DonSand>().DonSandQuestion();
            case 8: return GameObject.Find("DonnaClips").GetComponent<DonnaClips>().DonnaClipsQuestion();
            case 9: return GameObject.Find("MrLee").GetComponent<MrLee>().MrLeeQuestion();
            case 10: return GameObject.Find("MrsRight").GetComponent<MrsRight>().MrsRightQuestion();
            case 11: return GameObject.Find("MrHubris").GetComponent<MrHubris>().MrHubrisQuestion();
            case 12: return GameObject.Find("Reptilian").GetComponent<Reptilian>().ReptilianQuestion();
            case 13: return GameObject.Find("Slime").GetComponent<Slime>().SlimeQuestion();
            case 14: return GameObject.Find("Kraken").GetComponent<Kraken>().KrakenQuestion();
            case 15: return GameObject.Find("DrPiff").GetComponent<DrPiff>().DrPiffQuestion();
            case 16: return GameObject.Find("DrBolt").GetComponent<DrBolt>().DrBoltQuestion();
            case 17: return GameObject.Find("DrPlot").GetComponent<DrPlot>().DrPlotQuestion();
           
            default:
                return new CharacterQuestion("Vse po pizde poshlo");

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