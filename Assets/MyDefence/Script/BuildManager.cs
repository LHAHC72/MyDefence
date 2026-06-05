using System.Runtime.CompilerServices;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // 어디서나 접근 가능하게 정적으로 자기 자신 담을 그릇 생성
    public static BuildManager instance;

    public GameObject machineGun;
    public GameObject missail;

    private GameObject selectCannon = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;    // 자기 자신을 static 변수 할당
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    // 타워 들어있는지 없는지 확인하는 프리퍼티
    public bool HasTowerSelected => selectCannon != null;

    // 선택한 타워 저장하는 함수
    public void SelectTower(GameObject tower)
    {
        selectCannon = tower;
    }

    public void BuildTurretOn(GameObject tile)
    {
        
        Vector3 spawnPosition = tile.transform.position + new Vector3(0, 0.5f, 0);  // 타일 위에 올리려고 살짝 위로

        Instantiate(selectCannon, spawnPosition, Quaternion.identity);
    }



}
