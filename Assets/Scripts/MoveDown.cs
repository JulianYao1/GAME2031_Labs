using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ICommand
{
    private Transform transform;

    public MoveDown(Transform t)
    {
        transform = t;
    }
    public void Execute()
    {
        transform.Translate(Vector3.down);
    }

    public void Undo()
    {
        transform.Translate(Vector3.up);
    }
}
