using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;




public class AnimalGenetics : MonoBehaviour
{

    public SizeGene[] sg;

    // Method to simulate the inheritance of genes from two parents
    public AnimalGenes Breed(AnimalGenes parent1, AnimalGenes parent2)
    {
        // Randomly choose one gene from each parent for size
        SizeGene[] offspringSizeGenes = new SizeGene[2];
        offspringSizeGenes[0] = parent1.sizeGene[Random.Range(0, parent1.sizeGene.Length)];
        offspringSizeGenes[1] = parent2.sizeGene[Random.Range(0, parent2.sizeGene.Length)];

        // Randomly choose two genes from each parent for color
        ColorGene[] offspringColorGenes = new ColorGene[2];
        offspringColorGenes[0] = parent1.colorGenes[Random.Range(0, parent1.colorGenes.Length)];
        offspringColorGenes[1] = parent2.colorGenes[Random.Range(0, parent2.colorGenes.Length)];

        return new AnimalGenes(offspringSizeGenes, offspringColorGenes);
    }
}

