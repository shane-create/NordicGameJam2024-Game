using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{


    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public Transform characterSprite;
    public Animator anim;

    private List<Collider2D> dangerColliders = new List<Collider2D>();



    private void Start()
    {
        // 找到所有带有 "Danger" 标签的 GameObjects 并获取它们的 Collider2D
        GameObject[] dangerObjects = GameObject.FindGameObjectsWithTag("Danger");
        foreach (GameObject obj in dangerObjects)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();
            if (collider != null)
            {
                dangerColliders.Add(collider);
            }
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
            SetDangerCollidersEnabled(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("GGGG");
            SetDangerCollidersEnabled(true);

        }
    }
    private void SetDangerCollidersEnabled(bool enabled)
    {
        foreach (Collider2D collider in dangerColliders)
        {
            collider.enabled = enabled;
        }
    }
}


