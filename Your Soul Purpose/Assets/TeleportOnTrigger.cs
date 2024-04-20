using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform teleportDestination;  // 传送目标位置的引用

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞的对象的标签是否是 "TeleportTrigger"
        if (collision.collider.CompareTag("TeleportTrigger"))
        {
            // 获取碰撞点
            Vector2 contactPoint = collision.contacts[0].point;

            // 将玩家或其他对象传送到碰撞点位置或指定的目标位置
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // 传送到碰撞点或预定义的目标位置
                player.transform.position = contactPoint; // 或 teleportDestination.position，视需求而定

                // 如果你想在传送时销毁碰撞的对象
                // Destroy(collision.gameObject);
            }
        }
    }
}
