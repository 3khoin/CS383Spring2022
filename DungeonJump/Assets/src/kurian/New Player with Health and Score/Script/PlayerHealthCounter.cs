using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthCounter : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int heathValue;

    // Use for Inilization
    void Start()
    {
        heathValue = 100;
    }

    public void Update()
    {
        scoreText.text = "Health: " + heathValue;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name.Equals("Heart"))
        {
            heathValue += 10;
            collision.gameObject.SetActive(false);
        }         
       
       if (collision.name.Equals("Enemy") )
        {
            if(heathValue <= 0)
            {
              //  scoreText.text = "Health:"+"Dead"; 
            }
            else
            {
                heathValue -= 3;
            }                
        } 
    }
   
}