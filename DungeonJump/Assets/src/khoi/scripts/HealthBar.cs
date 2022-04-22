/* 
 * HealthBar.cs
 * Developer: Khoi Nguyen
 * Displays a health bar on the screen that changes in fill as the player's HP changes.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // This field is for inserting the image that will be seen in the health bar
    public Image fill;

    /*
     * Start()
     * Parameters: none
     * Returns: none
     * Initializes the health bar with the player health.
     */
    private void Start()
    {
        fill = GameObject.Find("Fill").GetComponent<Image>();
        fill.fillAmount = PlayerManagerTmp.instance.GetPlayerHealth();
    }

    /*
     * Update()
     * Parameters: none
     * Returns: none
     * Updates the health bar as the player health changes every frame.
     */
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            fill.fillAmount = PlayerManagerTmp.instance.GetPlayerHealth();
        }
    }
}