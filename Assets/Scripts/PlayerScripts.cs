using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScripts : MonoBehaviour
{
    //[SerializeField] InputAction foo;
    [SerializeField] float moveSpeed = 3;
    [SerializeField] Vector2 moveDirection;
    //[SerializeField] Vector2 mousePosition;
    [SerializeField] SpriteRenderer spriteImage;
    [SerializeField] GameObject objectToClone;
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //foo.Enable();
        //InputSystem.onActionChange +=
        //    (obj, change) =>
        //    {
        //        switch (change)
        //        {
        //            case InputActionChange.ActionStarted:
        //            case InputActionChange.ActionPerformed:
        //            case InputActionChange.ActionCanceled:
        //                Debug.Log($"{((InputAction)obj).name}:{change}");
        //                break;
        //        }
        //    };
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);

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
    }

    public void Fire()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));

        GameObject spawnedObject = Instantiate(objectToClone);
        spawnedObject.transform.position = worldPosition;
    }
}
