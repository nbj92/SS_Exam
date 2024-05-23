using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    public GameObject transporter;

   
    void Update()
    {
        //GameManager.instance.active =
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transporter")
        {
            
            if (SceneManager.GetActiveScene().name == "Laboratorie")
            {
                SceneManager.LoadScene("JakeScene");
                
            }
            else
            {
                SceneManager.LoadScene("Laboratorie");
                
            }
        }

    }

}
