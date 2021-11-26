using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����Ƽ UI�� ����ϱ� ���� ���ӽ����̽�
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // ���� ���� UI
    public Text currentScoreUI;
    // ���� ����
    public int currentScore;
    // �ְ� ���� UI
    public Text bestScoreUI;
    // �ְ� ����
    public int bestScore;

    private void Start()
    {
        // ��ǥ: �ְ� ������ �ҷ��� bestScore ������ �Ҵ��ϰ� ȭ�鿡 ǥ���Ѵ�.
        // ����: 1. �ְ� ������ �ҷ��� bestScore�� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("Best Score", 0); // 0�� ����� ���� ������
        // 2. �ְ� ������ ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ� ���� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
