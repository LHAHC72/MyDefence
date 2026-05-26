using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 시간을 누적할 변수
    float CurrentTime = 0;

    // 적 스폰 시간을 조절할 변수
    public float CreateTime = 1;

    // 적을 소환하는 공장
    public GameObject enemyFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;  // Time.deltaTime이 1이 되면 1초가 지났다는 뜻

        if(CurrentTime >= CreateTime)   // 만약 게임 시간이 설정해둔 스폰 시간을 넘어설 경우
        {
            GameObject enemy = Instantiate(enemyFactory);   // enemy를 공장으로 소환하고

            enemy.transform.position = transform.position;  // 내 위치에 가져다 놓고

            CurrentTime = 0;    // 시간을 0으로 초기화
        }
    }
}
