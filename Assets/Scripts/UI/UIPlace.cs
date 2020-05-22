using Rui.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlace : SingletonMonoBehaviour<UIPlace>, UIInterface
{
    public GameObject textObject;
    public Text text;

    public void Display(string content)
    {
        StartCoroutine(DisplayGo(content));
    }
    public IEnumerator DisplayGo(string content)
    {
        textObject.SetActive(true);
        text.text = content;
        yield return new WaitForSeconds(4f);
        textObject.SetActive(false);
    }
}
