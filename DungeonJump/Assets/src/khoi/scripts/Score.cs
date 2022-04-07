using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = string.Format("Score: {0}", PlayerManagerTmp.instance.GetPlayerScore().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("Score: {0}", PlayerManagerTmp.instance.GetPlayerScore().ToString());
    }
}