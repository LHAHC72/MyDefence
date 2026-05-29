using UnityEngine;
using System.Collections;



public class ShootingManager : MonoBehaviour
{
    public GameObject bulletFactory;

    // 시간 저장 변수
    public float CurrentTime = 0;

    // 총알 쿨타임 변수
    public float CreateTime = 1;

    // target 정보를 받기 위해 target을 가지고 있는 RotateCannon 스크립트를 통째로 받아옴
    public RotateCannon rotateCannonScript;


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
            // 새로운 타겟 정보 담을 오브젝트를 생성하고 'newTarget'이라는 변수에 담습니다.


            // GameObject 타입의 변수 bullet은 bulletFactory에서 받아온 오브젝트를 생성
            GameObject bullet = Instantiate(bulletFactory);

            // bullet의 위치는 Script가 적용된 위치와 동기화
            bullet.transform.position = this.transform.position;


            // target 정보 가져오기
            RotateCannon targetInfo = newTarget.GetComponent<RotateCannon>();

            // 시간 초기화
            CurrentTime = 0;

        }

    }


}
