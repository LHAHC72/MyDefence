using UnityEngine;
using UnityEngine.Rendering;

namespace MyDefence
{

    public class RotateCannon : MonoBehaviour
    {
        #region 시간계산 위한 변수
        // 적 탐색 타이머
        private float CurrentTime = 0;
        private float CreateTime = 0.3f;

        // 발사 타이머
        public float fireCurrentTime = 0;
        public float fireCreateTime = 1f;

        // 탄환 발사
        public GameObject bulletPrefab;     // 탄환 프리팹 오브젝트, 사본을 프리팹에 만들기 위해
        public Transform firePoint;         // 파이어 포인트(탄환이 생성되는 위치)

        #endregion

        #region 전역변수

        // 공격 사거리
        public float attackRange = 7f;

        // 감지한 적들을 저장해둘 배열
        private GameObject[] enemies;

        // 최소값을 구하기 위한 엄청 큰 값
        float minValue = float.MaxValue;

        // 가장 가까운 오브젝트를 저장할 변수
        GameObject minObject = null;

        // 타겟을 저장할 변수
        public Transform target;




        #endregion



        void Start()
        {

        }


        void Update()
        {

            #region 가장 가까운 적 검색
            // 적 검색(최적화 위해 0.3초에 한번씩 검색)
            CurrentTime += Time.deltaTime;

            if (CurrentTime >= CreateTime)
            {
                // 초기화
                minValue = float.MaxValue;
                minObject = null;

                // "Enemy" 태그가 붙은 오브젝트들을 enemies 배열에 저장
                enemies = GameObject.FindGameObjectsWithTag("Enemy");

                // 


                foreach (GameObject enemy in enemies)
                {
                    // 변수 distace 에 오브젝트와 터렛간에 거리를 구하기
                    float distace = Vector3.Distance(this.transform.position, enemy.transform.position);

                    // 가장 가까운(최소값) 오브젝트 비교하기, 그 오브젝트를 가장 가까운 오브젝트로 저장
                    if (distace < minValue)
                    {
                        this.minValue = distace;
                        minObject = enemy;
                    }

                }

                // 각 변수 초기화
                CurrentTime = 0;
            }
            #endregion

            #region 회전
            // 적을 찾지 못했을 때는 회전X, 찾았을 때만 회전 실행 + 총알 출발
            if (minObject != null)
            {

                // 회전
                Vector3 dir = minObject.transform.position - transform.position;
                Quaternion target = Quaternion.LookRotation(dir);
                transform.rotation = target;

                // 총알
                fireCurrentTime += Time.deltaTime;

                if (fireCurrentTime >= fireCreateTime)
                {
                    Shoot();
                    fireCurrentTime = 0;
                }


            }
            #endregion

        }

        private void OnDrawGizmos()
        {
            // 기즈모 색을 빨강으로
            Gizmos.color = Color.red;

            // 기즈모의 모양은 원, 오브젝트 위치를 중심으로 반지름은 attackRange만큼.
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

        public void Shoot()
        {
            // 총구 위치에 탄환 객체 사본 생성
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            BulletMove bullet = bulletGo.GetComponent<BulletMove>();    // 탄환 오브젝트에 부탁되어 있는 Bullet 클래스의 인스턴스 가져오기

            // 타겟 정보를 bullet에게 넘겨준다
            if (bullet != null)
            {
                bullet.SetTarget(minObject.transform);
            }
        }
    }
}