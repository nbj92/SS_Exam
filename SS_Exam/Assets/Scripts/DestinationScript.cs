using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DestinationScript : MonoBehaviour {
    public GameObject menuPanel; // Reference to the UI panel
    public TMP_Dropdown destinationDropdown; // Reference to the Dropdown

    void Start() {
        menuPanel.SetActive(false); // Ensure the menu is initially hidden
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            menuPanel.SetActive(true); // Show the menu when the teleporter is clicked
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && menuPanel.activeSelf) // Check for Escape key press and if the menu is open
        {
            CloseMenu(); // Close the menu
        }
    }

    public void CloseMenu() {
        menuPanel.SetActive(false); // Hide the menu
    }

    public void TeleportToDestination() {
        string selectedDestination = destinationDropdown.options[destinationDropdown.value].text;
        // Implement your teleportation logic here
        Debug.Log("Teleporting to " + selectedDestination);
        CloseMenu();
    }

    public void OnDropdownValueChanged(int index) {
        TeleportToDestination(); // Call the teleport method when the dropdown value changes
    }
}
