using UnityEngine;

namespace MySample
{
    // 사각형 정보를 관리하는 구조체

    public struct CBox
    {
        public float x; // x좌표
        public float y; // y좌표
        public float w; // w좌표
        public float h; // h좌표
    }

    // 원의 정보를 관리하는 구조체
    public struct CCircle
    {
        public float x;
        public float y;
        public float r;
    } 

    public class HitTest : MonoBehaviour
    {
        #region Custom Method
        // 매개 변수로 받은 두개의 Box가 충돌했는지 체크하는 함수
        // 충돌 했으면 true 반환, 아니면 false 반환
        private bool CheckHitBox(CBox a, CBox b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);

            if(xDistance <= (a.w/2 + b.w/2) && yDistance <= (a.h/2 + b.h / 2))
            {
                return true;
            }

            return false;
        }

        
        public bool CheckHitCircle(CCircle a, CCircle b)
        {
            float xDistance = (a.x < b.x) ? (b.x - a.x) : (a.x - b.x);
            float yDistance = (a.y < b.y) ? (b.y - a.y) : (a.y - b.y);

            // 두 원 중점간의 거리
            float distace = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

            if(distace < (a.r + b.r))
            {
                return true;
            }
            return false;
        }

        // 도착 판정으로 충돌체크
        // 두 오브젝트 간의 거리가 일정 거리(0.5f) 안에 있으면 충돌이라고 판정
        public bool CheckArrivePosition(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);

            if(distance < 0.5f)
            {
                return true;
            }
            return false;
        }



        // 이동시 타겟까지 남은 거리와 이번 프레임에 이동거리를 비교하여 충돌판정
        public float moveSpeed = 10f;

        public bool CheckPassPosition(Transform target)
        {
            // 남은 거리
            float distace = Vector3.Distance(this.transform.position, target.position);

            // 이번 프레임의 이동거리 = 프레임 한번의 이동 거리 = Time.delteTime * 이동 속도
            float distaceThisFrame = Time.deltaTime * moveSpeed;

            if (distace <= distaceThisFrame)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}