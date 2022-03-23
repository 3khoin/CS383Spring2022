using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDmgHazard : Hazard
{
    public float dmg;
    public float redDmgDelay = 0.5f;

    private GameObject target;

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
            //store player to damage:
            target = collision.gameObject;

            //damage player immediately
            DamagePlayer();
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        //if collide w/ player exiting:
        if (collision.gameObject.tag == "Player")
        {
            //clear player so not re-damaged:
            target = null;
        }
    }

    private void DamagePlayer()
    {
        //if target exited:
        if (target == null)
        {
            return; //dont damage
        }

        //dmg player
        //target.GetComponent<SomeType>().DmgPlayer(); or target.getComponent<SomeType>().health -= dmg;
        print("Damage Player");

        //try damaging player again in 0.5s:
        Invoke("DamagePlayer", redDmgDelay);
    }
}
