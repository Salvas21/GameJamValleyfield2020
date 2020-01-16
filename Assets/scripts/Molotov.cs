using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Molotov : MonoBehaviour{
    [SerializeField] private float fireSpread = 2;
    [SerializeField] public double lifeTime = 3;
    [SerializeField] public float throwForce = 1;
    private double currentLifeTime;
    private double deadTime = 0;
    private BoxCollider2D collider;
    private Rigidbody2D rb;
    private Vector3 targetPos;
    private float sizeGrowFactor;
    private double nextTime;
    public void Start(){
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        rb = (Rigidbody2D) gameObject.AddComponent(typeof(Rigidbody2D));
        collider = (BoxCollider2D) gameObject.AddComponent(typeof(BoxCollider2D));
        setRb();
        setCollider();
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GameObject.FindObjectOfType<Camera>().nearClipPlane));
        rb.MovePosition( transform.position +  new Vector3(target.x - gameObject.transform.position.x, target.y - gameObject.transform.position.y, 0f));
        sizeGrowFactor = fireSpread / (float) lifeTime;
    }

    public void Update(){
        if(deadTime == 0 && rb.velocity == Vector2.zero){
            deadTime = Time.time + lifeTime;
        }else if(deadTime !=0 && Time.time >= deadTime){
            Destroy(gameObject);
        }else if(deadTime != 0){
            updateFireSpred();    
        }
    }

    private void updateFireSpred(){
        if(nextTime < Time.time){
            nextTime = Time.time + lifeTime / 4;
            transform.localScale = transform.localScale + new Vector3(sizeGrowFactor, sizeGrowFactor);
            Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            gameObject.GetComponent<BoxCollider2D>().size = S;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
        }
    }

   private void setRb(){
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 0;
        rb.drag = 25;
        rb.angularDrag = 0f;
        rb.mass = 0.0001f;
        rb.freezeRotation = true;
    }

    private void setCollider(){
        collider.isTrigger = true;
        collider.autoTiling = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Player"){
            rb.velocity = Vector3.zero;
        }
    }
}
