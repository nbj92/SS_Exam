using System;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    //public GameObject go;
    public GameObject btnCircle;
    public GameObject btnInfo;
    public CanvasGroup cg;
    private Rigidbody2D playerRB;
    private bool fadeIn = false;
    private bool fadeOut = false;


    private void Start()
    {
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    //public void ToggleTooltip()
    //{        
    //    if (!fadeIn && cg.alpha <= 0)
    //    {
    //        fadeIn = true;
    //        Debug.Log(fadeIn);
    //    } else if(!fadeOut && cg.alpha >= 1)
    //    {
    //        fadeOut = true;
    //        Debug.Log(fadeOut);
    //    }
    //}

    //private void Update()
    //{

    //    if (btnCircle.activeSelf && Input.GetKeyDown(KeyCode.X))
    //    {
    //        ToggleTooltip();
    //        playerRB.constraints = playerRB.constraints == RigidbodyConstraints2D.FreezePosition ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.FreezePosition;   
    //    }

    //    if (fadeIn)
    //    {
    //        if(cg.alpha < 1)
    //        {
    //            cg.alpha += 2*Time.deltaTime;
    //            if(cg.alpha >= 1)
    //            {
    //                cg.interactable = true;
    //                fadeIn = false;
    //            }
    //        }
    //    }
    //    else if (fadeOut)
    //    {
    //        if (cg.alpha >= 0)
    //        {
    //            cg.alpha -= 2*Time.deltaTime;
    //            if (cg.alpha <= 0)
    //            {
    //                cg.interactable = false;
    //                fadeOut = false;
    //            }
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    btnCircle.SetActive(true);
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    btnCircle.SetActive(false);
    //}

    private void OnMouseOver()
    {
        btnInfo.SetActive(true);
    }

    private void OnMouseExit()
    {
        btnInfo.SetActive(false);
    }
}
