using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable
{
    public void Respawn();
}

public class Element : MonoBehaviour, ISpawnable
{
    [SerializeField] private GameObject spawnPoint;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        Respawn();
    }

    public void Respawn()
    {
        Vector3 position =
            new Vector3(Random.Range(spawnPoint.transform.position.x - 10, spawnPoint.transform.position.x + 10),
                spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        gameObject.transform.position = position;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}