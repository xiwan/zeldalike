using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AUnit : MonoBehaviour
{
    public FloatValue maxHealth;
    public AKnockBack knockBack;
    public Signal healthSignal;

    public abstract void Knock(float knockTime, float damage);

    protected bool TakeDamage(float damage)
    {
        maxHealth.runtimeValue -= damage;
        healthSignal.Raise();
        if (maxHealth.runtimeValue <= 0)
        {
            this.gameObject.SetActive(false);
        }
        return this.gameObject.activeInHierarchy;
    }
}
