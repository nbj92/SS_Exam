using Inv = Assets.Scripts.Inventory;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Inventory;
using static UnityEditor.Progress;
using Assets.Scripts.Alternativ;
using System;
using Unity.VisualScripting;


namespace Assets.Scripts
{
    public class PlayerMovement_2 : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5;
        public float maxPickupDropDistance = 0.5f;
        private float xInput;
        private float yInput;

        private Vector2 moveDirection;

        private Rigidbody2D rb;
        private Animator animator;
        private Transform playerSpriteTransform;

        public List<Animal_2> inventory = new List<Animal_2>();
        public int inventorySize = 4;

        public GameObject prefab;
        // Start is called before the first frame update
        void Start()
        {

            PlayerPrefs.DeleteAll();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            // Reference the PlayerSprite child GameObject
            playerSpriteTransform = transform.Find("SpriteRnd");
            Debug.Log(PlayerPrefs.GetInt("InventoryCount"));

            if(PlayerPrefs.HasKey("InventoryCount"))
            {
                int count = PlayerPrefs.GetInt("InventoryCount");
                Debug.Log("We have playerPrefs");
                Debug.Log("Inventory Count: " + count);
                for(int i=0; i<count; i++)
                {
                    Animal_2 animal = JsonUtility.FromJson<Animal_2>(PlayerPrefs.GetString("Amoebe_" + i));
                    inventory.Add(animal);
                    Debug.Log("Animale_size: "+animal.size);
                    Debug.Log("Animale_size: " + animal.Color);

                }
                PlayerPrefs.DeleteKey("InventoryCount");
                Debug.Log("Inventorytory: " + inventory.Count);
            } else
            {
                Debug.Log("No Prefs");
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            GetInput();

            if (Input.GetMouseButtonDown(1)) // Right mouse button
            {
                DropItem();
            }
        }

        private void FixedUpdate()
        {
            Movement();
        }

        void GetInput()
        {
            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
        }

        void Movement()
        {
            moveDirection = new Vector2(xInput, yInput).normalized;
            rb.velocity = moveDirection * moveSpeed;

            animator.SetFloat("Speed", moveDirection.magnitude);

            if (moveDirection.x > 0)
            {
                playerSpriteTransform.localScale = new Vector3(1, 1, 1); // Facing right
            }
            else if (moveDirection.x < 0)
            {
                playerSpriteTransform.localScale = new Vector3(-1, 1, 1); // Facing left
            }
        }


        public void PickUpItem(Item_2 item)
        {
            Animal_2 amoebe = item.Animal;
                
                AudioManager.instance.PlayPickupSound();
            //Debug.Log($"Added {item.quantity} {item.itemName}. Total: {inventory.GetItems().Find(i => i.itemName == item.itemName).quantity}");


            //Debug.Log()

            inventory.Add(amoebe);
            GameManager.instance.RemoveAnimal(amoebe);

            //if (inventory.Count > 0)
            //    Debug.Log(inventory[^1]);

            //GameObject child = transform.GetChild(0).gameObject;
            
            //Debug.Log(child);


            //PlayerPrefs.SetString("Amoebe_" + (inventory.Count - 1) + "_AnimalName", amoebe.AnimalName);
            //PlayerPrefs.SetFloat("Amoebe_" + (inventory.Count - 1) + "_Size", amoebe.Size);
            //PlayerPrefs.SetString("Amoebe_" + (inventory.Count - 1) + "_Color", amoebe.Color.ToString());
            Debug.Log("Inventory Count: "+inventory.Count);
            PlayerPrefs.SetString("Amoebe_" + (inventory.Count - 1), JsonUtility.ToJson(amoebe));

            
                PlayerPrefs.SetInt("InventoryCount", inventory.Count);
                PlayerPrefs.Save();
            
            //else
            //{
            //    PlayerPrefs.DeleteKey("InventoryCount");
            //}

            Destroy(item.gameObject); // Remove the item from the scene
           
        }

        void DropItem()
        {
            if (inventory.Count > 0)
            {
                Vector2 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float distance = Vector2.Distance(transform.position, dropPosition);

                if (distance <= maxPickupDropDistance)
                {
                    Animal_2 animal = inventory[^1];
                    //GameManager.instance.AddAnimal(animal);
                    inventory.RemoveAt(inventory.Count-1);


                    //GameObject go = prefab;
                    //GameObject child = go.transform.GetChild(0).gameObject;
                    //SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
                    //sr.color = animal.Color;

                    //Debug.Log(animal.Color);
                    //Debug.Log(animal.Size);
                    //go.GetComponent<Item_2>().size = (float)animal.size;
                    //Debug.Log("ANIMAL DROP: "+animal.size);

                    GameObject droppedItem = Instantiate(prefab, dropPosition, Quaternion.identity);
                    droppedItem.GetComponent<Item_2>().color = animal.Color;
                    droppedItem.GetComponent<Item_2>().size = (float)animal.size;
                    //GameObject child = droppedItem.transform.GetChild(0).gameObject;
                    //SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
                    //sr.color = animal.Color;
                    //Debug.Log(animal.Color);
                    //Debug.Log(animal.Size);
                    //droppedItem.GetComponent<Item_2>().size = animal.Size;
                    AudioManager.instance.PlayDropSound();
                    //if (inventory.Count > 0)
                    //        Debug.Log(inventory[^1]);

                    PlayerPrefs.DeleteKey("Amoebe_" + (inventory.Count - 1));

                    if (inventory.Count > 0)
                    {
                        PlayerPrefs.SetInt("InventoryCount", inventory.Count);
                        PlayerPrefs.Save();
                    } else
                    {
                        PlayerPrefs.DeleteKey("InventoryCount");
                    }
                    

                    //Debug.Log($"Dropped {inventory[^1].itemName} at {dropPosition}");
                }
            }
            else
            {
                Debug.Log("Cannot drop item too far away.");
            }
        }
    }
}

