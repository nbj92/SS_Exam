using System;

namespace Assets.Scripts.Inventory {
    [Serializable]
    public class InventoryItem {
        public string itemName;
        public int quantity;

        public InventoryItem(string name, int qty) {
            itemName = name;
            quantity = qty;
        }
    }
}
