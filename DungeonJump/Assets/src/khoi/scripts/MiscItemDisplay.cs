using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscItemDisplay : MonoBehaviour
{
    public Image item;
    public string itemName;

    // Start is called before the first frame update
    private void Start()
    {
        if(PlayerManagerTmp.instance.MiscItemIsCollected(itemName))
        {
            item.enabled = true;
        }
        else
        {
            item.enabled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerManagerTmp.instance.MiscItemIsCollected(itemName))
        {
            item.enabled = true;
        }
        else
        {
            item.enabled = false;
        }
    }
}