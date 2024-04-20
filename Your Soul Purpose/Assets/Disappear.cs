using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float timeToDisappear = 5f;  // ������ʧʱ��Ϊ5��
    private float timer = 0;            // ��ʱ��
    private bool playerOnTop = false;   // ����Ƿ��������ϵı�־

    void Update()
    {
        if (playerOnTop)
        {
            timer += Time.deltaTime;  // ����������ϣ���ʼ��ʱ
            if (timer >= timeToDisappear)
            {
                gameObject.SetActive(false);  // ʱ�䵽��������ʧ
            }
        }
        else
        {
            timer = 0;  // ��Ҳ��������ϣ����ü�ʱ��
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // �����ײ�Ķ����Ƿ�Ϊ���
        {
            playerOnTop = true;  // ��ҽ��룬��ʼ��ʱ
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // ����뿪
        {
            playerOnTop = false;  // ֹͣ��ʱ
        }
    }
}
