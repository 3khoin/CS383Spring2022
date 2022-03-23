using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHazard : Hazard
{
    public Vector2 launchDir;
    public float launchForce;
    public AnimationClip hazardAnim;
    public float activationDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if( collision.gameObject.tag == "Player")
        {
            //start the launch delay coroutine:
            StartCoroutine(LaunchDelay());

            //launch player, but only if still on tile after delay
            LaunchPlayer(collision.gameObject);
        }
    }

    //delay launch coroutine:
    IEnumerator LaunchDelay()
    {

        yield return new WaitForSeconds(activationDelay);
    }

    //launch player:
    private void LaunchPlayer(GameObject player)
    {

        //add force to player's rigidbody:
        player.GetComponent<Rigidbody2D>().AddForce(launchDir * launchForce);
    }
}