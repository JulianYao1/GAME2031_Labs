using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private MyButton _rightArrowBtn;
    [SerializeField] private MyButton _leftArrowBtn;
    [SerializeField] private MyButton _upArrowBtn;
    [SerializeField] private MyButton _downArrowBtn;
    private float _horizontal_movement = 0f;
    private float _vertical_movement = 0f;
    //[SerializeField] float _jumpHeight = 5.0f;

    private void Awake()
    {
        if (_rightArrowBtn != null)
        {
            _rightArrowBtn.OnPointerDownEvent.AddListener(()=> Move(1, ref _horizontal_movement));
            _rightArrowBtn.OnPointerUpEvent.AddListener(()=> Move(0, ref _horizontal_movement));
        }
        if (_leftArrowBtn != null)
        {
            _leftArrowBtn.OnPointerDownEvent.AddListener(()=> Move(-1, ref _horizontal_movement));
            _leftArrowBtn.OnPointerUpEvent.AddListener(() => Move(0, ref _horizontal_movement));
        }
        if (_upArrowBtn != null)
        {
            _upArrowBtn.OnPointerDownEvent.AddListener(() => Move(1, ref _vertical_movement));
            _upArrowBtn.OnPointerUpEvent.AddListener(() => Move(0, ref _vertical_movement));
        }
        if (_downArrowBtn != null)
        {
            _downArrowBtn.OnPointerDownEvent.AddListener(() => Move(-1, ref _vertical_movement));
            _downArrowBtn.OnPointerUpEvent.AddListener(() => Move(0, ref _vertical_movement));
        }
    }

    private void Move(float direction, ref float movement)
    {
        movement = movement == 0 ? direction : 0f;
    }

    //public void Jump()
    //{
    //    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, _jumpHeight, 0), ForceMode2D.Impulse);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var posChangeX = _horizontal_movement * _moveSpeed * Time.deltaTime;
        var posChangeY = _vertical_movement * _moveSpeed * Time.deltaTime;
        transform.position += new Vector3(posChangeX, posChangeY, 0);
    }
}
