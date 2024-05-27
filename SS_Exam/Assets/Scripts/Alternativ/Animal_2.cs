using System;
using UnityEngine;

namespace Assets.Scripts.Alternativ
{
    [Serializable]
    public class Animal_2
    {

        public Color Color { get; set; }
        public float? size;
        public string AnimalName { get; set;}

        public Animal_2(string name, float? size, Color? color)
        {
            this.AnimalName = name;
            this.size = size;
            this.Color = (Color)color;
        }


    }
}
