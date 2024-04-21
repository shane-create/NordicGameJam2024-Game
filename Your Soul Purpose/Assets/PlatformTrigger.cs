using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform controlledPlatform;  // 需要控制的平台

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlatformTrigger"))  // 假设子弹具有 "Bullet" 标签
        {
            controlledPlatform.ActivatePlatform();  // 激活平台移动
        }
    }
}
