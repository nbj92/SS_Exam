using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AnimalGenes
    {
        public SizeGene[] sizeGene;
        public ColorGene[] colorGenes;


        public AnimalGenes(SizeGene[] size, params ColorGene[] colors)
        {
            sizeGene = size;
            colorGenes = colors;
        }

        // Method to determine the phenotype (actual size and color) based on genes
        public (SizeGene, ColorGene) DeterminePhenotype()
        {
            // For size, if there's at least one dominant allele (Large), the phenotype will be Large
            SizeGene phenotypeSize = SizeGene.Small; // Start with the recessive allele
            foreach (var gene in sizeGene)
            {
                if (gene == SizeGene.Large)
                {
                    phenotypeSize = SizeGene.Large;
                    break;
                }
            }

            // For color, determine the dominant color allele
            ColorGene phenotypeColor = ColorGene.Blue; // Start with the least dominant color
            foreach (var gene in colorGenes)
            {
                if (gene == ColorGene.Red)
                {
                    phenotypeColor = ColorGene.Red;
                    break;
                }
                else if (gene == ColorGene.Green)
                {
                    phenotypeColor = ColorGene.Green;
                    // Remove break statement to properly check for all colors
                }
            }

            return (phenotypeSize, phenotypeColor);
        }
    }
}