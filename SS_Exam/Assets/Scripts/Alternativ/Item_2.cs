using Assets.Scripts.Alternativ;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Assets.Scripts
{
    public class Item_2 : MonoBehaviour
    {

        public Color color;
        public float size;
        public GameObject sprite;
        public Animal_2 Animal { get; set; }

        private void Start()
        {
            int animalCount = GameManager.instance.GetAnimals().Count;
            //Debug.Log("Color: " + color);
            //Debug.Log("Animal_size: " + Animal);
            if (Animal == null)
            {
                if (size == 1f)
                {
                    color = new Color(22 / 255f, 25 / 255f, 201 / 255f, 1f);
                }
                else if (size == 2f)
                {
                    color = new Color(161 / 255.0f, 28 / 255.0f, 34 / 255.0f, 1.0f); //new Color(161f, 28f, 34f, 255f);
                    //Debug.Log("Size 2 color: " + color);
                }
                
                Animal = new Animal_2("Amoebe_" + animalCount, size, color);
            }

            
            SpriteRenderer sr = sprite.GetComponent<SpriteRenderer>();
            sprite.transform.localScale = new Vector3((float)Animal.size, (float)Animal.size, 1f);

            sr.color = Animal.Color;
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
                }
                else
                {
                    Debug.Log("Item is too far away to pick up.");
                }
            }
        }
    }
}