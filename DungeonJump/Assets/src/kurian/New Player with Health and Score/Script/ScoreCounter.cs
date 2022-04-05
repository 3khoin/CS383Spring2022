using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int scoreValue;

    // Use for Inilization
    void Start()
    {       
        scoreValue = 0;
    }

    public void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Coin") )
        {
            scoreValue += 2;
            collision.gameObject.SetActive(false);
        }       
    }
}