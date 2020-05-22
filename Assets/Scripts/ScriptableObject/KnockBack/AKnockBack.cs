using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AKnockBack : ScriptableObject
{
    public abstract IEnumerator KnockCo(AUnit target, float knockTime);
}


