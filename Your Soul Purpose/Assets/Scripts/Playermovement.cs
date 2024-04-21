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

    // Update is called once per frame

    private void Start()
    {
        GameObject dangerObject = GameObject.FindGameObjectWithTag("Danger"); // ȷ�����Ѿ������� Danger ����� GameObject ��������ȷ�� Tag
        if (dangerObject != null)
        {
            dangerComponent = dangerObject.GetComponent<Danger>();
            dangerCollider = dangerObject.GetComponent<Collider2D>();
        }
    }
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
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


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = other.transform;  // ��ҳ�Ϊƽ̨���Ӷ���
            dangerCollider.enabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.parent = null;  // ������ӹ�ϵ
            dangerCollider.enabled = true;

        }
    }

}
