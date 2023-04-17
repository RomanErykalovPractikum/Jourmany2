using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonSand : MonoBehaviour
{
    public CharacterQuestion DonSandQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
