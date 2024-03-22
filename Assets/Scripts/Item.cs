using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
            
    }
}
