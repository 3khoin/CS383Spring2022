using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrywayExit : MonoBehaviour
{
    public GameObject cieling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cieling.SetActive(true);
        }
    }
}
