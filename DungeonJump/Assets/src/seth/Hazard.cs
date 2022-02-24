using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public AudioSource hazardSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        print("hazard trigger entered");
    }
}
