using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light discoLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HSV = Hue, Saturation, Value
        //Hue controls the color
        //Saturation controls how much color there is
        //Value controls how bright the color is
        discoLight.color = Color.HSVToRGB(Random.value, 1, 1);
    }
}