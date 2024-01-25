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
    [SerializeField] float _jumpHeight = 5f;

    [SerializeField] private GameObject spawnPoint;

    private void Awake()
    {
        if (_rightArrowBtn != null)
        {
            _rightArrowBtn.OnPointerDownEvent.AddListener(()=> MoveHorizontal(1));
            _rightArrowBtn.OnPointerUpEvent.AddListener(()=> MoveHorizontal(0));
        }
        if (_leftArrowBtn != null)
        {
            _leftArrowBtn.OnPointerDownEvent.AddListener(()=> MoveHorizontal(-1));
            _leftArrowBtn.OnPointerUpEvent.AddListener(() => MoveHorizontal(0));
        }
        if (_upArrowBtn != null)
        {
            _upArrowBtn.OnPointerDownEvent.AddListener(Jump);
        }
        if (_downArrowBtn != null)
        {
            _downArrowBtn.OnPointerDownEvent.AddListener(() => MoveVertical(-1));
            _downArrowBtn.OnPointerUpEvent.AddListener(() => MoveVertical(-1));
        }
    }

    private void MoveHorizontal(float direction)
    {
        _horizontal_movement = _horizontal_movement == 0 ? direction : 0f;   
    }
    private void MoveVertical(float direction)
    {
        _vertical_movement = _vertical_movement == 0 ? direction : 0f;
    }


    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, _jumpHeight, 0), ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>().AddForce(new Vector3(_moveSpeed * Time.deltaTime * _moveSpeed, 0, 0),
        //    ForceMode2D.Impulse);

        var posChangeX = _horizontal_movement * _moveSpeed * Time.deltaTime;
        var posChangeY = _vertical_movement * _moveSpeed * Time.deltaTime;
        transform.position += new Vector3(posChangeX, posChangeY, 0);
    }

    private void OnCollisionionEnter2D(Collision2D collision)
    {
        GameObject other;
        //Rigidbody2D otherRigidbody;

        if (collision.otherRigidbody.gameObject.name == "Player")
        {
            other = collision.rigidbody.gameObject;
            //otherRigidbody = collision.rigidbody;
        }
        else
        {
            other = collision.otherRigidbody.gameObject;
            //otherRigidbody = collision.otherRigidbody;
        }
        other.GetComponent<ISpawnable>().Respawn();
        //other.gameObject.transform.position = spawnPoint.transform.position;
        //otherRigidbody.velocity = Vector3.zero;


       
    }
}
