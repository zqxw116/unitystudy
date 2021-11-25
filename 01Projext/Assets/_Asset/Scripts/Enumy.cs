using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ���� �ٸ� ��ü�� �浹���� �� ���� ȿ���� �߻���Ű�� �ʹ�.
// ����: 1. ���� �ٸ� ��ü�� �浹�����ϱ�.
//       2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
//       3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
// �ʿ� �Ӽ�: ���� ���� �ּ�(�ܺο��� ���� �־��ش�.)

public class Enumy : MonoBehaviour
{
    // �ʿ� �Ӽ�: �̵��ӵ�
    public float speed = 5;
    GameObject player;
    // ������ ���� ������ ����� Start�� Update���� ���
    Vector3 dir;
    public GameObject explosionFactory;

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
    // 1. ���� �ٸ� ��ü�� �浹�����ϱ�.
    private void OnCollisionEnter(Collision collision)
    {
        // 2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
        GameObject explosion = Instantiate(explosionFactory);

        // 3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
        explosion.transform.position = transform.position;

        // �� �װ�
        Destroy(collision.gameObject);
        // �� ����
        Destroy(gameObject);

        // ���ʹ̸� ���� ������ ���� ������ ǥ���ϰ� �ʹ�.
        // 1. ������ ScoreManager ��ü�� ã�ƿ���.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager ���� ������Ʈ���� ���´�.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
        sm.currentScore++;
        // 4. ȭ�鿡 ���� ǥ���ϱ�
        sm.currentScoreUI.text = "���� ���� : " + sm.currentScore;

    }
    
}
