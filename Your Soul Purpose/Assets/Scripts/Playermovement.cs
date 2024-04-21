using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{


    private Danger dangerComponent;
    private Collider2D dangerCollider;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public Transform characterSprite;
    public Animator anim;





    private void Start()
    {
        GameObject dangerObject = GameObject.FindGameObjectWithTag("Danger"); // 确保您已经给带有 Danger 组件的 GameObject 设置了正确的 Tag
        if (dangerObject != null)
        {
            dangerComponent = dangerObject.GetComponent<Danger>();
            dangerCollider = dangerObject.GetComponent<Collider2D>();
        }
    }
   
    
    
    
    
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
            characterSprite.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (movement.x > 0.01f)
        {
            characterSprite.localRotation = Quaternion.Euler(0, 0, 0);
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

        // Calculate local movement vector based on input and move speed
        Vector2 localMovement = movement * moveSpeed * Time.fixedDeltaTime;

        // Apply local movement in the global context
        if (transform.parent != null)
        {
            // Convert local movement to global space when the player is on a moving platform
            Vector3 globalMovement = transform.parent.TransformVector(localMovement);
            rb.MovePosition(rb.position + new Vector2(globalMovement.x, globalMovement.y));
        }
        else
        {
            // Normal movement when not on a platform
            rb.MovePosition(rb.position + localMovement);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("GG");
            dangerCollider.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("GGGG");
            dangerCollider.enabled = false;

        }
    }

}


