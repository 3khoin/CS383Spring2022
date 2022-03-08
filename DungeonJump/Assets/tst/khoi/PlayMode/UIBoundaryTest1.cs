using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// 81504 UI elements on screen before failing

public class UIBoundaryTest1 : MonoBehaviour
{
    public GameObject hpPrefab;
    private Vector2 screenBounds;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("UIStressTest");
    }

    [UnityTest]
    public IEnumerator BoundaryTest1()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //hpPrefab = Resources.Load("Health Bar") as GameObject;
        //GameObject hpBar = Instantiate(hpPrefab) as GameObject;
        //hpBar.transform.position = new Vector2(screenBounds.x, screenBounds.y);

        //GameObject HPBarPrefab = Resources.Load("HealthBar") as GameObject;
        //GameObject HPBarInstance = Instantiate(HPBarPrefab, transform.position, transform.rotation);
        //HPBarInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        //GameObject HPBar = new GameObject("HealthBar");
        //HPBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

        //Instantiate(HPBar);
        //print("Oh hello");

        var hpBar = GameObject.FindGameObjectsWithTag("HealthBar");
        //hpBar[0].GetComponent<HealthBar>().UpdateHP(0.5f);

        print(hpBar.Length);

        yield return null;

        Assert.True(false);
    }

    public IEnumerator BoundaryTest2()
    {


        yield return null;

        Assert.True(false);
    }

    [TearDown]
    public void Teardown()
    {
    }
}