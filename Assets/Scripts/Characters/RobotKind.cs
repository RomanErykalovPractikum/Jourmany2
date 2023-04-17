using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class RobotKind : MonoBehaviour
{
    public CharacterQuestion RobotKindQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
