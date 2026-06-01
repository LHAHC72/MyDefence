using NUnit.Framework.Internal.Commands;
using Unity.VisualScripting;
using UnityEngine;

namespace MySample
{

    public class ComponentTest : MonoBehaviour
    {

        #region
        // [2] public 으로 개체 변수 선언하고 인스펙터 창에서 드래그로 가져온다
        public GameObject targetGameObject;
        public Transform targetTransform;

        #endregion

        private void Start()
        {
            // 컴포넌트 객체(인스턴스) 가져오기 연습

            #region Unity Event Method
            // [1] 게임 오브젝트(또는 트랜스폼) 의 인스턴스 가져오기
            // This.gameObject : ComponentTest 스크립트가 붙어있는 게임 오브젝트의 객체(인스턴스)
            // this.transform  : ComponentTest 스크립트가 붙어있는 트랜스폼의 객체(인스턴스)
            // ComponentTest 스크립트와 같은 오브젝트에 함께 부착되어 있는 TargetTest 클래스의 인스턴스 접근

            // TargetTest 클래스의 인스턴스 가져오기

            // MonoBehaviour를 상속받은 클래스는 new를 통해 인스턴스 생성하지 않음
            /*TargetTest cTest = new TargetTest();
            Debug.Log(cTest.a);*/

            // TargetTest 스크립트가 붙어있는 게임오브젝트의 인스턴스를 가져와서 접근한다.
            TargetTest gTest = targetGameObject.GetComponent<TargetTest>();
            Debug.Log(gTest.a);
            gTest.SetB(50);
            Debug.Log(gTest.GetB());
            #endregion
        }
    }

}





       
      
            




        
        

        
        
        



/*
게임 오브젝트(또는 트랜스폼)의 인스턴스 가져오는 방법
[1] 게임 오브젝트에 스크립트를 부착하여, 부착한 스크립트에서 this.gameobject 또는 this.transform으로 접근한다.
 
[2] public 으로 개체 변수 선언하고 인스펙터 창에서 드래그로 가져온다

컴포넌트(MonoBehaviour를 상속받은 클래스)의 인스턴스를 가져오는 방법
[1] 게임 오브젝트(또는 트랜스폼)의 인스턴스 가져와서 인스턴스 이름.GetComponent<컴포넌트이름>()
[2] 
*/