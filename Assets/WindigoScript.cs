using UnityEngine;

public class WindigoScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Bullet")
        {
            //Do absolutely nothing
        }
    }
}
