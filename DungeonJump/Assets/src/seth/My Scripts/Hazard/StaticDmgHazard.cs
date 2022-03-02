using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDmgHazard : Hazard
{
    public int dmg;
    public int redDmgDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //implement redamage delay somehow
    }

    override public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        //if collid w/ player:
        if( collision.gameObject.tag == "Player")
        {
            //damage player immediately
            DamagePlayer(collision.gameObject);
        }
    }

    private void DamagePlayer(GameObject player)
    {
        //dmg player
        //player.GetComponent<SomeType>().DmgPlayer(); or player.getComponent<SomeType>().health -= dmg;
        print("Damage Player");
    }
}
