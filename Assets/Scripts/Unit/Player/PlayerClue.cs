using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClue : MonoBehaviour
{
    public GameObject clue;

    public void Enable()
    {
        clue.SetActive(true);
    }

    public void Disable()
    {
        clue.SetActive(false);
    }
}
