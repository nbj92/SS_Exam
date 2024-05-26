using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGenetics : MonoBehaviour
{
    public GameObject offspringPrefab;

    public GameObject BreedAnimals(Animals parentA, Animals parentB)
    {
        // Determine which genes the offspring inherits from each parent
        Animals offspringGenes = TestTwoGenes(parentA, parentB);

        // Instantiate a new offspring object with the selected genes
        GameObject offspring = Instantiate(offspringPrefab, transform.position, Quaternion.identity);

        // Assign the genes to the offspring
        Animals offspringComponent = offspring.GetComponent<Animals>();
        offspringComponent.dominance = offspringGenes.dominance;
        offspringComponent.size = offspringGenes.size;
        // Assign other genes as needed

        // Return the offspring object
        return offspring;
    }

    Animals TestTwoGenes(Animals a, Animals b)
    {
        float size = a.dominance / (a.dominance + b.dominance);

        float randomNumber = Random.Range(0f, 1f);


        if(randomNumber <= size)
        {
            Debug.Log("Gene from a");
            return a;
        } else
        {
            Debug.Log("Gene from b");
            return b;
        }
    }
}