using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public GameObject transporter;
    public CanvasGroup lab;
    public CanvasGroup island;


    void Update()
    {
        //GameManager.instance.active =
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Transporter"))
        {
            Debug.Log("Transporter detected.");

            if ( lab.alpha == 1 )
            {
                Debug.Log("Deactivating lab, activating island.");
                SetCanvasGroupActive(lab, false);
                SetCanvasGroupActive(island, true);
            }
            else if ( island.alpha == 1 )
            {
                Debug.Log("Deactivating island, activating lab.");
                SetCanvasGroupActive(island, false);
                SetCanvasGroupActive(lab, true);
            }
        }

    }

    private void SetCanvasGroupActive(CanvasGroup canvasGroup, bool isActive)
    {
        canvasGroup.alpha = isActive ? 1 : 0;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
        Debug.Log(canvasGroup.name + " set to " + ( isActive ? "active" : "inactive" ));

        // Manually set the active state of all child objects
        foreach ( Transform child in canvasGroup.transform )
        {
            child.gameObject.SetActive(isActive);
            Debug.Log("Child " + child.name + " set to " + ( isActive ? "active" : "inactive" ));
        }
    }

}
