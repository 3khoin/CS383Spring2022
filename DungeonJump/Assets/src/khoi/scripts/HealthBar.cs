using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cainos.PixelArtTopDown_Basic;

public class HealthBar : MonoBehaviour
{
    public Image fill;

    private void Start()
    {
        fill = GameObject.Find("Fill").GetComponent<Image>();
        fill.fillAmount = PlayerManagerTmp.instance.GetPlayerHealth();
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            fill.fillAmount = PlayerManagerTmp.instance.GetPlayerHealth();
        }
    }
}