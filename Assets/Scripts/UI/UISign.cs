using Rui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UISign : SingletonMonoBehaviour<UISign>, UIInterface
{
    public GameObject textObject;
    public Text text;

    public void Display(string content) 
    {
        if (textObject.activeInHierarchy)
        {
            textObject.SetActive(false);
        }
        else
        {
            textObject.SetActive(true);
            text.text = content;
        }
    }

} 
