using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start() {
        Destroy(gameObject, 5f); //destory after 5 seconds if not destoyed otherwise
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
    
    private void Update()
    {
        transform.position += transform.right * 0.15f;
    }
}