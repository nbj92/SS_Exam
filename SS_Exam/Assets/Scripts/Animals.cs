using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public enum Color { Red, Green, Blue };
    public float dominance;
    public Color[] genes;
}

public class Ko : Animals
{
    public void Speak()
    {
        Debug.Log("Muhhhhhh");
    }
}
