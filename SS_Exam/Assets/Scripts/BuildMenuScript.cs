using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildMenuScript : MonoBehaviour {
    public GameObject buildMenuPanel; // Reference to the Build Menu panel

    void Start() {
        buildMenuPanel.SetActive(false); // Ensure the build menu is initially hidden
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.B)) // Detect B key press
        {
            ToggleBuildMenu(); // Toggle the build menu visibility
        }
    }

    public void ToggleBuildMenu() {
        buildMenuPanel.SetActive(!buildMenuPanel.activeSelf); // Toggle the menu visibility
    }

    public void BuildItem(string itemName) {
        // Implement your building logic here
        Debug.Log("Building " + itemName);
        ToggleBuildMenu(); // Close the menu after building
    }
}
