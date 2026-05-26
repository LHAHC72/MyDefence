using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // 게임 오브젝트의 이동 
    // 이동 목표지점 변수 선언 및 초기화
    private Vector3 targetPosition = new Vector3(7f,1f,8f);

    // 이동 목표 위치에 있는 오브젝트의 transform 인스턴스 선언, 생성(new)
    public Transform target;

    // 이동속도를 저장하는 변수를 선언하고 초기화
    public float speed = 10f;

    void Start()
    {
        // this.gameObject.transform
        // this.transform.gameObject

        // this.gameObject 또는 gameObject  MoveTest 스크립트가 붙어있는 게임 오브젝트의 객체(인스턴스)
        // this.gameObject.transform 또는 gameObject.transform
        // this.Transform 또는 Transform 

        // this.transform.position = new Vector3(7f, 1f, 8f);
        // this.gameObjet.transform.position = new Vector3(7f, 1f, 8f);
        // this.gameObject.transform.position = targetPosition;   // 위와 같은 뜻

        // this.transform.position = targetPosition;

        // Debug.Log($"타겟 위치: {target.position}");
        // this.transform.position = target.position;

    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 위치를 앞으로 이동, z 값이 증가한다.
        // this.transform.position 연산
        // this.transform.position.z += 1.0f;  불가능, vector 연산 해줘야함
        // this.transform.position += new Vector3(0f, 0f, 0.1f);
        // this.transform.position += Vector3.forward;      Vector(0f,0f,1f);


        // 앞방향으로 1초에 speed(속도값) 만큼 이동
        // this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * speed;

        // 타켓까지 이동(dir(방향)으로 이동, Time.deltaTime, speed)
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.Self);

        this.transform.position += Vector3.forward * Time.deltaTime * speed;
       
        // 이동요소
        // 방향 : 이동할 방향 지정
        // Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다.
        // 속도(speed) : 이동의 빠르기를 지정
        
    }
}

/*
 
n 프레임 : 초당 n번 실행(보여주기)
20 프레임 : 초당 20번 실행
20 프레임이면 1프레임당 = 0.05초

ex) 성능이 좋은 컴 10프레임, 안좋은 컴 2프레임

성능이 좋은 컴
- Time.deletaTime을 고려하지 않을 경우 = 1초에 10만큼 이동
- Time.deletaTime을 고려하는 경우 = 1초에 10만큼 이동 (* Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime: 0.1f 

this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.1씩 증가

= 1만큼 이동

성능이 나쁜 컴
- Time.deletaTime을 고려하지 않을 경우 = 1초에 2만큼 이동
- Time.deletaTime을 고려하는 경우 = 1초에 10만큼 이동 (* Time.deltaTime) : 1초에 1만큼 이동
Time.deltaTime: 0.1f 

this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.5씩 증가
this.transform.position += new Vector3(0f,0f,1f) * Time.deltaTime;  = 0.5씩 증가

= 1만큼 이동

 */
