using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class CreateCannon : MonoBehaviour
    {
        private Renderer tileRenderer;  // 타일의 Renderer 컴포넌트를 가져올 변수
        private Color originalColor;    // 타일의 원래 색상을 기억할 변수
        public Color hoverColor;        // 마우스가 올라갔을 때 지정할 하이라이트 색상

        void Start()
        {
            // 타일의 Renderer 컴포넌트 가져오기
            tileRenderer = GetComponent<Renderer>();

            // 초기 시작할 때의 원래 색상을 기억해 둡니다.
            originalColor = tileRenderer.material.color;
        }

        // 1. 마우스가 타일 위로 올라갔을 때 (Hover Start)
        void OnMouseEnter()
        {
            // [과제 2-4] 만약 저장된(선택된) 타워가 없으면 타일의 메터리얼(색상)이 변경되지 않게 합니다.
            if (!BuildManager.instance.HasTowerSelected) return;

            // 선택된 타워가 있을 때만 지정한 하이라이트 색으로 변경
            tileRenderer.material.color = hoverColor;
        }

        // 2. 마우스가 타일 밖으로 나갔을 때 (Hover End)
        void OnMouseExit()
        {
            // [과제 2-4] 마찬가지로 타워가 선택되어 색이 바뀌었던 상태였을 때만 원상복구 프로세스를 태웁니다.
            if (!BuildManager.instance.HasTowerSelected) return;

            // 원래 색상으로 되돌리기
            tileRenderer.material.color = originalColor;
        }

        // 3. 마우스로 이 타일을 클릭했을 때
        private void OnMouseDown()
        {
            // [과제 3] 타일 위에 버튼(UI)이 있을 경우 타일 선택 또는 타워 설치가 안 되게 하기
            // 이 체크는 함수의 '가장 첫 줄'에 와야 UI 클릭 시 아래 로그나 로직이 작동하지 않습니다.
            /*if (EventSystem.current.IsPointerOverGameObject())
            {
                return; // UI 클릭 중이므로 타일 클릭 이벤트를 즉시 무시하고 종료
            }*/

            // [과제 2-1] 만약 저장된 타워가 없으면(선택 버턴을 누르지 않으면) 설치 실패 처리
            if (!BuildManager.instance.HasTowerSelected)
            {
                Debug.Log("타워를 설치하지 못했습니다.!!");
                return; // 함수를 즉시 종료하여 아래의 실제 설치 로직이 실행되지 않게 막음
            }

            Debug.Log($"[타일] 마우스 클릭 감지됨!");

            // [과제 2-3 & 과제 4-3] 위 조건들을 다 통과했다면 선택된 타워를 이 타일에 설치합니다.
            Debug.Log("마우스 클릭 - 여기에 터렛 설치");
            BuildManager.instance.BuildTower(this.transform.position);

            // 타워가 성공적으로 설치되었으므로, 마우스 오버 상태가 유지되더라도 원래 색상으로 고정해줍니다.
            originalColor = tileRenderer.material.color;
        }
    }
}