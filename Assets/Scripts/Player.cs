using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ICommand c = new MoveRight(transform);
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ICommand c = new MoveLeft(transform);
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ComboCommand c = new ComboCommand(this);
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));           
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            gm.Undo();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            gm.UndoAll();
        }
    }
}
