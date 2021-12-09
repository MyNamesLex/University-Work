using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
public class PlaymodeTestsScript
{
    private GameObject snakehead;
    private GameObject snake1;
    private GameObject snake2;
    private GameObject snake3;
    private GameObject snake4;

    private GameObject cam;
    private GameObject enemiesOnScreen;

    //Poison Positions/Manager
    private GameObject pos1;
    private GameObject pos2;
    private GameObject pos3;
    private GameObject pos4;
    private GameObject pos5;
    private GameObject poisonSpawns;

    [SetUp]
    public void SetUp()
    {
        var snake0Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/SnakeHead.prefab");
        var snake1Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Snake1.prefab");
        var snake2Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Snake2.prefab");
        var snake3Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Snake3.prefab");
        var snake4Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Snake4.prefab");

        var enemiesOnScreenPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/EnemiesOnScreen.prefab");
        var camPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PlaceHolderEnemy.prefab");

        var pos1Obj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos1.prefab");
        var pos2Obj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos2.prefab");
        var pos3Obj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos3.prefab");
        var pos4Obj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos4.prefab");
        var pos5Obj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos5.prefab");
        var poisonSpawnsObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PoisonSpawns.prefab");

        snakehead = Object.Instantiate(snake0Prefab);
        snake1 = Object.Instantiate(snake1Prefab);
        snake2 = Object.Instantiate(snake2Prefab);
        snake3 = Object.Instantiate(snake3Prefab);
        snake4 = Object.Instantiate(snake4Prefab);

        enemiesOnScreen = Object.Instantiate(enemiesOnScreenPrefab);
        cam = Object.Instantiate(camPrefab);

        pos1 = Object.Instantiate(pos1Obj);
        pos2 = Object.Instantiate(pos2Obj);
        pos3 = Object.Instantiate(pos3Obj);
        pos4 = Object.Instantiate(pos4Obj);
        pos5 = Object.Instantiate(pos5Obj);
        poisonSpawns = Object.Instantiate(poisonSpawnsObj);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(snakehead);
        Object.Destroy(snake1);
        Object.Destroy(snake2);
        Object.Destroy(snake3);
        Object.Destroy(snake4);

        Object.Destroy(enemiesOnScreen);
        Object.Destroy(cam);

        Object.Destroy(pos1);
        Object.Destroy(pos2);
        Object.Destroy(pos3);
        Object.Destroy(pos4);
        Object.Destroy(pos5);
        Object.Destroy(poisonSpawns);
    }

    //check for rigidbodys

    [Test]
    public void TestToCheckSnakeHeadHasRigidbody()
    {
        Assert.IsTrue(snakehead.GetComponent<Rigidbody2D>() == true);
    }

    [Test]
    public void TestToCheckSnake1HasRigidbody()
    {
        Assert.IsTrue(snake1.GetComponent<Rigidbody2D>() == true);
    }

    [Test]
    public void TestToCheckSnake2HasRigidbody()
    {
        Assert.IsTrue(snake2.GetComponent<Rigidbody2D>() == true);
    }

    [Test]
    public void TestToCheckSnake3HasRigidbody()
    {
        Assert.IsTrue(snake3.GetComponent<Rigidbody2D>() == true);
    }

    [Test]
    public void TestToCheckSnake4HasRigidbody()
    {
        Assert.IsTrue(snake4.GetComponent<Rigidbody2D>() == true);
    }

    [Test]
    public void TestToCheckEnemyHasRigidbody()
    {
        var enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PlaceHolderEnemy.prefab");
        Assert.IsTrue(enemy.GetComponent<Rigidbody2D>() == true);
    }

    //Check object instantiated

    [Test]
    public void TestEnemiesOnScreenInstantiated()
    {
        Assert.IsNotNull(enemiesOnScreen);
    }

    [Test]
    public void TestSnakeHeadHasInstantiated()
    {
        Assert.IsNotNull(snakehead);
    }
    [Test]
    public void TestSnake1HasInstantiated()
    {
        Assert.IsNotNull(snake1);
    }
    [Test]
    public void TestSnake2HasInstantiated()
    {
        Assert.IsNotNull(snake2);
    }
    [Test]
    public void TestSnake3HasInstantiated()
    {
        Assert.IsNotNull(snake3);
    }
    [Test]
    public void TestSnake4HasInstantiated()
    {
        Assert.IsNotNull(snake4);
    }

    [Test]
    public void TestSceneHasPoisonManagerObject()
    {
        Assert.IsNotNull(poisonSpawns);
    }

    [Test]
    public void TestSceneHasACamera()
    {
        Assert.IsNotNull(cam);
    }

    //Test Poison Spawn Locations

    [Test]
    public void TestSceneHasPoisonSpawnLocationObjectPos1()
    {
        Assert.IsNotNull(pos1);
    }

    [Test]
    public void TestSceneHasPoisonSpawnLocationObjectPos2()
    {
        Assert.IsNotNull(pos2);
    }

    [Test]
    public void TestSceneHasPoisonSpawnLocationObjectPos3()
    {
        Assert.IsNotNull(pos3);
    }

    [Test]
    public void TestSceneHasPoisonSpawnLocationObjectPos4()
    {
        Assert.IsNotNull(pos4);
    }

    [Test]
    public void TestSceneHasPoisonSpawnLocationObjectPos5()
    {
        Assert.IsNotNull(pos5);
    }

    //Check functionality

    [UnityTest]
    public IEnumerator TestEnemyIsDestroyedWhenCollidesWithPlayer()
    {
        var enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PlaceHolderEnemy.prefab");
        GameObject enemyobj = GameObject.Instantiate(enemy);
        enemyobj.transform.position = snakehead.transform.position;

        yield return new WaitForSeconds(1);
        Assert.IsTrue(enemyobj == null);
    }

    [UnityTest]
    public IEnumerator TestPoisonCircleMovesToPoisonSpawnLocation()
    {
        var poison = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PoisonCircle.prefab");
        GameObject poisonobj = GameObject.Instantiate(poison);
        poisonobj.GetComponent<Rigidbody2D>().isKinematic = true;

        var poisonspawn = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/Pos1.prefab");
        GameObject poisonobjspawn = GameObject.Instantiate(poisonspawn);
        poisonobj.transform.position = poisonobjspawn.transform.position;

        yield return new WaitForSeconds(1);
        string pos = poisonobjspawn.transform.position.ToString();
        string po = poisonobj.transform.position.ToString();
        Assert.AreEqual(po, pos);
    }

    [UnityTest]
    public IEnumerator TestPoisonCircleCollidesWithEnemy()
    {
        var poison = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PoisonCircle.prefab");
        GameObject poisonobj = GameObject.Instantiate(poison);

        var enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PlaceHolderEnemy.prefab");
        GameObject enemyobj = GameObject.Instantiate(enemy);
        enemyobj.transform.position = poisonobj.transform.position;

        yield return new WaitForSeconds(1f);
        Assert.IsTrue(enemyobj == null);
    }

    [UnityTest]
    public IEnumerator TestExplosionCollidesWithEnemy()
    {
        var explode = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/ExplosionObject.prefab");
        GameObject explodeobj = GameObject.Instantiate(explode);

        var enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefab/PlaceHolderEnemy.prefab");
        GameObject enemyobj = GameObject.Instantiate(enemy);

        enemyobj.transform.position = explodeobj.transform.position;

        yield return new WaitForSeconds(1f);
        Assert.IsTrue(enemyobj == null);
    }
}