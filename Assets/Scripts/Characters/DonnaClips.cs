using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonnaClips : MonoBehaviour
{
    public CharacterQuestion DonnaClipsQuestion()
    {
        return new CharacterQuestion(this.name);
    }
}
