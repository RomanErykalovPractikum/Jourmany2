using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrBolt : MonoBehaviour
{
    public CharacterQuestion DrBoltQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
