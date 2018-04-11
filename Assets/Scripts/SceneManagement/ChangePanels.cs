using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanels : MonoBehaviour
{

    [SerializeField]
    private GameObject closingPanel;
    [SerializeField]
    private GameObject openingPanel;

    public void Show()
    {
        closingPanel.SetActive(!closingPanel.active);
        openingPanel.SetActive(!openingPanel.active);
    }
}