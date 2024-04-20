using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform teleportDestination;  // ����Ŀ��λ�õ�����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �����ײ�Ķ���ı�ǩ�Ƿ��� "TeleportTrigger"
        if (collision.collider.CompareTag("TeleportTrigger"))
        {
            // ��ȡ��ײ��
            Vector2 contactPoint = collision.contacts[0].point;

            // ����һ����������͵���ײ��λ�û�ָ����Ŀ��λ��
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // ���͵���ײ���Ԥ�����Ŀ��λ��
                player.transform.position = contactPoint; // �� teleportDestination.position�����������

                // ��������ڴ���ʱ������ײ�Ķ���
                // Destroy(collision.gameObject);
            }
        }
    }
}
