using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumy : MonoBehaviour
{
    // 필요 속성: 이동속도
    public float speed = 5;

    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;

    private void Start()
    {
        // Vector3 dir; ##전역변수로 설정

        // 간단한 적 AI
        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다.
        int randValue = UnityEngine.Random.Range(0, 10);
        // 만약 3보다 작으면 플레이어 방향으로
        if (randValue < 3)
        {
            // 플레이어를 찾아 target으로 하고 싶다.
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다. target - me(= target <- me)
            dir = target.transform.position - transform.position;
            // 방향의 크기를 1로 하고 싶다.
            dir.Normalize();
        }
        // 그렇지 않으면 아래 방향으로 정하고 싶다
        else
        {
            dir = Vector3.down;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다
        // Vector3 dir = Vector3.down; ##전역변수로 다시 설정

        // 2. 이동하고 싶다. P(이동할위치) = P0(현재위치) + v(속도)*t(시간)
        transform.position += dir * speed * Time.deltaTime;
    }

    // 충돌 시작
    private void OnCollisionEnter(Collision other)
    {
        // 너 죽고
        Destroy(other.gameObject);
        // 나 죽자
        Destroy(gameObject);
    }
    
}
