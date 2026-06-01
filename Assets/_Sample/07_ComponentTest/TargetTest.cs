using TMPro.EditorUtilities;
using UnityEngine;

namespace MySample
{

    // 타겟을 관리하는 클래스

    public class TargetTest : MonoBehaviour
    {
        #region Valuable

        public int a = 10;
        private int b;

        #endregion

        #region Unity Event Method

        private void Start()
        {
            // 필드 초기화
            b = 30;
        }

        #endregion

        #region Custom Method

        public void SetB(int _b)
        {
            b = _b;
        }

        public int GetB()
        {
            return b;
        }

        #endregion

    }
}