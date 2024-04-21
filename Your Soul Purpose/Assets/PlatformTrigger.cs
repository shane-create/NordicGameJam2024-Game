using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform controlledPlatform;  // ��Ҫ���Ƶ�ƽ̨

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlatformTrigger"))  // �����ӵ����� "Bullet" ��ǩ
        {
            controlledPlatform.ActivatePlatform();  // ����ƽ̨�ƶ�
        }
    }
}
