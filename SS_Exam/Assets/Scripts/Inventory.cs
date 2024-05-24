using System;
using System.Collections.Generic;

namespace Assets.Scripts.Inventory {

    [Serializable]
    public class Inventory {
        private List<InventoryItem> items;

        public Inventory() {
            items = new List<InventoryItem>();
        }

        public void AddItem(string itemName, int quantity)
        {
            InventoryItem item = items.Find(i => i.itemName == itemName);
            if (item != null)
            {
                item.quantity += quantity;
            }
            else
            {
                items.Add(new InventoryItem(itemName, quantity));
            }
        }

        public void RemoveItem(string itemName, int quantity)
        {
            InventoryItem item = items.Find(i => i.itemName == itemName);
            if (item != null)
            {
                item.quantity -= quantity;
                if (item.quantity <= 0)
                {
                    items.Remove(item);
                }
            }
        }



        public List<InventoryItem> GetItems() {
            return items;
        }
    }
}
