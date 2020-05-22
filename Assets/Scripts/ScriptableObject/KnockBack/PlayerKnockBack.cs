using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AKnockBack/PlayerKnockBack")]
public class PlayerKnockBack : AKnockBack
{
    public float _knockTime;

    public override IEnumerator KnockCo(AUnit target, float knockTime)
    {
        var obj = target.GetComponent<Player>();
        var hit = obj.GetComponent<Rigidbody2D>();
        if (hit != null)
        {
            yield return new WaitForSeconds(Mathf.Max(_knockTime, knockTime));
            hit.velocity = Vector2.zero;
            obj.currentState = PlayerState.idle;
            hit.velocity = Vector2.zero;
        }
    }
}
