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
        // �����ʼλ��
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
            shoot.enabled = false;// �����ƶ����ƽű�
        }

        // ʹ�����ʧ�����������Ⱦ������ײ��
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // �ȴ��趨���ӳ�ʱ��
        yield return new WaitForSeconds(delayBeforeReset);

        // �����λ�����õ���ʼλ��
        transform.position = startPosition;
        if (playerMovement != null && shoot != null)
        {
            playerMovement.enabled = true;
            shoot.enabled = true;// ���������ƶ����ƽű�
        }
        // �ٴ�ʹ��ҳ���
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
