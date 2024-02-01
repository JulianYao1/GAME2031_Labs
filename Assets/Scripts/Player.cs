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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            gm.Undo();
        }
    }
}
