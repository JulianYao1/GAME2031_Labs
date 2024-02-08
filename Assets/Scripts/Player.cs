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

        if (Input.GetKeyDown(KeyCode.S))
        {
            ICommand c = new MoveDown(transform);
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ICommand c = new MoveUp(transform);
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ICommand c = new ChangeColour(GetComponent<Renderer>());
            gm.AddCommand(c);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ComboCommand c = new ComboCommand(this);
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new Rotate(transform));
            c.AddStep(new MoveLeft(transform));           
            c.AddStep(new MoveRight(transform));
            c.AddStep(new ChangeColour(GetComponent<Renderer>()));
            c.AddStep(new ScaleDown(transform));
            c.AddStep(new MoveRight(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new MoveLeft(transform));
            c.AddStep(new ScaleUp(transform));
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            gm.Redo();
        }
    }
}
