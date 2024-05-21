using Assets.Scripts;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public enum SizeGene { Large = 75, Small = 100 };

public enum ColorGene { Red = 25, Green = 35, Blue = 40 };
public class Breed : MonoBehaviour
{

    //public Animal father;
    //public Animal mother;
    private Random rand = new Random();

    public Animal BreedAnimal(Animal father, Animal mother)
    {

        SizeGene sg;
        ColorGene cg;

        if(father.Size.Equals(mother.Size))
        {
            sg = father.Size;
        } else
        {
            int r = rand.Next(100) + 1;

            foreach (SizeGene gene in Enum.GetValues(typeof(SizeGene))) {
                Debug.Log(gene);
            }

            //if (r )
            //{
            //    sg = father
            //}
        }

        //Animal child = new Animal(sg, cg);
        return null;
    }

}
