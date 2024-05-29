using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Alternativ
{
    public class Score : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameManager.instance.scoreText = gameObject.GetComponent<TextMeshProUGUI>();
            GameManager.instance.UpdateUI();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}