using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DonnaClipsCharacter : Character
{
    public DonnaClipsCharacter() : base("Donna Clips", "Gold Gloves", 3) { }

    public override CharacterQuestionStruct Question()
    {
        return new CharacterQuestionStruct("DonnaClipsCharacter");
    }
}

public class DonnaClips : MonoBehaviour { }
