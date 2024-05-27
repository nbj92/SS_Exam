using Assets.Scripts;
using Assets.Scripts.Alternativ;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalGenetics_2 : MonoBehaviour
{
    public GameObject offspringPrefab;

    public GameObject BreedAnimals(Animal_2 parentA, Animal_2 parentB)
    {
        // Determine which genes the offspring inherits from each parent
        //Animal_2 offspringGenes = TestTwoGenes(parentA, parentB)

        float size = OffSpringSize((float)parentA.size, (float)parentB.size);
        Color color = OffspringColor(parentA.Color, parentB.Color);

        Debug.Log("breed: " + color);


        //Debug:Logger()

        Animal_2 offSpring = new Animal_2("Amoebe_"+GameManager.instance.GetAnimals().Count, size, color);
        //offspringPrefab.GetComponent<Item_2>().Animal = offSpring;
        //offspringPrefab.GetComponent<Item_2>().Animal = offspringGenes;
        //Debug.Log("offs:"+offSpring.size);
        //GameObject go = offspringPrefab;
        //go.GetComponent<Item_2>().Animal = offSpring;
        //GameObject child = go.transform.GetChild(0).gameObject;
        //SpriteRenderer sr = child.GetComponent<SpriteRenderer>();
        //sr.color = offSpring.Color;
        //go.GetComponent<Item_2>().size = (float)offSpring.size;
        // Assign the genes to the offspring
        //Animal_2 offspringComponent = offspring.GetComponent<Item_2>();
        //offspringComponent.dominance = offspringGenes.dominance;
        //offspringComponent.size = offspringGenes.size;
        // Assign other genes as needed

        
        // Instantiate a new offspring object with the selected genes
        GameObject offspring = Instantiate(offspringPrefab, transform.position, Quaternion.identity);
        offspring.GetComponent<Item_2>().color = color;
        offspring.GetComponent<Item_2>().size = (float)offSpring.size;

        Debug.Log(offspring.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color);
        //offspring.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color
        offspring.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = OffspringColor(parentA.Color, parentB.Color);//new Color(142/255f, 155/255f, 244/255f, 1f);
        //go.GetComponent<Item_2>().SetColor(color);
        // Return the offspring object
        return offspring;   
    }

    Color OffspringColor(Color colorA, Color colorB)
    {
        float rnd = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(rnd);
        float r = (rnd *Math.Max(colorA.r, colorB.r) + (1f - rnd) * Math.Min(colorA.r, colorB.r));
        Debug.Log("r: " + r);
        rnd = UnityEngine.Random.Range(0f, 1f);
        float g = (rnd * Math.Max(colorA.g, colorB.g) + (1f - rnd) * Math.Min(colorA.g, colorB.g));

        rnd = UnityEngine.Random.Range(0f, 1f);
        float b = (rnd * Math.Max(colorA.b, colorB.b) + (1f - rnd) * Math.Min(colorA.b, colorB.b));

        Color colorOffspring = new Color(r, g, b, 1f);
        Debug.Log(colorOffspring);




        return colorOffspring;

        return Color.white;
    }

    float OffSpringSize(float sizeA, float sizeB)
    {
        //float size = a.dominance / (a.dominance + b.dominance);

        float rnd= UnityEngine.Random.Range(0f, 1f);

        float size = (1f-rnd)*sizeA + rnd*sizeB;

        return size;
        //if(randomNumber <= size)
        //{
        //    Debug.Log("Gene from a");
        //    return a;
        //} else
        //{
        //    Debug.Log("Gene from b");
        //    return b;
        //}


    }
}