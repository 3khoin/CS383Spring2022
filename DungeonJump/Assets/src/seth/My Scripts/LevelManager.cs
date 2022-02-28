using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] progressBlocks;
    public GameObject player;
    public Vector2 playerRespawnPos;

    private GameObject[] playerCurrItems;
    private GameObject[] totItems;
    private int progPercentage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckProgress()
    {
        //calc progPercentage thru ratio of player items and tot items:
        progPercentage = playerCurrItems.Length / totItems.Length;
    }

    //remove specified prog block:
    private void Remove_PBlock(int arrIndex)
    {
        //turn off visibility of prog block:
        progressBlocks[arrIndex].SetActive(false); 
    }
}
