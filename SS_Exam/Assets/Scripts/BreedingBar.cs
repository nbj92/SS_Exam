using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreedingBar : MonoBehaviour
{

    public ParticleSystem pSystem;
    public Image Fill;
    private Slider slider;
    private float moveSpeed = 0.2f;
    private float startHue;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        
        Color.RGBToHSV(Fill.color, out float H, out float S, out float V);
        startHue = H;
        //Debug.Log("Start: " +pSystem.isPlaying);
        pSystem.Play();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (pSystem != null && !pSystem.isPlaying)
        {
            pSystem.Play();
            //Debug.Log(pSystem);
        }

        if(gameObject.activeSelf && slider.value < 1)
        {
            slider.value += moveSpeed*Time.deltaTime;
            Color.RGBToHSV(Fill.color, out float H, out float S, out float V);
            //Debug.Log("update " + H);
            H = startHue - startHue * slider.value;

                
                    Fill.color = Color.HSVToRGB(H, S, V);
                
            
            if(slider.value > 0.65) {
                moveSpeed = 0.5f;
               
            }



        }
        
    }
}
