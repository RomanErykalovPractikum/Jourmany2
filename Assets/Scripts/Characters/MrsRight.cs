using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class MrsRight : MonoBehaviour
{
    public CharacterQuestion MrsRightQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
