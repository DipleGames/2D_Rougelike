// StatCalculator.cs
using UnityEngine;
using System;

[DefaultExecutionOrder(-50)]
public class StatCalculator : MonoBehaviour
{
    [Header("레벨 시스템")]
    public LevelSystem levelSystem;   // 레벨/경험치

    // 출력 (읽기 전용) 이걸로 계산한 값을 PlayerStats 컴퍼넌트에 보내삔다.
    public float MaxHp   { get; private set; }
    public float MaxMp   { get; private set; }
    public float Speed { get; private set; }

    public event Action OnRecalculated;
    public event Action OnDefaultCalculated;

    private void Awake()
    {
        if (levelSystem != null)
            levelSystem.OnLevelChanged += _ => ReCalculate(); // 레벨이 오르면 스펙 재계산
    }


    #region  Calculator
    private PlayerStats playerStats;

    /// <summary>
    /// 캐릭터 기본 스펙 세팅용 메서드
    /// </summary>
    public void DefaultCulculate()
    {
        playerStats = GetComponent<PlayerStats>();
        if (playerStats.character == null || levelSystem == null)
        {
            Debug.LogWarning("StatCalculator: character/levelSystem null");
            return;
        }

        // 1. 캐릭터 디폴트 스탯 임시 변수에 담고 
        float baseHp = playerStats.character.baseHp;
        float baseMp = playerStats.character.baseMp;
        float baseSpeed = playerStats.character.baseSpeed;

        // 2. 읽기 변수에 담은다음 플레이어스탯 으로 보낸다.
        MaxHp = Mathf.Max(1f, baseHp);
        MaxMp = Mathf.Max(1f, baseMp);
        Speed = Mathf.Max(0.1f, baseSpeed);

        OnDefaultCalculated?.Invoke();
    }

    /// <summary>
    /// 스탯 변화시 계산용 메서드
    /// </summary>
    public void ReCalculate()
    {
        playerStats = GetComponent<PlayerStats>();
        if (playerStats.character == null || levelSystem == null)
        {
            Debug.LogWarning("StatCalculator: character/levelSystem null");
            return;
        }

        int L = Mathf.Max(1, levelSystem.Level);
        int idx = L - 1; // 커브 입력용

        // 1) 기본 + 성장 (예: 커브/테이블 사용) 
        float maxHp = playerStats.MaxHp + 10f;
        float maxMp = playerStats.MaxMp + 10f;
        float speed = playerStats.Speed + 10f;

        // 2) (선택) 장비/버프 보정이 있다면 여기서 합산

        // 3) 계산이 끝난값을 담기
        MaxHp = Mathf.Max(1f, maxHp);
        MaxMp = Mathf.Max(1f, maxMp);
        Speed = Mathf.Max(0.1f, speed);

        OnRecalculated?.Invoke();
    }
    #endregion
}
