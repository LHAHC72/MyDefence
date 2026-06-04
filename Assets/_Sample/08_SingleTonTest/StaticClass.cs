/*using UnityEngine;

namespace MySample
{

    
    public class StaticClass
    {
        // 정적(static) 맴버 변수 = 
        public static int number = 0;

        SingleTonClass.Instance.number = 10;
        Debug.Log(SingleTonClass.Instance.number);

            // 싱글톤 패턴 클래스 인스턴스를 이용하며 맴버변수 사용하기
            // 싱글톤 패턴 클래스 new를 사용하지 않는다. 클래스 안에서 자동생성을 했기 때문
            // SingleTonClass singletonClass = new SingleTonClass(); -> X

            var singletonClassA = SingleTonClass.Instance;
        var singletonClassB = SingleTonClass.Instance;
            if (singletonClassA == singletonClassB)
            {
                Debug.Log(singletonClassA);
            }
}
}*/