using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonSnitch : MonoBehaviour
{
    public CharacterQuestion DonSnitchQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
