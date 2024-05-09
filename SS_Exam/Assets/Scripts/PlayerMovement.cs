using Inv = Assets.Scripts.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts; // Ensure this is here to access the Item class

namespace Assets.Scripts {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField]
        private float moveSpeed = 5;

        private float xInput;
        private float yInput;

        private Vector2 moveDirection;

        private Rigidbody2D rb;
        private Animator animator;

        private Inv.Inventory inventory;

        public GameObject itemPrefab;

        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            inventory = new Inv.Inventory();
        }

        // Update is called once per frame
        void Update() {
            GetInput();

            if (Input.GetMouseButtonDown(1)) // Right mouse button
            {
                DropItem();
            }
        }

        private void FixedUpdate() {
            Movement();
        }

        void GetInput() {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }

        void Movement() {
            moveDirection = new Vector2(xInput, yInput).normalized;
            rb.velocity = moveDirection * moveSpeed;

            animator.SetFloat("Speed", moveDirection.magnitude);

            if (moveDirection.x > 0) {
                transform.localScale = new Vector3(1, 1, 1); // Facing right
            } else if (moveDirection.x < 0) {
                transform.localScale = new Vector3(-1, 1, 1); // Facing left
            }
        }

        public void PickUpItem(Item item) {
            inventory.AddItem(item.itemName, item.quantity);
            Debug.Log($"Added {item.quantity} {item.itemName}. Total: {inventory.GetItems().Find(i => i.itemName == item.itemName).quantity}");
            Destroy(item.gameObject); // Remove the item from the scene
        }

        void DropItem() {
            if (inventory.GetItems().Count > 0) {
                Inv.InventoryItem inventoryItem = inventory.GetItems()[0]; // Get the first item in the inventory for simplicity
                inventory.RemoveItem(inventoryItem.itemName, 1);

                Vector2 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Check if itemPrefab is assigned
                if (itemPrefab != null) {
                    GameObject droppedItem = Instantiate(itemPrefab, dropPosition, Quaternion.identity);
                    Item itemComponent = droppedItem.GetComponent<Item>();
                    itemComponent.itemName = inventoryItem.itemName;
                    itemComponent.quantity = 1;

                    Debug.Log($"Dropped {inventoryItem.itemName} at {dropPosition}");
                } else {
                    Debug.LogError("Item prefab is not assigned!");
                }
            }
        }


    }
}
