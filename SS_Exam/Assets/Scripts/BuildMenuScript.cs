using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildMenuScript : MonoBehaviour {
    public GameObject buildMenuPanel; 

    void Start() {
        buildMenuPanel.SetActive(false); 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.B) && UIManager.Instance.activeGroup == UIManager.Instance.labGroup) 
        {
            ToggleBuildMenu(); 
        }
    }

    public void ToggleBuildMenu() {
        buildMenuPanel.SetActive(!buildMenuPanel.activeSelf); 
    }

    public void BuildItem(string itemName) {
       
        Debug.Log("Building " + itemName);
        ToggleBuildMenu(); 
    }
}
