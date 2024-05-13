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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && slider.value < 1)
        {
            if (pSystem != null && !pSystem.isPlaying)
                pSystem.Play();

            slider.value += moveSpeed * Time.deltaTime;
            Color.RGBToHSV(Fill.color, out float H, out float S, out float V);
            H = startHue - startHue * slider.value;
            Fill.color = Color.HSVToRGB(H, S, V);

            ParticleSystem.MainModule mm = pSystem.main;
            mm.startColor = Fill.color;

            if (slider.value > 0.65)
                moveSpeed = 0.5f;
        } else
        {
            pSystem.Stop();
        }
        
    }
}
