using Assets.Scripts.Alternativ;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Assets.Scripts
{
    public class Item_2 : MonoBehaviour
    {

        private Color color;
        public float size = 1;
        public GameObject sprite;
        public Animal_2 Animal { get; set; }


        
        private void Start()
        {
            SpriteRenderer sr = sprite.GetComponent<SpriteRenderer>();
            sprite.transform.localScale = new Vector3(size, size, 1f);

            if (size == 1)
            {
                color = new Color32(22, 25, 201, 255);
                sr.color = color;
                //Debug.Log("size : 1");
            }
            else if (size == 2)
            {
                color = new Color32(161, 28, 34, 255);
                sr.color = color;
                
                //Debug.Log("size : 2");
                
                
                //Debug.Log("Color: " + color);
            } else
            {
                color = new Color32(22, 25, 201, 255);
                sr.color = color;
                
                //Debug.Log("size : NOT 1 OR 2");
            }
            int animalCount = GameManager.instance.GetAnimals().Count;
            Animal = new Animal_2("Amoebe_"+animalCount, size, color);
            Debug.Log("Ani_Size: " + Animal.size);
            GameManager.instance.AddAnimal(Animal);

        }
        private void OnMouseDown()
        {
            PlayerMovement_2 playerMovement = FindObjectOfType<PlayerMovement_2>();
            if (playerMovement != null)
            {
                float distance = Vector2.Distance(playerMovement.transform.position, transform.position);
                if (distance <= playerMovement.maxPickupDropDistance)
                {
                    playerMovement.PickUpItem(this);
                    //Debug.Log("Close enough.");
                }
                else
                {
                    Debug.Log("Item is too far away to pick up.");
                }
            }
        }
    }
}