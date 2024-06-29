using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    [UnityTest]
    public IEnumerator GoForward()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerMovement>();
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        float input = 1f;

        player.movementSpeed = 10f;

        player.rigidbody = rigidbody;

        Vector3 startPosition = player.transform.position;

        player.MovePlayerForwardOrBackward(input);
        yield return null;

        Vector3 direction = player.transform.position - startPosition;

        yield return new WaitForSeconds(2f);
        Assert.That((direction).x, Is.EqualTo(Vector3.zero.x));
        Assert.That((direction).y, Is.EqualTo(Vector3.zero.y));
        Assert.That((direction).z, Is.GreaterThan(Vector3.zero.z));
    }

    [UnityTest]
    public IEnumerator GoBackward()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerMovement>();
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        float input = -1f;

        player.movementSpeed = 10f;

        player.rigidbody = rigidbody;

        Vector3 startPosition = player.transform.position;

        player.MovePlayerForwardOrBackward(input);
        yield return null;

        Vector3 direction = player.transform.position - startPosition;

        yield return new WaitForSeconds(2f);
        Assert.That((direction).x, Is.EqualTo(Vector3.zero.x));
        Assert.That((direction).y, Is.EqualTo(Vector3.zero.y));
        Assert.That((direction).z, Is.LessThan(Vector3.zero.z));
    }


    [UnityTest]
    public IEnumerator TurnRight()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerMovement>();
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        float input = 1f;

        player.rotationSpeed = 5f;

        player.rigidbody = rigidbody;

        Quaternion startRotation = player.transform.rotation;

        player.RotatePlayer(input);
        yield return null;

        Quaternion actualRotation = player.transform.rotation;

        yield return new WaitForSeconds(2f);
        Assert.That(actualRotation.x, Is.EqualTo(0));
        Assert.That(actualRotation.y, Is.GreaterThan(startRotation.y));
        Assert.That(actualRotation.z, Is.EqualTo(0));
    }

    [UnityTest]
    public IEnumerator TurnLeft()
    {
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<PlayerMovement>();
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        float input = -1f;

        player.rotationSpeed = 5f;

        player.rigidbody = rigidbody;

        Quaternion startRotation = player.transform.rotation;

        player.RotatePlayer(input);
        yield return null;

        Quaternion actualRotation = player.transform.rotation;

        yield return new WaitForSeconds(2f);
        Assert.That(actualRotation.x, Is.EqualTo(0));
        Assert.That(actualRotation.y, Is.LessThan(startRotation.y));
        Assert.That(actualRotation.z, Is.EqualTo(0));
    }

}
