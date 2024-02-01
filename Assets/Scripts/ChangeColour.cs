using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChangeColour : ICommand
{
    private Renderer renderer;

    public ChangeColour(Renderer r)
    {
        renderer = r;
    }
    public void Execute()
    {
        renderer.material.color = Color.red;
    }

    public void Undo()
    {
        
    }
}
