using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : ICommand
{
    private Transform transform;

    public MoveUp(Transform t)
    {
        transform = t;
    }
    public void Execute()
    {
        transform.Translate(Vector3.up);
    }

    public void Undo()
    {
        transform.Translate(Vector3.down);
    }
}
