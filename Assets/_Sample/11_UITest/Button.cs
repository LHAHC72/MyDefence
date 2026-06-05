using UnityEngine;

namespace MyDefence
{

    public class Button : MonoBehaviour
    {
        private int Score = 100;

        public void Fire()
        {
            Debug.Log("발사 하였습니다.");
        }

        public void Jump()
        {
            Debug.Log("플레이어가 점프하였습니다.");
            Score += 10;
        }
    }
}