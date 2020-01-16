using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour{

    [SerializeField] private bool throwable = false;
    [SerializeField] private float speed = 0.5f;
    private Rigidbody2D rb;
    private BoxCollider2D collider;

    private Vector3 movement;

    public void Start(){
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        rb = (Rigidbody2D) gameObject.AddComponent(typeof(Rigidbody2D));
        collider = (BoxCollider2D) gameObject.AddComponent(typeof(BoxCollider2D));
        setRb();
        setCollider();
        movement = new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed, Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed, 0f);
    }
    public void Update(){
        rb.MovePosition(transform.position + movement);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player"){
            Destroy(gameObject);
        }
    }

    private void setRb(){
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 0;
        rb.angularDrag = 0;
        rb.angularDrag = 0;
        rb.mass = 0.000001f;
        rb.freezeRotation = true;
    }

    private void setCollider(){
        collider.isTrigger = true;
        collider.autoTiling = true;
    }
}