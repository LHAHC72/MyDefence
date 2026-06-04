using Unity.Hierarchy;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

namespace MyDefence
{
    public class CameraMove : MonoBehaviour
    {
        public float moveSpeed = 5; // 움직이는 속도
        public float zoomSpeed = 1000f; // 줌 속도
        private bool isCannotMove = false; // 카메라 이동 제한, // true : 이동 불능, false : 이동 가능
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {
            

            // 카메라 이동기능 막기
            // 토글 버튼 누르면 카메라 이동 막는다. : flase일때 누르면 true로 바꾸고
            // 토근 버튼 다시 누르면 다시 움직이게 : true일 때 누르면 false로 바꿈 
            if (Input.GetButtonDown("Esc Toogle"))
            {
                // isCannotMove = (isCannotMove == true) ? false : true;
                isCannotMove = !isCannotMove;
                
            }

            if (isCannotMove) // isCannotMove == true
            {
                return;
            }


            // 상하좌우 이동 입력
            float hValue = Input.GetAxis("Horizontal");
            float vValue = Input.GetAxis("Vertical");

            // 줌
            // float zoom = Input.mouseScrollDelta.y * (-1);
            // float zoomIn = zoom * zoomSpeed;

            // 마우스 따라 이동
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;


            if (mouseX <= 20 && mouseX >= 0)
            {
                hValue = -1f;
            }

            if (mouseX >= Screen.width - 20 && Screen.width >= mouseX)
            {
                hValue = 1f;
            }

            if (mouseY <= 20 && mouseY >= 0)
            {
                vValue = -1f;
            }

            if (mouseY >= Screen.height - 20 && Screen.height >= mouseY)
            {
                vValue = 1f;
            }

            Vector3 moveDirection = new Vector3(hValue, 0, vValue);

            // Mouse ScrollWhell 이라는 엑시스 값을 이용한 줌인아웃
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 CameraZoom = this.transform.position;

            // 최대값, 최소값 설정
            CameraZoom.y = Mathf.Clamp(CameraZoom.y, 10f, 25f);

            // y축만 이동 연산 - 보정 계수 적용
            CameraZoom.y += scroll * Time.deltaTime * zoomSpeed * (-1f);
            this.transform.position = CameraZoom;



            // 상하좌우, 줌
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        }
    }
}