using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace MyDefence {
    public class CreateCannon : MonoBehaviour
    {

        private Renderer tileRenderer;  // 색 컴포넌트 가져올 변수
        private Color originalColor;    // 원래 색 기억할 변수
        public Color hoverColor;        // 지정할 색

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 타일 색 컴포넌트 가져오기
            tileRenderer = GetComponent<Renderer>();

            // 원래 색 기억하기
            originalColor = tileRenderer.material.color;
        }

        // 마우스 올라갔을 때
        void OnMouseEnter()
        {
            // 선택한 타워가 없을 경우 색상 변경 X
            if (!BuildManager.instance.HasTowerSelected) return;

            // 지정한 색으로 변경
            tileRenderer.material.color = hoverColor;
        }
        // 마우스 나갔을 때
        void OnMouseExit()
        {
            tileRenderer.material.color = originalColor;
        }

        // 마우스를 클릭했을 때
        private void OnMouseDown()
        {
            // 문구 출력
            Debug.Log("마우스 클릭 - 여기에 터렛 설치");

            // 마우스가 UI 위에 있으면 타일 클릭 무시
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            // 선택된 타워 없다면 설치 실패
            if (!BuildManager.instance.HasTowerSelected)
            {
                Debug.Log("타워를 설치하지 못했습니다.!!");
                return; // 함수를 즉시 종료하여 아래 설치 로직이 실행 안 되게 막음
            }

            Debug.Log("마우스 클릭 - 여기에 터렛 설치");
            BuildManager.instance.BuildTurretOn(this.gameObject);





        }
    }
}