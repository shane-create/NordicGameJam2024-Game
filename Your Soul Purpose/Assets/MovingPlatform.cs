using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;  // �ƶ�����ʼ��
    public Transform PointB;  // �ƶ����յ�
    public float speed = 2.0f;  // �ƶ��ٶ�

    private Vector3 nextPosition;  // ��һ���ƶ�Ŀ��λ��

    void Start()
    {
        nextPosition = PointA.position;  // ��ʼ����Ϊ��A
    }

    void Update()
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
