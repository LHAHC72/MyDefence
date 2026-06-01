using UnityEngine;

namespace MySample
{
    // 기본 클래스의 싱글톤 패턴
    public class SingleTonClass
    {
        // SingletonClass 클래스의 인스턴스(객체) 정적(static) 변수 선언
        private static SingleTonClass instance;

        // public 한 속성으로 private 한 intance 에 전역적으로 접근하기


        // 1. 속성을 사용하는 경우 
        public static SingleTonClass Instance
        {
            get
            {
                if(instance == null)    // new를 한번도 안썼을 경우(한번도 가져다 쓴적이 없을 때), 싱글톤은 new를 단 한번만 사용하는 규칙이기에 한번 사용한 이후로는 사용X
                {
                    // 인스턴스 생성
                    instance = new SingleTonClass();
                }
                return instance;
            }
            
        }

        /*// 2. 함수를 사용하는 경우
        public static SingleTonClass Instance()
        {
            get
            {
                if (instance == null)    // new를 한번도 안썼을 경우(한번도 가져다 쓴적이 없을 때), 싱글톤은 new를 단 한번만 사용하는 규칙이기에 한번 사용한 이후로는 사용X
                {
                    // 인스턴스 생성
                    instance = new SingleTonClass();
                }
                return instance;
            }

        }*/

        // 필드: 인스턴스이름.number -> Instance.number
        public int number;


    }
}