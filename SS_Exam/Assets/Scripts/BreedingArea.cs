using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingArea : MonoBehaviour
{
    // Reference to the AnimalGenetics script
    public AnimalGenetics animalGenetics;

     // Method called when an animal is placed in the machine
    public void PlaceAnimal(Animals animal)
    {
        Animals[] animalsInside = GetComponentsInChildren<Animals>();
        Debug.Log("Number of animals inside: " + animalsInside.Length);

        if ( animalsInside.Length < 2 )
        {
            // Move the placed animal to be a child of the breeding area
            animal.transform.SetParent(transform);

            Debug.Log("Animal placed in the machine: " + animal.name);
        }
        else
        {
            // Breed the animals inside the area
            Debug.Log("Breeding animals: " + animalsInside[0].name + " and " + animalsInside[1].name);
            BreedAnimals(animalsInside[0], animalsInside[1]);

            // Remove the animals from the area
            Destroy(animalsInside[0].gameObject);
            Destroy(animalsInside[1].gameObject);


            // Reset the position of the placed animal within the area
            //animal.transform.localPosition = Vector3.zero;
            

            Debug.Log("New animal placed in the machine: " + animal.name);
        }
    }

    // Method to breed two animals inside the machine
    private void BreedAnimals(Animals parentA, Animals parentB)
    {
        // Call the BreedAnimals method from the AnimalGenetics script
        GameObject offspring = animalGenetics.BreedAnimals(parentA, parentB);
        Debug.Log("Offspring created: " + offspring.name);

        // Determine a position outside the trigger area
        Vector3 outsideTriggerPosition = GetPositionOutsideTriggerArea();

        // Set the offspring's position to the new position
        offspring.transform.position = outsideTriggerPosition;

        // Detach the offspring from the breeding area
        offspring.transform.SetParent(null);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        // Check if the collider belongs to an object with the "Amoebe" tag
        if ( other.CompareTag("Amoebe") )
        {
            Debug.Log("Amoebe detected: " + other.gameObject.name);

            // Get the Animals component from the collider's GameObject
            Animals animal = other.GetComponent<Animals>();
            Debug.Log("Animal component: " + ( animal != null ? animal.name : "null" ));

            // Ensure that the animal component is not null
            if ( animal != null )
            {
                // Place the animal into the machine
                PlaceAnimal(animal);
            }
        }
        else
        {
            Debug.Log("Object is not tagged as Amoebe: " + other.gameObject.tag);
        }
    }

    // Method to get a position outside the trigger area
    private Vector3 GetPositionOutsideTriggerArea()
    {
        // Calculate a random number for position outside the trigger area
        float random = Random.Range(3f, 6f);
        // Distance to place the offspring outside the trigger area
        float offset = random; 
        return transform.position + new Vector3(offset, 0f, 0f);
    }
}
