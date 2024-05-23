using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreedingArea : MonoBehaviour
{
    // Reference to the AnimalGenetics script
    public AnimalGenetics animalGenetics;

    public GameManager gameManager;

    public Slider breedingBar;

    // List to track animals inside the breeding area
    private List<Animals> animalsInside = new List<Animals>();

    private void Awake()
    {
        breedingBar.value = 0;
        breedingBar.gameObject.SetActive(false);
    }

    // Method to breed two animals inside the area
    private void BreedAnimals(Animals parentA, Animals parentB)
    {
        // Start the breeding coroutine
        StartCoroutine(BreedAnimalsCoroutine(parentA, parentB));
    }

    private IEnumerator BreedAnimalsCoroutine(Animals parentA, Animals parentB)
    {
        // Show the breeding bar and initialize its value
        breedingBar.gameObject.SetActive(true);
        breedingBar.value = 0;

        float breedingDuration = 5f; // Duration of the breeding process in seconds

        // Update the progress bar over time
        while ( breedingBar.value < 1 )
        {
            breedingBar.value += Time.deltaTime / breedingDuration;
            yield return null; // Wait for the next frame
        }

        // Hide the breeding bar
        breedingBar.gameObject.SetActive(false);

        // Call the BreedAnimals method from the AnimalGenetics script
        GameObject offspring = animalGenetics.BreedAnimals(parentA, parentB);
        Debug.Log("Offspring created: " + offspring.name);

        // Determine a position outside the trigger area
        Vector3 outsideTriggerPosition = GetPositionOutsideTriggerArea();

        if ( gameManager != null )
        {
            // Add a point based on the animal tag
            if ( offspring.CompareTag("Amoebe") )
            {
                gameManager.AddScore(2);
            }
        }

        // Set the offspring's position to the new position
        offspring.transform.position = outsideTriggerPosition;

        // Detach the offspring from the breeding area
        offspring.transform.SetParent(null);

        // Clear the animals from the list and destroy the parents
        animalsInside.Clear();
        Destroy(parentA.gameObject);
        Destroy(parentB.gameObject);
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
                    BreedAnimals(animalsInside[0], animalsInside[1]);
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
