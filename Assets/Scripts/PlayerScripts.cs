using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField]
    InputAction foo;

    // Start is called before the first frame update
    void Start()
    {
        foo.Enable();
        InputSystem.onActionChange +=
            (obj, change) =>
            {
                switch (change)
                {
                    case InputActionChange.ActionStarted:
                        break;
                    case InputActionChange.ActionPerformed:
                        break;
                    case InputActionChange.ActionCanceled:
                        Debug.Log($"{((InputAction)obj).name}:{change}");
                        break;
                }
            };
    }

    // Update is called once per frame
    void Update()
    {
        var v = foo.ReadValue<Vector2>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        var a = context.action;
        var v = a.ReadValue<Vector2>();
        Debug.Log("V");
        transform.Translate(v * Time.deltaTime);
    }
    
}
