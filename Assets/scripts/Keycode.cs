using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
    
}
