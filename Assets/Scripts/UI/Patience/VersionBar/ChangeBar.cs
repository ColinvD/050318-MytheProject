using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBar : MonoBehaviour {

    [SerializeField]
    private RectTransform fill;
    [SerializeField]
    private Slider slider;

    public void ChangeBarWidth()
    {
        if (slider.value == 0)
        {
            fill.rect.Set(fill.rect.x, fill.rect.y, 0, fill.rect.height);
        }
        else
        {
            fill.rect.Set(fill.rect.x, fill.rect.y, 20, fill.rect.height);
        }
    }

}
