using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Animal : MonoBehaviour
    {
        public ColorGene Color { get; set; }
        public SizeGene Size { get; set; }
        
        public Animal(SizeGene size, ColorGene color)
        {
            this.Size = size;
            this.Color = color;
        }
    }
}