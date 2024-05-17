using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingMachine : MonoBehaviour
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
            // Move the placed animal to be a child of the breeding machine
            animal.transform.SetParent(transform);

            Debug.Log("Animal placed in the machine: " + animal.name);
        }
        else
        {
            // Breed the animals inside the machine
            Debug.Log("Breeding animals: " + animalsInside[0].name + " and " + animalsInside[1].name);
            BreedAnimals(animalsInside[0], animalsInside[1]);

            // Remove the animals from the machine
            Destroy(animalsInside[0].gameObject);
            Destroy(animalsInside[1].gameObject);

            // Move the new animal to be a child of the breeding machine
            animal.transform.SetParent(transform);

            // Reset the position of the placed animal within the machine
            animal.transform.localPosition = Vector3.zero;
            Debug.Log("New animal placed in the machine: " + animal.name);
        }
    }

    // Method to breed two animals inside the machine
    private void BreedAnimals(Animals parentA, Animals parentB)
    {
        // Call the BreedAnimals method from the AnimalGenetics script
        GameObject offspring = animalGenetics.BreedAnimals(parentA, parentB);
        Debug.Log("Offspring created: " + offspring.name);

        // Optionally, you can place the offspring somewhere in your scene
        offspring.transform.position = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D other)
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
}
