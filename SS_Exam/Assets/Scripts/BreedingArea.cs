using Assets.Scripts;
using Assets.Scripts.Alternativ;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BreedingArea : MonoBehaviour
{
    // Reference to the AnimalGenetics script
    public AnimalGenetics_2 animalGenetics;

    private GameManager gameManager;

    public Slider breedingBar;

    // List to track animals inside the breeding area
    //private List<Animals> animalsInside = new List<Animals>();
    private List<GameObject> animalsInside = new List<GameObject>();

    private void Awake()
    {
        breedingBar.value = 0;
        breedingBar.gameObject.SetActive(false);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    // Method to breed two animals inside the area
    private void BreedAnimals(GameObject parentA, GameObject parentB)
    {
        // Start the breeding coroutine
        StartCoroutine(BreedAnimalsCoroutine(parentA, parentB));
    }

    //private IEnumerator BreedAnimalsCoroutine(Animals parentA, Animals parentB)
    //{
    //    // Show the breeding bar and initialize its value
    //    breedingBar.gameObject.SetActive(true);
    //    breedingBar.value = 0;

    //    float breedingDuration = 5f; // Duration of the breeding process in seconds

    //    // Update the progress bar over time
    //    while ( breedingBar.value < 1 )
    //    {
    //        breedingBar.value += Time.deltaTime / breedingDuration;
    //        yield return null; // Wait for the next frame
    //    }

    //    // Hide the breeding bar
    //    breedingBar.gameObject.SetActive(false);

    //    // Call the BreedAnimals method from the AnimalGenetics script
    //    GameObject offspring = animalGenetics.BreedAnimals(parentA, parentB);
    //    Debug.Log("Offspring created: " + offspring.name);

    //    // Determine a position outside the trigger area
    //    Vector3 outsideTriggerPosition = GetPositionOutsideTriggerArea();

    //    //add points to the game manager
    //    if ( gameManager != null )
    //    {
    //        // Add a point based on the animal tag
    //        if ( offspring.CompareTag("Amoebe") )
    //        {
    //            gameManager.AddScore(2);
    //        }
    //    }

    //    // Set the offspring's position to the new position
    //    offspring.transform.position = outsideTriggerPosition;

    //    // Detach the offspring from the breeding area
    //    offspring.transform.SetParent(null);

    //    // Clear the animals from the list and destroy the parents
    //    animalsInside.Clear();
    //    Destroy(parentA.gameObject);
    //    Destroy(parentB.gameObject);
    //}


    private IEnumerator BreedAnimalsCoroutine(GameObject parentA, GameObject parentB)
    {

        Animal_2 animalA = parentA.GetComponent<Item_2>().Animal;
        Animal_2 animalB = parentB.GetComponent<Item_2>().Animal;
        // Show the breeding bar and initialize its value
        breedingBar.gameObject.SetActive(true);
        breedingBar.value = 0;

        float breedingDuration = 5f; // Duration of the breeding process in seconds

        // Update the progress bar over time
        while (breedingBar.value < 1)
        {
            breedingBar.value += Time.deltaTime / breedingDuration;
            yield return null; // Wait for the next frame
        }

        // Hide the breeding bar
        breedingBar.gameObject.SetActive(false);

        // Call the BreedAnimals method from the AnimalGenetics script
        GameObject offspring = animalGenetics.BreedAnimals(animalA, animalB);
        Debug.Log("Offspring created: " + offspring.name);
        Debug.Log("Tag: " + offspring.tag);

        // Determine a position outside the trigger area
        Vector3 outsideTriggerPosition = GetPositionOutsideTriggerArea();
        Debug.Log("I AM YOUR GM: " + gameManager);
        //add points to the game manager
        if (GameManager.instance != null)
        {
            // Add a point based on the animal tag
            if (offspring.CompareTag("Amoebe"))
            {
                Debug.Log("YOU ARE A AMOEBE");
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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Triggered with: " + other.gameObject.name);

    //    // Check if the collider belongs to an object with the "Amoebe" tag
    //    if ( other.CompareTag("Amoebe") )
    //    {
    //        Debug.Log("Amoebe detected: " + other.gameObject.name);

    //        // Get the Animals component from the collider's GameObject
    //        Animals animal = other.GetComponent<Animals>();
    //        Debug.Log("Animal component: " + ( animal != null ? animal.name : "null" ));

    //        // Ensure that the animal component is not null
    //        if ( animal != null && !animalsInside.Contains(animal) )
    //        {
    //            // Add the animal to the list of animals inside the breeding area
    //            animalsInside.Add(animal);

    //            // Start the breeding coroutine if there are two animals inside
    //            if ( animalsInside.Count >= 2 )
    //            {
    //                BreedAnimals(animalsInside[0], animalsInside[1]);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Object is not tagged as Amoebe: " + other.gameObject.tag);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        // Check if the collider belongs to an object with the "Amoebe" tag
        if (other.CompareTag("Amoebe"))
        {
            Debug.Log("Amoebe detected: " + other.gameObject.name);

            // Get the Animals component from the collider's GameObject
            GameObject go = other.gameObject;
            Animal_2 animal = go.GetComponent<Item_2>().Animal;
            Debug.Log("Animal component: " + (animal != null ? animal.AnimalName : "null"));

            // Ensure that the animal component is not null
            if (animal != null && !animalsInside.Contains(go))
            {
                // Add the animal to the list of animals inside the breeding area
                animalsInside.Add(go);

                // Start the breeding coroutine if there are two animals inside
                if (animalsInside.Count >= 2)
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

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if ( other.CompareTag("Amoebe") )
    //    {
    //        Animals animal = other.GetComponent<Animals>();
    //        if ( animal != null && animalsInside.Contains(animal) )
    //        {
    //            animalsInside.Remove(animal);
    //            Debug.Log("Animal exited the breeding area: " + animal.name);
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Amoebe"))
        {
            GameObject animal = other.gameObject;
            if (animal != null && animalsInside.Contains(animal))
            {
                animalsInside.Remove(animal);
                Debug.Log("Animal exited the breeding area: " + animal.name);
            }
        }
    }
}
