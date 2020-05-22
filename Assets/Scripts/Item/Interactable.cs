using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal clueOn;
    public Signal clueOff;
    public bool inRange;

    public virtual void OnTriggerEnter2DCall(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clueOn.Raise();
            inRange = true;
        }
    }

    public virtual void OnTriggerExit2DCall(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clueOff.Raise();
            inRange = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter2DCall(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        OnTriggerExit2DCall(other);
    }
}
