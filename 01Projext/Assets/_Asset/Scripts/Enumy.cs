using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumy : MonoBehaviour
{
    // �ʿ� �Ӽ�: �̵��ӵ�
    public float speed = 5;

    // ������ ���� ������ ����� Start�� Update���� ���
    Vector3 dir;

    private void Start()
    {
        // Vector3 dir; ##���������� ����

        // ������ �� AI
        // 0���� 9���� 10���� �� �߿� �ϳ��� �������� �����´�.
        int randValue = UnityEngine.Random.Range(0, 10);
        // ���� 3���� ������ �÷��̾� ��������
        if (randValue < 3)
        {
            // �÷��̾ ã�� target���� �ϰ� �ʹ�.
            GameObject target = GameObject.Find("Player");
            // ������ ���ϰ� �ʹ�. target - me(= target <- me)
            dir = target.transform.position - transform.position;
            // ������ ũ�⸦ 1�� �ϰ� �ʹ�.
            dir.Normalize();
        }
        // �׷��� ������ �Ʒ� �������� ���ϰ� �ʹ�
        else
        {
            dir = Vector3.down;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 1. ������ ���Ѵ�
        // Vector3 dir = Vector3.down; ##���������� �ٽ� ����

        // 2. �̵��ϰ� �ʹ�. P(�̵�����ġ) = P0(������ġ) + v(�ӵ�)*t(�ð�)
        transform.position += dir * speed * Time.deltaTime;
    }

    // �浹 ����
    private void OnCollisionEnter(Collision other)
    {
        // �� �װ�
        Destroy(other.gameObject);
        // �� ����
        Destroy(gameObject);
    }
    
}
