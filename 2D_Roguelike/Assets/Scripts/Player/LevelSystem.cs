// LevelSystem.cs
using UnityEngine;
using System;

public class LevelSystem : MonoBehaviour
{
    [Header("레벨/경험치")]
    [SerializeField] private int _level = 0;
    [SerializeField] private float _exp = 0f;

    public int Level => _level;
    public float Exp => _exp;

    public event Action<int> OnLevelChanged;     // 새 레벨
    public event Action<float> OnExpChanged;     // 현재 경험치
    public event Action<int, float> OnRequiredExpChanged; // (level, required)

    // 필요 경험치 함수(예시): 선형. 필요하면 커브/테이블로 교체.
    public float RequiredExp(int level)
    {
        // 레벨 1→2에 10, 이후 +5씩
        return 10f + (level - 1) * 5f;
    }

    public void AddExp(float amount)
    {
        if (amount <= 0f) return;
        _exp += amount;
        OnExpChanged?.Invoke(_exp);

        TryLevelUpLoop();
    }

    private void TryLevelUpLoop()
    {
        var req = RequiredExp(_level);
        while (_exp >= req)
        {
            _exp -= req;
            _level++;
            OnLevelChanged?.Invoke(_level);
            OnRequiredExpChanged?.Invoke(_level, RequiredExp(_level));
            req = RequiredExp(_level);
        }
        // 경험치 변경 브로드캐스트(게이지 갱신용)
        OnExpChanged?.Invoke(_exp);
    }

    // 초기 호출용 (UI가 필요 경험치 구독 시)
    private void Start()
    {
        OnRequiredExpChanged?.Invoke(_level, RequiredExp(_level));
        OnExpChanged?.Invoke(_exp);
        OnLevelChanged?.Invoke(_level);
    }
}
