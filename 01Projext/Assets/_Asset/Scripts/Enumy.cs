using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적이 다른 물체와 충돌했을 때 폭발 효과를 발생시키고 싶다.
// 순서: 1. 적이 다른 물체와 충돌했으니까.
//       2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
//       3. 폭발 효과를 발생(위치)시키고 싶다.
// 필요 속성: 폭발 공장 주소(외부에서 값을 넣어준다.)

public class Enumy : MonoBehaviour
{
    // 필요 속성: 이동속도
    public float speed = 5;
    GameObject player;
    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;
    public GameObject explosionFactory;

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
    // 1. 적이 다른 물체와 충돌했으니까.
    private void OnCollisionEnter(Collision collision)
    {
        // 2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
        GameObject explosion = Instantiate(explosionFactory);

        // 3. 폭발 효과를 발생(위치)시키고 싶다.
        explosion.transform.position = transform.position;

        // 너 죽고
        Destroy(collision.gameObject);
        // 나 죽자
        Destroy(gameObject);

        // 에너미를 잡을 때마다 현재 점수를 표시하고 싶다.
        // 1. 씬에서 ScoreManager 객체를 찾아오자.
        GameObject smObject = GameObject.Find("ScoreManager");
        // 2. ScoreManager 게임 오브젝트에서 얻어온다.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        // 3. ScoreManager 클래스의 속성에 값을 할당한다.
        sm.currentScore++;
        // 4. 화면에 점수 표시하기
        sm.currentScoreUI.text = "현재 점수 : " + sm.currentScore;

    }
    
}
