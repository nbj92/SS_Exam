using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingArea : MonoBehaviour
{
    // Reference to the AnimalGenetics script
    public AnimalGenetics animalGenetics;

    public GameManager gameManager;

    // List to track animals inside the breeding area
    private List<Animals> animalsInside = new List<Animals>();


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

        if (gameManager != null)
        {
            //add point based on the animal tag
            if ( offspring.CompareTag("Amoebe") )
            {
                // Add a point to the score using the game manager
                gameManager.AddScore(2);
            }
        }

        // Set the offspring's position to the new position
        offspring.transform.position = outsideTriggerPosition;

        // Detach the offspring from the breeding area
        offspring.transform.SetParent(null);
    }

    private IEnumerator BreedAnimalsCoroutine()
    {
        yield return new WaitForEndOfFrame(); // Ensure both animals are registered

        if ( animalsInside.Count >= 2 )
        {
            Animals parentA = animalsInside[0];
            Animals parentB = animalsInside[1];

            Debug.Log("Breeding animals: " + parentA.name + " and " + parentB.name);
            BreedAnimals(parentA, parentB);

            // Remove the animals from the list and destroy them
            animalsInside.Clear();
            Destroy(parentA.gameObject);
            Destroy(parentB.gameObject);
        }
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
            if ( animal != null && !animalsInside.Contains(animal) )
            {
                // Add the animal to the list of animals inside the breeding area
                animalsInside.Add(animal);

                // Start the breeding coroutine if there are two animals inside
                if ( animalsInside.Count >= 2 )
                {
                    StartCoroutine(BreedAnimalsCoroutine());
                }
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
        float randomX = Random.Range(-1.9f, 0.3f);
        float randonY = Random.Range(1f, -1f);
        // Distance to place the offspring outside the trigger area
        float offsetX = randomX;
        float offsetY = randonY;
        return transform.position + new Vector3(offsetX, offsetY, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.CompareTag("Amoebe") )
        {
            Animals animal = other.GetComponent<Animals>();
            if ( animal != null && animalsInside.Contains(animal) )
            {
                animalsInside.Remove(animal);
                Debug.Log("Animal exited the breeding area: " + animal.name);
            }
        }
    }
}
