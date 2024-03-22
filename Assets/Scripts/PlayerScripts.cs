using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScripts : MonoBehaviour
{
    [SerializeField]
    InputAction foo;
    [SerializeField] float moveSpeed = 3;
    [SerializeField] Vector2 moveDirection;
    [SerializeField] SpriteRenderer spriteImage;

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
                    case InputActionChange.ActionPerformed:
                    case InputActionChange.ActionCanceled:
                        Debug.Log($"{((InputAction)obj).name}:{change}");
                        break;
                }
            };
    }

    // Update is called once per frame
    void Update()
    {
        //v = foo.ReadValue<Vector2>();

        Vector2 inputVector = foo.ReadValue<Vector2>();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (moveDirection.x > 0)
        {
            Quaternion rotationRight = Quaternion.Euler(0f, 0f, 0f);
            spriteImage.transform.rotation = rotationRight;
        }
        else if (moveDirection.x < 0)
        {
            Quaternion rotationLeft = Quaternion.Euler(0f, 180f, 0f);
            spriteImage.transform.rotation = rotationLeft;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        var a = context.action;
        moveDirection = a.ReadValue<Vector2>();
        Debug.Log("V");
    }
    
}
