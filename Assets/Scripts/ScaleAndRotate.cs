using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : ICommand
{
    private Transform transform;

    public ScaleUp(Transform t)
    {
        transform = t;
    }

    public void Execute()
    {
        transform.localScale *= 2;
    }
    public void Undo()
    {
        transform.localScale /= 2;
    }
}

public class ScaleDown : ICommand
{
    private Transform transform;

    public ScaleDown(Transform t)
    {
        transform = t;
    }

    public void Execute()
    {
        transform.localScale /= 2;
    }
    public void Undo()
    {
        transform.localScale *= 2;
    }
}

public class Rotate : ICommand
{
    private Transform transform;

    public Rotate(Transform t)
    {
        transform = t;
    }

    public void Execute()
    {
        transform.Rotate(0,0,30);
    }
    public void Undo()
    {
        transform.Rotate(0, 0, -30);
    }
}