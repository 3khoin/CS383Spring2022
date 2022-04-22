using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class ItemIsCollected
{
    [SetUp]
    void Setup()
    {
        SceneManager.LoadScene("OverworldSpawnArea");
    }

    [UnityTest]
    public IEnumerator ItemIsCollectedTest()
    {

        yield return new WaitForSeconds(0.5f);

    }
}
