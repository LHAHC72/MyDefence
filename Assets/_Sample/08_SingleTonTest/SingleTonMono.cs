using UnityEngine;

namespace MySample
{

    // MonoBehaviour를 상속받은 클래스의 싱글톤 패턴

    public class SingleTonMono : MonoBehaviour
    {
        private void Start()
        {
            SingleTonClass.Instance.number = 10;
            Debug.Log(SingleTonClass.Instance.number);
        }
    }
}