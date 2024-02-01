using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : ICommand
{
    private Transform transform;

    public MoveLeft(Transform t)
    {
        transform = t;
    }
    public void Execute()
    {
        transform.Translate(Vector3.left);
    }

    public void Undo()
    {
        transform.Translate(Vector3.right);
    }
}
