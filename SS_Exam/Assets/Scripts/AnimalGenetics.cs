using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class AnimalGenetics : MonoBehaviour
//{
//    public enum SizeGene { Large, Small };
//    public enum ColorGene { Red, Green, Blue };

//    public class AnimalGenes
//    {
//        public SizeGene[] sizeGene;
//        public ColorGene[] colorGenes;

//        public AnimalGenes(SizeGene[] size, params ColorGene[] colors)
//        {
//            sizeGene = size;
//            colorGenes = colors;
//        }

//        // Method to determine the phenotype (actual size and color) based on genes
//        public (SizeGene, ColorGene) DeterminePhenotype()
//        {
//            // For size, if there's at least one dominant allele (Large), the phenotype will be Large
//            SizeGene phenotypeSize = SizeGene.Small; // Start with the recessive allele
//            foreach ( var gene in sizeGene) { 
//            if ( phenotypeSize == SizeGene.Large )
//                {
//                    phenotypeSize = SizeGene.Large;
//                }
//            }

//            // For color, determine the dominant color allele
//            ColorGene phenotypeColor = ColorGene.Blue; // Start with the least dominant color
//            foreach ( var gene in colorGenes )
//            {
//                if ( gene == ColorGene.Red )
//                {
//                    phenotypeColor = ColorGene.Red;
//                    break;
//                }
//                else if ( gene == ColorGene.Green )
//                {
//                    phenotypeColor = ColorGene.Green;
//                    break; // Added break statement to stop after finding the dominant color
//                }
//            }

//            return (phenotypeSize, phenotypeColor);
//        }
//    }

//}

public class AnimalGenetics : MonoBehaviour
{
    public Animals a;
    public Animals b;
    Animals TestTwoGenes(Animals a, Animals b)
    {
        float color = a.dominance / (a.dominance + b.dominance);

        float randomNumber = Random.Range(0f, 1f);

        if(randomNumber <= color)
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