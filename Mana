using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mana : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI tmp;

    public float manaProductionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += Time.deltaTime * manaProductionSpeed;
        tmp.text = slider.value.ToString("f0");
    }
}
