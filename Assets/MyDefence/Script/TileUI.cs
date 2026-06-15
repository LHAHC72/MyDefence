using UnityEngine;

namespace MyDefence
{

    public class TileUI : MonoBehaviour
    {

        // 타일 UI를 관리하는 클래스
        // 선택된 타일의 정보(위치, 상태, 타일blueprint 등)를 가져와 구현
        #region Variables
        public GameObject ui; // 타일 UI 게임 오브젝트
        #endregion

        #region
        // 타일 UI 보이기
        public void ShowTileUI()
        {
            ui.SetActive(true);
        }

        // 타일 UI 숨기기
        public void HideTileUI()
        {
            ui.SetActive(false);
        }
        #endregion

        


    }
}