using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider[] sliders;
    public Controller controller;

    void Start()
    {
        
    }

    void Update()
    {
        controller.speed = sliders[0].value;
        controller.radiusX = sliders[1].value;
        controller.radiusY = sliders[2].value;
        controller.transposeX = sliders[3].value;
        controller.transposeY = sliders[4].value;
        controller.height = sliders[5].value;
    }
}
