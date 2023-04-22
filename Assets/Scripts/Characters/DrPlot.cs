using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Putin;

public class DrPlotCharacter : Character
{
    public DrPlotCharacter() : base("Dr Plot", "Scientist", 3) { }

    public override CharacterQuestion Question()
    {
        return new CharacterQuestion("DrPlotCharacter");
    }
}

public class DrPlot : MonoBehaviour { }
