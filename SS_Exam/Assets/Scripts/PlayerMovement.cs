using Inv = Assets.Scripts.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts; // Ensure this is here to access the Item class

namespace Assets.Scripts {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField]
        private float moveSpeed = 5;

        
        public float maxPickupDropDistance = 0.5f;

        private float xInput;
        private float yInput;

        private Vector2 moveDirection;

        private Rigidbody2D rb;
        private Animator animator;
        private Transform playerSpriteTransform;

        private Inv.Inventory inventory;

        public Dictionary<string, GameObject> itemPrefabs;

        // List of item prefab references for initialization in the Inspector
        [System.Serializable]
        public struct ItemPrefabReference {
            public string itemName;
            public GameObject prefab;
        }

        public ItemPrefabReference[] itemPrefabReferences;

        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody2D>();


            animator = GetComponentInChildren<Animator>();
            // Reference the PlayerSprite child GameObject
            playerSpriteTransform = transform.Find("SpriteRnd");


            inventory = new Inv.Inventory();

            // Initialize the itemPrefabs dictionary
            itemPrefabs = new Dictionary<string, GameObject>();
            foreach (var itemPrefabReference in itemPrefabReferences) {
                itemPrefabs[itemPrefabReference.itemName] = itemPrefabReference.prefab;
            }
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
                playerSpriteTransform.localScale = new Vector3(1, 1, 1); // Facing right
            } else if (moveDirection.x < 0) {
                playerSpriteTransform.localScale = new Vector3(-1, 1, 1); // Facing left
            }
        }


        public void PickUpItem(Item item) {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance <= maxPickupDropDistance) {
                inventory.AddItem(item.itemName, item.quantity);
                if (AudioManager.instance)
                {
                    AudioManager.instance.PlayPickupSound();
                }
                Debug.Log($"Added {item.quantity} {item.itemName}. Total: {inventory.GetItems().Find(i => i.itemName == item.itemName).quantity}");
                Destroy(item.gameObject); // Remove the item from the scene
            } else {
                Debug.Log("Item is too far away to pick up.");
            }
        }

        void DropItem() {
            if (inventory.GetItems().Count > 0) {
                Vector2 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(transform.position, dropPosition);

                if (distance <= maxPickupDropDistance) {
                    Inv.InventoryItem inventoryItem = inventory.GetItems()[0]; // Get the first item in the inventory for simplicity
                    inventory.RemoveItem(inventoryItem.itemName, 1);

                    if (itemPrefabs.TryGetValue(inventoryItem.itemName, out GameObject prefab)) {
                        GameObject droppedItem = Instantiate(prefab, dropPosition, Quaternion.identity);
                        Item itemComponent = droppedItem.GetComponent<Item>();
                        itemComponent.itemName = inventoryItem.itemName;
                        if (AudioManager.instance)
                        {
                            AudioManager.instance.PlayDropSound();
                        }
                        itemComponent.quantity = 1;

                        Debug.Log($"Dropped {inventoryItem.itemName} at {dropPosition}");
                    } else {
                        Debug.LogError($"No prefab found for item: {inventoryItem.itemName}");
                    }
                } else {
                    Debug.Log("Cannot drop item too far away.");
                }
            }
        }


    }
}
