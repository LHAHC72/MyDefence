using UnityEngine;

namespace MySample
{
    // 의자의 이동을 관리하는 클래스
    public class NewMonoBehaviourScript : MonoBehaviour
    {


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.back * 5 * Time.deltaTime);
        }
    }
}