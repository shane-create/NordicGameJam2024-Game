using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bounceForce = 10f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player2")
        {
            Vector2 reflectDirection = Vector2.Reflect(transform.up, collision.contacts[0].normal);
            GetComponent<Rigidbody2D>().velocity = reflectDirection * bounceForce;
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            // Ó¦ÓÃÐý×ª
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

    }
}


