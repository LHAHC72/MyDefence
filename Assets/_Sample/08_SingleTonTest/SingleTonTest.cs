/*using UnityEngine;

namespace MySample
{

    public class SingleTonTest : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            // 정적맴버변수 사용하기(전역적 접근) :  클래스이름.맴버변수이름
            StaticClass.number = 20;
            Debug.Log(StaticClass.number.ToString());

            // 싱글톤 패턴 클래스 인스턴스를 이용하여 맴버변수 사용하기 : 클래스이름.인스턴스이름.맴버변수이름
            SingleTonClass.Instance.number = 10;
            Debug.Log(SingleTonClass.Instance.number.ToString());

           
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
*//*
 
 디자인 패턴
 
싱글톤(singleton) 패턴
: 프로젝트 내에서 하나의 인스턴스만 존재하게 한다. new를 한번만 한다.
: 클래스의 인스턴스에게 전역적으로 접근이 가능하다. 인스턴스 변수를 static으로 선언

: 싱글톤 클래스의 인스턴스 변수는 자신 클래스의 코드블록 안에서 선언하고 객체를 가져온다


 */
