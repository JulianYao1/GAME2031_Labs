using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCommand : ICommand
{
    List<ICommand> list;
    MonoBehaviour o;

    public ComboCommand(MonoBehaviour mb)
    {
        o = mb;
        list = new List<ICommand>();
    }

    public void AddStep(ICommand c)
    {
        list.Add(c);
    }

    IEnumerator ExecuteAll(bool undo = false)
    {
        foreach (ICommand c in list)
        {
            if (!undo) { c.Execute(); } else { c.Undo(); }
            yield return new WaitForSeconds(0.3f);
        }

        if (undo)
            list.Reverse();
    }

    public void Execute()
    {
        o.StartCoroutine(ExecuteAll());
    }

    public void Undo()
    {
        list.Reverse();
        o.StartCoroutine(ExecuteAll(true));
    }
}
