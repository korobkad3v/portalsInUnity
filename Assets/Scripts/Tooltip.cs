using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;
    public float displayTime = 10f;
    public Camera mainCamera;

    private void Start()
    {
        HideTooltip();
        mainCamera = Camera.main;
    }

    public void ShowTooltip(string text)
    {
        gameObject.SetActive(true);
        tooltipText.text = text;
        Invoke("HideTooltip", displayTime);
    }


    public void HideTooltip()
    {

        gameObject.SetActive(false);
    }
}
