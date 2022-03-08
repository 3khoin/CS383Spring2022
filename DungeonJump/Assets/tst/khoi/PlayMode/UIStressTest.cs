using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// 81504 UI elements on screen before failing

public class UIStressTest : MonoBehaviour
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("UIStressTest");
    }

    [UnityTest]
    public IEnumerator StressTest()
    {
        GameObject HPBar = new GameObject("HealthBar");
        HPBar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        
        int i = 0;
        while (i < int.MaxValue)
        {
            Instantiate(HPBar);
            Debug.Log(i + " UI elements on screen");
            i++;
            yield return null;
        }

        yield return null;

        Assert.True(false);
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("UIStressTest");
    }
}