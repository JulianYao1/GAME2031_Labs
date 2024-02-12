using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : ICommand
{
    private Transform transform;

    public MoveRight(Transform t)
    {
        transform = t;
    }
    public void Execute()
    {
        transform.Translate(Vector3.right);
    }

    public void Undo()
    {
        transform.Translate(Vector3.left);
    }
}
