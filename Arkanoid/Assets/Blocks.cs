using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public int health;
    public int reward;
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}