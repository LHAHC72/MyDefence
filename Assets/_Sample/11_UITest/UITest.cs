using UnityEngine;

namespace MySample
{
    // UI 샘플 예제 - 버튼 호출 함수 구현
    public class UITest : MonoBehaviour
    {
        #region Custom Method
        // Fire 버튼 클릭시 호출되는 함수 - public void 버튼이름()
        // Fire 버튼에 등록되는 함수
        public void Fire()
        {
            Debug.Log("발사 하였습니다.");
        }
        
        #endregion


    }
}