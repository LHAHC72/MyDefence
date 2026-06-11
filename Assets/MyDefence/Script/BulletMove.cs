using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{

    public class BulletMove : MonoBehaviour
    {
        #region Variables

        private Transform target;    // 이동 목표 오브젝트의 트랜스폼 인스턴스

        public float moveSpeed = 50f;     // 탄환 이동 속도

        public GameObject bulletimpactPrefab;   // 임팩트 파티클 게임 오브젝트 인스턴스

        #endregion

        #region #region Custom Method
        // 타겟 설정하기
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        void HitTarget()
        {
            // 불렛이 적을 타격할 때 불릿이 부서져서 파편이 날아가는 효과
            if (bulletimpactPrefab) // == bulletImpactPrefab != null
            {
                GameObject effectGo = Instantiate(bulletimpactPrefab, this.transform.position, Quaternion.identity);
                Destroy(effectGo, 3f);
            }
            // 타겟, 탄환 게임 오브젝트 kill
            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }
        
        #endregion                        


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // 타겟 검증
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            // 충돌 판정

            // 남은 거리
            float distace = Vector3.Distance(this.transform.position, target.position);

            // 이번 프레임의 이동거리 = 프레임 한번의 이동 거리 = Time.delteTime * 이동 속도
            float distaceThisFrame = Time.deltaTime * moveSpeed;

            if (distace <= distaceThisFrame)
            {
                HitTarget();
            }

            // 타겟을 향해 이동 : dir, Timedelta, speed
            Vector3 dir = target.position - transform.position;

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            

            


        }
    }
}