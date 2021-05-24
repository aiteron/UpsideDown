using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerTests
{
    private Player1Controller player1;

    [SetUp]
    public void SetUp()
    {
        // Camera
        new GameObject().AddComponent<Camera>();

        // Player1
        player1 = new GameObject().AddComponent<Player1Controller>();
        player1.gameObject.AddComponent<BoxCollider2D>();
        player1.gameObject.AddComponent<Rigidbody2D>();
        player1.gameObject.AddComponent<Animator>();
        player1.Jumping = new GameObject().AddComponent<AudioSource>();
        player1.speed = 10;
        player1.jumpForce = 10;
        player1.gameObject.tag = "Player1";

        player1.stepParticles = new GameObject().AddComponent<ParticleSystem>();
        player1.feetPos1 = new GameObject().transform;
        player1.feetPos2 = new GameObject().transform;
    }

    [UnityTest]
    public IEnumerator Player_move_left_test()
    {
        // Box
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        // Wait for fall on box
        yield return new WaitForSeconds(2);

        var posXBefore = player1.transform.position.x;
        for (int i = 0; i < 300; i++)
        {
            player1.MoveLeft();
            yield return new WaitForEndOfFrame();
        }
        var posXAfter = player1.transform.position.x;

        Assert.Greater(posXBefore, posXAfter);
    }

    [UnityTest]
    public IEnumerator Player_move_right_test()
    {
        // Box
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        // Wait for fall on box
        yield return new WaitForSeconds(2);

        var posXBefore = player1.transform.position.x;
        for (int i = 0; i < 100; i++)
        {
            player1.MoveRight();
            yield return new WaitForEndOfFrame();
        }
        var posXAfter = player1.transform.position.x;

        Assert.Less(posXBefore, posXAfter);
    }

    // Jump

    [UnityTest]
    public IEnumerator Player_move_jump_test()
    {
        // Box
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        // Wait for fall on box
        yield return new WaitForSeconds(2);

        var posYBefore = player1.transform.position.y;
        player1.Jump();
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForEndOfFrame();
            Debug.Log(player1.transform.position.y);
        }
        var posYAfter = player1.transform.position.y;

        Assert.Less(posYBefore, posYAfter);
    }

    // Die
    [UnityTest]
    public IEnumerator Player_die_test()
    {
        // Box
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        var spikes = new GameObject().AddComponent<SpikesScript>();
        spikes.gameObject.AddComponent<BoxCollider2D>();
        spikes.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        spikes.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
        spikes.transform.position = new Vector3(0, 0, 0);       // Player spawn on spikes

        var managerFail = new GameObject().AddComponent<FailManager>();
        managerFail.gameObject.name = "_managerFail";
        managerFail.failMenuUI = new GameObject();
        managerFail.failMenuUI.SetActive(false);
        managerFail.failSound = new GameObject().AddComponent<AudioSource>();

        var gameMusic = new GameObject().AddComponent<AudioSource>();
        gameMusic.gameObject.name = "GameMusic";

        Assert.AreEqual(1, Time.timeScale);

        // Wait for fall on box
        yield return new WaitForEndOfFrame();   // Awake
        yield return new WaitForEndOfFrame();   // Start
        yield return new WaitForEndOfFrame();   // First frame of game
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Assert.AreEqual(0, Time.timeScale);
        Assert.AreEqual(true, managerFail.failMenuUI.activeSelf);
    }


    // Gems
    [UnityTest]
    public IEnumerator Player_get_new_gem_test()
    {
        // Box
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        var gem = new GameObject().AddComponent<GemBlueScript>();
        gem.gameObject.AddComponent<BoxCollider2D>();
        gem.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gem.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
        gem.transform.position = new Vector3(0, -10, 0);
        gem.collectSound = new GameObject().AddComponent<AudioSource>();

        Assert.AreEqual(0, player1.GetGemsCount());

        // Wait for fall on box
        yield return new WaitForSeconds(2);
        Debug.Log(player1.transform.position.y);

        Assert.AreEqual(1, player1.GetGemsCount());
    }

    // Win
    [UnityTest]
    public IEnumerator Player_win_test()
    {
        // Box for player 1
        var box = new GameObject().AddComponent<BoxCollider2D>();
        box.transform.position = new Vector3(0, -20, 0);
        box.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        // Gem for player 1
        var gem = new GameObject().AddComponent<GemBlueScript>();
        gem.gameObject.AddComponent<BoxCollider2D>();
        gem.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gem.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
        gem.transform.position = new Vector3(0, -10, 0);
        gem.collectSound = new GameObject().AddComponent<AudioSource>();

        // Door for player 1
        var door1 = new GameObject().AddComponent<ExitNormalScript>();
        door1.transform.position = new Vector3(0, -19, 0);
        door1.gameObject.AddComponent<BoxCollider2D>();
        door1.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
        door1.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        door1.gameObject.AddComponent<SpriteRenderer>();
        door1.isOpen = false;
        door1.gemsCountNeed = 1;


        // Second player
        var player2 = new GameObject().AddComponent<Player2Controller>();
        player2.gameObject.AddComponent<BoxCollider2D>();
        player2.gameObject.AddComponent<Rigidbody2D>();
        player2.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
        player2.gameObject.AddComponent<Animator>();
        player2.Jumping = new GameObject().AddComponent<AudioSource>();
        player2.speed = 10;
        player2.jumpForce = 10;
        player2.gameObject.tag = "Player2";
        player2.transform.position = new Vector3(10, 0, 0);

        player2.stepParticles = new GameObject().AddComponent<ParticleSystem>();
        player2.feetPos1 = new GameObject().transform;
        player2.feetPos2 = new GameObject().transform;

        // Box for player 2
        var box2 = new GameObject().AddComponent<BoxCollider2D>();
        box2.transform.position = new Vector3(10, 20, 0);
        box2.GetComponent<BoxCollider2D>().size = new Vector2(15, 1);

        // Gem for player 2
        var gem2 = new GameObject().AddComponent<GemRedScript>();
        gem2.gameObject.AddComponent<BoxCollider2D>();
        gem2.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gem2.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
        gem2.transform.position = new Vector3(10, 10, 0);
        gem2.collectSound = new GameObject().AddComponent<AudioSource>();

        Assert.AreEqual(0, player1.GetGemsCount());
        Assert.AreEqual(0, player2.GetGemsCount());

        // Wait for fall on box
        yield return new WaitForSeconds(2);
        Debug.Log(player2.transform.position.y);

        Assert.AreEqual(1, player1.GetGemsCount());
        Assert.AreEqual(1, player2.GetGemsCount());
    }

    [TearDown]
    public void TearDown()
    {
        Object.FindObjectsOfType<GameObject>().ToList().ForEach(go => Object.DestroyImmediate(go));
        Time.timeScale = 1.0f;
    }
}
