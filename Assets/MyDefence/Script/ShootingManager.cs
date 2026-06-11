using UnityEngine;
using System.Collections;



public class ShootingManager : MonoBehaviour
{
    public GameObject bulletFactory;

    // 시간 저장 변수
    public float CurrentTime = 0;

    // 총알 쿨타임 변수
    public float CreateTime = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // 시간 계산
        CurrentTime += Time.deltaTime;

        // 시간 올라가다가 정해진 시간 넘어서면
        if(CurrentTime >= CreateTime)
        {
            

            // GameObject 타입의 변수 bullet은 bulletFactory에서 받아온 오브젝트를 생성
            GameObject bullet = Instantiate(bulletFactory);

            // bullet의 위치는 Script가 적용된 위치와 동기화
            bullet.transform.position = this.transform.position;

            // 시간 초기화
            CurrentTime = 0;

        }

    }


}
