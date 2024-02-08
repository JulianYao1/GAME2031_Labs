using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

<<<<<<< Updated upstream
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private MyButton _rightArrowBtn;
    [SerializeField] private MyButton _leftArrowBtn;
    [SerializeField] private MyButton _upArrowBtn;
    [SerializeField] private MyButton _downArrowBtn;
    private float _horizontal_movement = 0f;
    private float _vertical_movement = 0f;
    [SerializeField] float _jumpHeight = 1f;

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
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, _jumpHeight * 0.2f, 0), ForceMode2D.Impulse);
=======
    [SerializeField] private Animator _animator;
    [SerializeField] private string _animParamSpeed;
    [SerializeField] private string _animParamIsWalking;

    private int _speedHash, _isWalking;

    private void Awake()
    {
        _speedHash = Animator.StringToHash(_animParamSpeed);
        _isWalking = Animator.StringToHash(_animParamIsWalking);
>>>>>>> Stashed changes
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(_vertical_movement * Time.deltaTime * _moveSpeed, 0, 0),
            ForceMode2D.Impulse);

<<<<<<< Updated upstream
        var posChangeX = _horizontal_movement * _moveSpeed * Time.deltaTime;
        var posChangeY = _vertical_movement * _moveSpeed * Time.deltaTime;
        transform.position += new Vector3(posChangeX, posChangeY, 0);
=======
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
            //c.AddStep(new ChangeColour(GetComponent<Renderer>()));
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
>>>>>>> Stashed changes
    }
}
