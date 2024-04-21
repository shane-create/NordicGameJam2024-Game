using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;  // �ƶ�����ʼ��
    public Transform PointB;  // �ƶ����յ�
    public float speed = 2.0f;  // �ƶ��ٶ�

    private Vector3 nextPosition;  // ��һ���ƶ�Ŀ��λ��
    private bool isActive = false;

    void Start()
    {
        nextPosition = PointA.position;  // ��ʼ����Ϊ��A
    }

    void Update()
    {
        if (isActive)  // ֻ�е� isActive Ϊ true ʱ��ƽ̨���ƶ�
        {
            // �ƶ�ƽ̨����һ��λ��
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

            // ����Ƿ񵽴�Ŀ��λ��
            if (Vector3.Distance(transform.position, nextPosition) < 0.1f)
            {
                // �����ǰĿ��λ���ǵ�A������һ��λ������Ϊ��B����֮��Ȼ
                nextPosition = nextPosition == PointA.position ? PointB.position : PointA.position;
            }
        }
    }

    // ������������������ƽ̨�ƶ�
    public void ActivatePlatform()
    {
        isActive = true;
    }
}