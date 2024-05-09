using UnityEngine;

namespace Assets.Scripts {
    public class Item : MonoBehaviour {
        public string itemName;
        public int quantity = 1;

        private void OnMouseDown() {
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null) {
                float distance = Vector2.Distance(playerMovement.transform.position, transform.position);
                if (distance <= playerMovement.maxPickupDropDistance) {
                    playerMovement.PickUpItem(this);
                } else {
                    Debug.Log("Item is too far away to pick up.");
                }
            }
        }
    }
}
