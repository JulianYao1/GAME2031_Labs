using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Stack<ICommand> _CommandBuffer = new Stack<ICommand>();

    // Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // Destroy(this);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddCommand(ICommand c)
    {
        c.Execute();
        _CommandBuffer.Push(c);
    }

    public void Undo()
    {
        if (_CommandBuffer.Count > 0)
        {
            ICommand c = _CommandBuffer.Pop();
            c.Undo();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
