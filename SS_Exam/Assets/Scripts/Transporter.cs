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
            PlayerPrefs.Save();
            //Transform t = transporter.transform;
            if (SceneManager.GetActiveScene().name == "Laboratorie")
            {
                SceneManager.LoadScene("JakeScene");
                //gameObject.transform.position = new Vector3(t.position.x, t.position.y, t.position.z);
            }
            else
            {
                SceneManager.LoadScene("Laboratorie");
                //gameObject.transform.position = new Vector3(t.position.x, t.position.y, t.position.z);
            }
        }

    }

}
