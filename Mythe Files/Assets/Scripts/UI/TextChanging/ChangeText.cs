using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public void Change(string text)
    {
        gameObject.GetComponent<Text>().text = text;
    }
}
