using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DestinationScript : MonoBehaviour {
    public GameObject menuPanel; 
    public TMP_Dropdown destinationDropdown; 

    void Start() {
        menuPanel.SetActive(false); 
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) 
        {
            menuPanel.SetActive(true); 
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.activeSelf) 
        {
            CloseMenu(); 
        }
    }

    public void CloseMenu() {
        menuPanel.SetActive(false); 
    }

    public void TeleportToDestination() {
        string selectedDestination = destinationDropdown.options[destinationDropdown.value].text;
        
        Debug.Log("Teleporting to " + selectedDestination);
        CloseMenu();
    }

    public void OnDropdownValueChanged(int index) {
        TeleportToDestination(); 
    }
}
