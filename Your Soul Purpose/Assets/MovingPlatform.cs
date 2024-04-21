using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;  // 移动的起始点
    public Transform PointB;  // 移动的终点
    public float speed = 2.0f;  // 移动速度

    private Vector3 nextPosition;  // 下一个移动目标位置
    private bool isActive = false;

    void Start()
    {
        nextPosition = PointA.position;  // 初始设置为点A
    }

    void Update()
    {
        if (isActive)  // 只有当 isActive 为 true 时，平台才移动
        {
            // 移动平台到下一个位置
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

            // 检查是否到达目标位置
            if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
            {
                // 如果当前目标位置是点A，则下一个位置设置为点B，反之亦然
                nextPosition = nextPosition == PointA.position ? PointB.position : PointA.position;
            }
        }
    }

    // 公共方法，用来激活平台移动
    public void ActivatePlatform()
    {
        isActive = true;
    }
}
