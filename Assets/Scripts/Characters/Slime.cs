using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class Slime : MonoBehaviour
{
    public CharacterQuestion SlimeQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
