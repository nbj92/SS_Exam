using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip_Info : MonoBehaviour
{

    private bool fadeIn = false;
    private bool fadeOut = false;
    public CanvasGroup tooltipCG;
    public GameObject tooltipInfoBox;
    public GameObject btnInfo;


    private void Update()
    {
        if (fadeIn)
        {
            if (tooltipCG.alpha < 1)
            {
                tooltipCG.alpha += 2 * Time.deltaTime;
                if (tooltipCG.alpha >= 1)
                {
                    tooltipCG.interactable = true;
                    fadeIn = false;
                }
            }
        }
        else if (fadeOut)
        {
            if (tooltipCG.alpha >= 0)
            {
                tooltipCG.alpha -= 2 * Time.deltaTime;
                if (tooltipCG.alpha <= 0)
                {
                    tooltipCG.interactable = false;
                    fadeOut = false;
                }
                if (tooltipCG.alpha == 0)
                {
                    tooltipInfoBox.SetActive(false);
                }
            }
        }
    }
    private void OnMouseDown()
    {
        
            if (!fadeIn && tooltipCG.alpha <= 0)
            {
                fadeIn = true;
                tooltipInfoBox.SetActive(true);
                Debug.Log(fadeIn);
            }
            else if (!fadeOut && tooltipCG.alpha >= 1)
            {
                fadeOut = true;
                Debug.Log(fadeOut);
            }
        
    }


    private void OnMouseOver()
    {
        btnInfo.SetActive(true);
    }

    private void OnMouseExit()
    {
        if(tooltipCG.alpha < 1)
        btnInfo.SetActive(false);
    }
}
