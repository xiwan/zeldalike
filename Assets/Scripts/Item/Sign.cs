using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    public string dialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            UISign.Instance.Display(dialog);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2DCall(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2DCall(other);
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            UISign.Instance.textObject.SetActive(false);
        }
    }
}
