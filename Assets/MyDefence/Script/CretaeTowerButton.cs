using UnityEngine;

namespace MyDefence
{
    

    public class CretaeTowerButton : MonoBehaviour
    {
        private int towerType;
        

        public void OnClickSelectTower()
        {
            if (towerType == 1)
            {

                Debug.Log("머신건 타워를 선택 하였습니다.");
                BuildManager.instance.SelectTower(BuildManager.instance.machineGun);
            }

            else if (towerType == 2)
            {
                Debug.Log("다른 타워를 선택 하였습니다.");
                BuildManager.instance.SelectTower(BuildManager.instance.missail);
            }

            

        }
        
    }
}