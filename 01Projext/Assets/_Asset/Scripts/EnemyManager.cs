using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ���� �ð�
    float currentTime;
    // ���� �ð�
    public float createTime = 1;
    // �� ����
    public GameObject enemyFactory;

    // �ּ� �ð�
    float minTime = 1;
    // �ִ� �ð�
    float maxTime = 5;

    private void Start()
    {
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. �ð��� �帣�ٰ�
        currentTime += Time.deltaTime;
        
        // 2. ���� ���� �ð��� ���� �ð��� �Ǹ�
        if (currentTime > createTime)
        {
            // 3. �� ���忡�� ���� ������
            GameObject enemy = Instantiate(enemyFactory);
            // �� ��ġ�� ���� ���� �ʹ�.
            enemy.transform.position = transform.position;

            // ���� ������ �� ���� ���� �ð��� �ٽ� �����ϰ� �ʹ�.
            currentTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
