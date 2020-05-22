using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : AUnit
{
    public EnemyState currentState;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public override void Knock(float knockTime, float damage)
    {
        if (TakeDamage(damage))
        {
            currentState = EnemyState.stagger;
            StartCoroutine(knockBack.KnockCo(this, knockTime));
        }
    }

}
