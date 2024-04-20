using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float timeToDisappear = 5f;  // 设置消失时间为5秒
    private float timer = 0;            // 计时器
    private bool playerOnTop = false;   // 玩家是否在物体上的标志

    void Update()
    {
        if (playerOnTop)
        {
            timer += Time.deltaTime;  // 玩家在物体上，则开始计时
            if (timer >= timeToDisappear)
            {
                gameObject.SetActive(false);  // 时间到，物体消失
            }
        }
        else
        {
            timer = 0;  // 玩家不在物体上，重置计时器
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // 检查碰撞的对象是否为玩家
        {
            playerOnTop = true;  // 玩家进入，开始计时
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // 玩家离开
        {
            playerOnTop = false;  // 停止计时
        }
    }
}
