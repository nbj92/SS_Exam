using UnityEngine;

namespace Assets.Scripts {
    public class Item : MonoBehaviour {
        public string itemName;
        public int quantity = 1;

        private void OnMouseDown() {
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null) {
                playerMovement.PickUpItem(this);
            }
        }
    }
}
