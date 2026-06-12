using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyManager2 : MonoBehaviour
{
    // 적을 소환하는 공장
    public GameObject enemyFactory;

    // 웨이브를 저장하는 변수
    private int wave = 1;

    // UI 카운트다운
    public Text countDownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CreateMapTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnManager()
    {
        for (int i = 1; i <= wave; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);   // enemy를 공장으로 소환하고

            enemy.transform.position = transform.position;  // 내 위치에 가져다 놓고

            yield return new WaitForSeconds(0.5f);  // 0.5초의 간격 설정
        }

        wave++;
    }

    IEnumerator CreateMapTile()
    {
        for (int i = 1; i <= 5; i++)
        {
            // 스폰
            StartCoroutine(SpawnManager());
            Debug.Log($"[{wave}] 웨이브 생성");

            float timer = 5.0f;
            while (timer > 0)
            {
                if(countDownText != null)
                {
                    countDownText.text = $"다음 웨이브까지 {timer:F1}초 남았습니다";
                    countDownText.text = $"현재 웨이브 {wave}";
                }

                timer -= Time.deltaTime;

                yield return null;
            }

            // 웨이브를 살아서 클리어함
            if (GameData.Instance != null)
            {
                GameData.Instance.AddSurvivedRound();
            }
        }
        if(countDownText != null)
        {
            countDownText.text = "모든 웨이브 클리어!";
        }
    }

}
