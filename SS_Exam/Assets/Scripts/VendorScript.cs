using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VendorScript : MonoBehaviour {
    public GameObject menuPanel; 
    public TMP_Dropdown vendorDropdown; 

    void Start() {
        menuPanel.SetActive(false); 

        
        vendorDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

       
        InitializeDropdown();
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) 
        {
            menuPanel.SetActive(true); 
            ResetDropdown();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.V) && menuPanel.activeSelf) 
        {
            CloseMenu(); 
        }
    }

    public void CloseMenu() {
        menuPanel.SetActive(false); 
    }

    public void BuyItem(string itemName) {
        
        //Debug.Log("Buying " + itemName);
        CloseMenu();
    }

    public void OnDropdownValueChanged(int index) {
        string selectedItem = vendorDropdown.options[index].text;
        if (selectedItem != "Equipment to Buy") {
            BuyItem(selectedItem); 
        }
    }

    private void InitializeDropdown() {
        
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
        vendorDropdown.value = 0;
        vendorDropdown.RefreshShownValue(); 
    }
}
