using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence
{
    public class BuildManager : MonoBehaviour
    {
        // 어디서나 접근 가능하게 정적으로 자기 자신 담을 그릇 생성
        public static BuildManager instance;

        // ★ [수정] 외부에서는 수정을 못 하되, 인스펙터 창에 칸이 보이도록 [SerializeField]를 붙여줍니다.
        [Header("Tower Prefabs")]
        // 단순 private 변수가 아니라, 인스펙터에 "새로운 데이터 박스 한 묶음"으로 
        // 바로 생성해서 쓸 수 있도록 new 선언을 해줍니다.
        [SerializeField] private TowerBlueprint machineGun;
        [SerializeField] private TowerBlueprint missail;
        [SerializeField] private TowerBlueprint laser;


        // 현재 유저가 선택한 타워 프리팹을 저장할 변수
        private TowerBlueprint selectCannon = null;

        // 외부에서 안전하게 읽기 전용으로 현재 선택된 타워를 가져갈 프로퍼티
        public TowerBlueprint GetTowerToBuild => selectCannon;

        // 타워가 들어있는지 없는지 확인하는 프로퍼티
        public bool HasTowerSelected => selectCannon != null;

        private void Awake()
        {
            // 싱글톤 중복 방지 예외 처리
            if (instance != null && instance != this)
            {
                Debug.LogError($"[경고] 씬에 BuildManager가 중복 존재합니다! 파괴되는 오브젝트: {gameObject.name}");
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        /// <summary>
        /// 머신건 타워 저장하는 함수
        /// </summary>
        public void MachingunTower()
        {
            selectCannon = machineGun;

            // 데이터가 진짜 들어왔는지 눈으로 교차 검증하기 위해 로그 수정
            if (selectCannon != null)
                Debug.Log($"머신건 타워 선택 성공! 가격: {selectCannon.constructionCost}");
            else
                Debug.LogError("머신건 블루프린트 데이터가 인스펙터에 비어있습니다!");
        }

        /// <summary>
        /// 로켓 타워 저장하는 함수
        /// </summary>
        public void RocketTower()
        {
            // ★ [버그 수정] machineGun 대신 missail 변수를 매칭해 줍니다.
            selectCannon = missail;

            if (selectCannon != null)
                Debug.Log($"로켓 타워 선택 성공! 가격: {selectCannon.constructionCost}");
            else
                Debug.LogError("로켓 블루프린트 데이터가 인스펙터에 비어있습니다!");
        }

        public void LaserTower()
        {
            // ★ [버그 수정] machineGun 대신 missail 변수를 매칭해 줍니다.
            selectCannon = laser;

            if (selectCannon != null)
                Debug.Log($"레이저 타워 선택 성공! 가격: {selectCannon.constructionCost}");
            else
                Debug.LogError("레이저 블루프린트 데이터가 인스펙터에 비어있습니다!");
        }



        /// <summary>
        /// 타일에서 호출하여 실제 타워를 생성하는 함수
        /// </summary>
        public void BuildTower(Vector3 spawnPosition)
        {
            // 1. 선택된 타워가 없는 경우 예외 처리
            if (selectCannon == null)
            {
                Debug.LogWarning("건설할 타워가 선택되지 않았습니다!");
                return;
            }

            // 2. 돈이 충분한지 체크
            if (GameData.money < selectCannon.constructionCost)
            {
                Debug.Log("돈이 부족합니다");
                return;
            }

            // 3. 돈이 충분하다면 돈을 지불하고 계산해줍니다.
            GameData.money -= selectCannon.constructionCost;
            Debug.Log($"건설하고 남은돈 : {GameData.money}");

            // 4. 실제로 게임 세상에 타워를 생성합니다.
            Instantiate(selectCannon.towerPrefab, spawnPosition, Quaternion.identity);

            // ★ [추가] 설치가 끝났으면 선택 상태를 초기화해 줍니다. (원치 않으시면 지우셔도 됩니다.)
            selectCannon = null;
        }
    }
}