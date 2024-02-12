using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyTest
{
    Player playerPref = Resources.Load<Player>("Player");
    GameManager gmPref = Resources.Load<GameManager>("GameManager");
    // A Test behaves as an ordinary method
    [Test]
    public void TestPlayerExist()
    {
        var player = GameObject.Instantiate(playerPref);
        // Assert.IsTrue(player!=null);
        Assert.IsNotNull(player);
    }

    [Test]
    public void TestGMExist()
    {
        var gm = GameObject.Instantiate(gmPref);
        // Assert.IsTrue(player!=null);
        Assert.IsNotNull(gm);
    }

    [Test]
    public void TestMoveRight()
    {
        var player = GameObject.Instantiate(playerPref);
        Assert.IsNotNull(player);
        var gm = GameObject.Instantiate(gmPref);
        Assert.IsNotNull(gm);

        var oldPos = player.transform.position;

        ICommand c = new MoveRight(player.transform);
        gm.AddCommand(c);

        Assert.IsTrue(player.transform.position != oldPos);
    }


    [UnityTest]
    public IEnumerator TestComboCommand()
    {
        var player = GameObject.Instantiate(playerPref);
        Assert.IsNotNull(player);
        var gm = GameObject.Instantiate(gmPref);
        Assert.IsNotNull(gm);
        var oldPos = player.transform.position;
        ComboCommand c = new ComboCommand(player);
        c.AddStep(new MoveRight(player.transform));
        c.AddStep(new MoveRight(player.transform));
        c.AddStep(new MoveRight(player.transform));
        gm.AddCommand(c);

        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(player.transform.position == (oldPos + Vector3.right) + Vector3.right);
    }
}