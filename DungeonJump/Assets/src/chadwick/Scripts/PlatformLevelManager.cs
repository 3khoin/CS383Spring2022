/*
* Filename: PlatformLevelManager.cs
* Developer: Chadwick Goodall
* Purpose: This file contains the code for the PlatformerLevelManger singleton class which manages the game in platforming levels
* Notes: 
* Justification of use:
* singleton was for ease of data access as a global object within the game across scenes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
* Summary: The PlatformLevelManager class which manages the game in platforming levels
*
* Member Variables:
* instance - the singleton
* player - a game object which corresponds to the main player
* cam - the camera object in the scene
* spawnPnt - the spawn point object within the level
* top/bot/left/rightPnt - the boundary points corresponding to their orientation facing the level
*/
public class PlatformLevelManager : MonoBehaviour
{
	public static PlatformLevelManager instance; //singleton
	private GameObject player;
	public GameObject cam;
	private GameObject spawnPnt;
	private GameObject topPnt;
	private GameObject botPnt;
	private GameObject leftPnt;
	private GameObject rightPnt;

	/*
    * Summary: Initialize a PlatformLevelManager singleton
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	void Awake()
	{
		// Singleton code
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}


	/*
    * Summary: Run level initialization
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	void Start()
	{
		LevelInit();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}


	/*
		* Summary: Run level initialization
		*
		* Parameters:
		* none
		*
		* Returns:
		* none
		*/
	void OnSceneLoaded(Scene currScene, LoadSceneMode mode)
	{
		LevelInit();
	}


	/*
    * Summary: Check that the player remains in bounds every frame update
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	void Update()
	{
		PlayerWithinBounds();
		CheckPlayerHealth();
	}


	/*
    * Summary: Initialize an AudioManager singleton
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	void LateUpdate()
	{
		/* dont do this
		player = GameObject.FindGameObjectWithTag("Player");
		if (player.GetComponent<AudioListener>() == null)
		{
			player.AddComponent<AudioListener>();
		}
		*/
	}

	/*
    * Summary: Checks to ensure the player is within the level bounds
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	private void PlayerWithinBounds()
	{
		//*already found player when scene loaded* player = GameObject.FindGameObjectWithTag("Player");
		if (leftPnt != null && rightPnt != null && topPnt != null && botPnt != null && spawnPnt != null)
		{
			if (leftPnt.transform.position.x > player.transform.position.x)
			{
				Debug.Log("Player exceeded level boundary: " + leftPnt.transform.position);
				//tele player to spawn
				player.transform.position = spawnPnt.transform.position;
				Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
			}
			else if (rightPnt.transform.position.x < player.transform.position.x)
			{
				Debug.Log("Player exceeded level boundary: " + rightPnt.transform.position);
				player.transform.position = spawnPnt.transform.position;
				Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
			}
			else if (topPnt.transform.position.y < player.transform.position.y)
			{
				Debug.Log("Player exceeded level boundary: " + topPnt.transform.position);
				player.transform.position = spawnPnt.transform.position;
				Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
			}
			else if (botPnt.transform.position.y > player.transform.position.y)
			{
				Debug.Log("Player exceeded level boundary: " + botPnt.transform.position);
				player.transform.position = spawnPnt.transform.position;
				Debug.Log("Player reset to spawn position: " + spawnPnt.transform.position);
			}
		}
	}

	/*
    * Summary: Initialize a platform level by grabbing all of the boundary points and spawn placed in the scene
    * sets the player's position to the spawn point and sets up the camera
    *
    * Parameters:
    * none
    *
    * Returns:
    * none
    */
	private void LevelInit()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		spawnPnt = GameObject.FindGameObjectWithTag("Spawn");

		topPnt = GameObject.FindGameObjectWithTag("top");
		botPnt = GameObject.FindGameObjectWithTag("bot");
		leftPnt = GameObject.FindGameObjectWithTag("left");
		rightPnt = GameObject.FindGameObjectWithTag("right");

		/*
        * The below AudioListener component is added in order to interact with spatial audio attached
        * to the Runescape copyright easter egg.
        * The copyright infringement of this easter egg is publicly displaying an artistic work without authorization 
        * by the copyright holder.
        * If this music were used in a commercial release of the game, the legal implications that would arise would first and foremost
        * be lawsuits filed against HexBoyz as well as potential fines.
        * Under fair use clause 1 and 4 (1): the usage of the audio clip is solely for an educational purpose as well as
        * non commercial purpose as we have no intention of publishing and/or selling the game for fiscal gain. (4): Furthermore,
        * the scope of this project is so small and due to the lacking intention to publish and sell this game, the effect on the 
        * potential market for Jagex, the creators of Runescape, would be innocuous. This is such that the unlicensed use of this music
        * would not have the opportunity to inflict any kind of financial harm to Jagex as a company. 
        */
		//DONT ADD, ALREADY ADDED BY DEFAULT player.AddComponent<AudioListener>();


		// find the player and set the position to the spawn point
		//WHY R U FINDING THE PLAYER AGAIN, YOU JUST DID ABOVE player = GameObject.FindGameObjectWithTag("Player");
		//player.transform.position = spawnPnt.position;

		// find the camera and center it to the player
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		if( cam != null && player != null) //wont have a camera and player on every level
        {
			cam.transform.position = player.transform.position + new Vector3(0f, 0f, -10f);
		}
		else
        {
			Debug.LogWarning("Couldn't find main camera to reset transform");
        }
		
	}


	/*
		* Summary: Send the player back to the start of the level if they faint
		*
		* Parameters:
		* none
		*
		* Returns:
		* none
		*/
	private void CheckPlayerHealth()
	{
		if(PlayerManagerTmp.instance == null)
        {
			Debug.LogError("Player manager instance is null");
			return;
        }

		if (PlayerManagerTmp.instance.GetPlayerHealth() <= 0)
		{
			if(player == null)
            {
				Debug.LogError("Player couldn't be found.");
				return;
			}

			if(spawnPnt == null)
            {
				Debug.LogError("Spawn point is null.");
				return;
			}

			// reset player position and health
			player.transform.position = spawnPnt.transform.position;
			PlayerManagerTmp.instance.UpdatePlayerHealth(1);
			PlayerManagerTmp.instance.UpdatePlayerScore(-500);

			//animate player death
			// player should already be found again GameObject.FindGameObjectWithTag("Player").
			Animator playerAnim = player.GetComponentInChildren<Animator>();

			if( playerAnim == null)
            {
				Debug.LogError("Player animator couldn't be found");
				return;
			}

			playerAnim.SetTrigger("Die");
		}
	}
}