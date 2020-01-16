using UnityEngine;
using Pathfinding;

public class WindigoScript : MonoBehaviour{

    private AIPath aiPath;
    [SerializeField] private float stunTime;

    private float defaultSpeed;

    private float timeStopStun;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "BulletHit"){
            aiPath.speed = 0;
            timeStopStun = Time.time + stunTime;
        }
    }    

    void Start(){
        aiPath = gameObject.GetComponent<AIPath>();
        defaultSpeed = aiPath.speed;
    }

    void Update(){
        if(Time.time > timeStopStun){
            aiPath.speed = defaultSpeed;
        }else{
            aiPath.speed = 0;
        }
    }
}
