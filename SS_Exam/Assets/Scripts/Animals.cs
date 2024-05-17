using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public float size;
    public float dominance;
}

public class Ko : Animals
{
    public void Speak()
    {
        Debug.Log("Muhhhhhh");
    }
}
