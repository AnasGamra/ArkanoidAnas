using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 17.0f;

    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        score = 0;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.name == "Racket"){

            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if(col.gameObject.tag == "Block")
        {
            if (col.gameObject.GetComponent<Blocks>().health - 1 <= 0)
            {
                score += col.gameObject.GetComponent<Blocks>().reward;
                scoreText.text = score.ToString();
            }
        }
    } 
}
