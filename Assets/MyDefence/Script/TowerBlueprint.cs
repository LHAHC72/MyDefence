using UnityEngine;

// [System.Serializable]을 적어주어야 유니티 인스펙터 창에 이 클래스의 변수들이 노출됩니다.
[System.Serializable]
public class TowerBlueprint 
{
    [Header("타워 설정")]
    [Tooltip("설치할 타워의 프리팹을 넣어주세요.")]
    public GameObject towerPrefab; // 타워 프리팹

    [Tooltip("타워를 설치하는 데 필요한 비용입니다.")]
    public int constructionCost;   // 설치 가격
}