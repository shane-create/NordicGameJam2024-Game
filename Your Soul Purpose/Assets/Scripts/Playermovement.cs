using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public Animator anim;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool walking = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f;
        anim.SetBool("walk", walking);

        if (movement.x < -0.01f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x > 0.01f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        bool movingNorth = movement.y > 0.01f;
        anim.SetBool("walk_N", movingNorth);

        bool movingSouth = movement.y < -0.01f;
        anim.SetBool("walk_S", movingSouth);


}

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
