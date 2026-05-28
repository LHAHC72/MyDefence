using UnityEngine;

namespace MySample
{
    // 회전 테스트 예제 스크립트
    public class RotateTest : MonoBehaviour
    {


        #region Variables

        // 회전 속도
        public float turnSpeed = 5f;

        // 회전 값 변수
        private float x = 0;

        // 목표 오브젝트 트랜스폼 인스턴스
        public Transform target;

        // 이동 속도
        public float moveSpeed = 1.0f;


        #endregion

        #region Unity Event Method
        private void Start()
        {
           /* this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);  // y축을 회전해서 오른쪽 바라보기

            this.transform.rotation = Quaternion.Euler(0f ,90f, 0f);  // x축을 회전해서 오른쪽 바라보기

            this.transform.rotation = Quaternion.Euler(0f ,0f, 90f);  // z축을 회전해서 오른쪽 바라보기*/
        }
        #endregion

        private void Update()
        {
            x += 1;


            /*this.transform.rotation = Quaternion.Euler(x, 0, 0); // x축
            this.transform.rotation = Quaternion.Euler(0, x, 0); // y축
            this.transform.rotation = Quaternion.Euler(0, 0, x); // z축*/

            // [1] 지구의 자전 - Rotate
            // this.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);

            // [1-1] 지구의 공전 - RotateAround
            // this.transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);

            // [2] 원하는(목표) 방향을 회전

            /*// 목표 방향 구하기
            Vector3 dir = target.position - this.transform.position;

            // 목표 방향에 해당되는 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // this.transform (현재: 0,0,0) => lookRotation (목표: 0,41,0)
            // Quaternion.Lerp(Quaternion a, Quaternion b, float t);
            Quaternion qRoternion = Quaternion.Lerp(this.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
            this.transform.rotation = qRoternion;

            // Quaternion 으로부터 오일러값 구하기
            Vector3 euler = qRoternion.eulerAngles;

            //y축 회전하는 회전값을 구한다(위로 안움직이게 고정)
            this.transform.rotation = Quaternion.Euler(0f, euler.y, 0f);*/


            // 트랜스폼의 회전값을 구한 회전값에 대입
            // this.transform.rotation = lookRotation;


            // 이동 dir * Time.deltaTime * speed
            Vector3 dir = target.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);

            // transform.Translate(dir.normalized * Time.deltaTime * moveSpeed,Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed,Space.Self);    // Self를 사용했을 땐 개념이 달라서 코드도 수정됨

        }


    }
}

/*
 
- 러프 추가 설명
: a 출발지, b 도착지, t 는 출발지를 0, 도착지를 1로 가정하고 움직이는 거리. 0.1이면 10% 이동

a = 0, b = 10, t = 0.1
a = Lerp(a,b,t);

-> 한번 돌리고 결과값을 다시 a에 넣으니까

a = 1, b = 10, t = 0.1
a = Lerp(a,b,t);

-> 한번 더 돌리면 총 길이는 b-a 이므로 9가 됨. t는 a를 0, b를 1로 두었을 때 0.1 이동하는 것이기 때문에...

a = 1.9 , b = 10, t = 0.1
a = Lerp(a,b,t);

-> 총 길이 9에서 t(10% 이동) 해서 0.9 이동했으므로 1.9가 됨. 이걸 반복하면서 수렴의 형태가 됨


 
 */