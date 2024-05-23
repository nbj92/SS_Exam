using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VendorScript : MonoBehaviour {
    public GameObject menuPanel; // Reference to the UI panel
    public TMP_Dropdown vendorDropdown; // Reference to the Dropdown

    void Start() {
        menuPanel.SetActive(false); // Ensure the menu is initially hidden

        // Add listener for when the dropdown value is changed
        vendorDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Initialize dropdown
        InitializeDropdown();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            menuPanel.SetActive(true); // Show the menu when the vendor machine is clicked
            ResetDropdown();
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

    public void BuyItem(string itemName) {
        // Implement your item purchasing logic here
        Debug.Log("Buying " + itemName);
        CloseMenu();
    }

    public void OnDropdownValueChanged(int index) {
        string selectedItem = vendorDropdown.options[index].text;
        if (selectedItem != "Equipment to Buy") {
            BuyItem(selectedItem); // Call the purchase method when an item is selected
        }
    }

    private void InitializeDropdown() {
        // Add a placeholder option at the beginning
        if (vendorDropdown.options.Count == 0) {
            TMP_Dropdown.OptionData placeholder = new TMP_Dropdown.OptionData("Equipment to Buy");
            vendorDropdown.options.Add(placeholder);

            List<string> items = new List<string> { "Catching Net (5g)", "Sling Shot (10g)", "Stun Gun (15g)" };

            foreach (string item in items) {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(item);
                vendorDropdown.options.Add(option);
            }
        }
    }

    private void ResetDropdown() {
        vendorDropdown.value = 0; // Set to the placeholder option
        vendorDropdown.RefreshShownValue(); // Refresh to show the correct value
    }
}
