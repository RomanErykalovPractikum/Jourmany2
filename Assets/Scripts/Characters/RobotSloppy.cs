using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class RobotSloppy : MonoBehaviour
{
    public CharacterQuestion RobotSloppyQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
