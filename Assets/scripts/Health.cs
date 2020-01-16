using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameObject player;
    private Movement movement;

    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
  
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Movement>();
        movement = player.GetComponentInParent<Movement>();
        health = movement.getHealth();
        numOfHearts = movement.getMaxHealth();

    }

    public void Update()
    {
        health = movement.getHealth();
        if (health > numOfHearts) {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            } if (i < numOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
   

    }
}
