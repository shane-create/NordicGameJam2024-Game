using UnityEngine;
using System.Collections;
public class Danger : MonoBehaviour
{
    private Vector3 startPosition;
    public float delayBeforeReset = 2.0f;
    private Playermovement playerMovement;
    private Shooter shoot;
    public AudioSource audioSource;  
    public AudioClip deathSound;     
    void Start()
    {
        // 保存初始位置
        startPosition = transform.position;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();
        shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooter>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Danger"))
        {
            StartCoroutine(HandleDeathAndRespawn());
            
        }
    }

    IEnumerator HandleDeathAndRespawn()
    {
        Debug.Log("Player has died.");
        audioSource.PlayOneShot(deathSound);
        if (playerMovement != null && shoot != null)
        {
            playerMovement.enabled = false;
            shoot.enabled = false;// 禁用移动控制脚本
        }

        // 使玩家消失，例如禁用渲染器和碰撞器
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // 等待设定的延迟时间
        yield return new WaitForSeconds(delayBeforeReset);

        // 将玩家位置重置到初始位置
        transform.position = startPosition;
        if (playerMovement != null && shoot != null)
        {
            playerMovement.enabled = true;
            shoot.enabled = true;// 重新启用移动控制脚本
        }
        // 再次使玩家出现
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
