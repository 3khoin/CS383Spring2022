using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cainos.PixelArtTopDown_Basic;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    public float playerHP;

    private void Start()
    {
        fill = GameObject.Find("Fill").GetComponent<Image>();
        playerHP = 1f;
        fill.fillAmount = playerHP;
    }

    private void Update()
    {
        //fill.fillAmount = playerHP;
        if (Time.timeScale == 1)
        {
            //if (playerHP <= 1f && playerHP > 0f) UpdateHP(-0.002f);
            //if (playerHP == 0f) UpdateHP(1f);

            // Check that player HP does not exceed bounds
            if (playerHP < 0f) playerHP = 0f;
            if (playerHP > 1f) playerHP = 1f;

            fill.fillAmount = playerHP;
        }
    }

    public void UpdateHP(float hpChange)
    {
        playerHP += hpChange;
    }
}