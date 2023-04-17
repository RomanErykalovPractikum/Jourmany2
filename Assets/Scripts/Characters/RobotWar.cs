using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class RobotWar : MonoBehaviour
{
    public CharacterQuestion RobotWarQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
