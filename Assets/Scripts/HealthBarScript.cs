﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject playerCube;

    public Slider slider;

    private void Start()
    {
        SetMaxHealth();
    }

    void Update()
    {
        if (slider.maxValue == 0f) {
            SetMaxHealth();
        }
        SetHealth();
    }

    public void SetHealth()
    {
        slider.value = playerCube.GetComponent<StatSheet>().HP;
    }

    public void SetMaxHealth()
    {
        slider.maxValue = playerCube.GetComponent<StatSheet>().HP;
        slider.value = playerCube.GetComponent<StatSheet>().HP;
    }
}
