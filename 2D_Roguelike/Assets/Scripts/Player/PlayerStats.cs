// PlayerStats.cs
using UnityEngine;
using System;

[DefaultExecutionOrder(-40)]
public class PlayerStats : MonoBehaviour
{
    [Header("참조")]
    public Character character;
    public StatCalculator statCalc;

    [Header("플레이어 스탯")]
    [SerializeField] private float _maxHp;
    [SerializeField] private float _maxMp;
    [SerializeField] private float _speed; 

    public float MaxHp => _maxHp;
    public float MaxMp => _maxMp;
    public float Speed  => _speed;

    public event Action OnMaxStatsChanged;       // Max 변경 알림
    public event Action<float,float> OnSpeedChanged; // (old,new) – 필요 시

    private void Awake()
    {
        if (statCalc != null)
        {
            statCalc.OnDefaultCalculated += OnStatRecalculated; // 1. 캐릭터 선택시 "스텟 계산기"에서 기초 스텟을 적용한 뒤 스텟결과창에 적용 
            statCalc.OnRecalculated += OnStatRecalculated; // 2. 스텟이 변화할때 "스텟 계산기"에서 계산이 완료되면 스텟결과창에 적용
        }
    }

    private void Start()
    {
        OnStatRecalculated(); // 초기 1회
    }

    private void OnStatRecalculated()
    {
        if (statCalc == null) return;

        _maxHp = statCalc.MaxHp;
        _maxMp = statCalc.MaxMp;
        _speed = statCalc.Speed;


        OnMaxStatsChanged?.Invoke();
    }

    private void OnDestroy()
    {
        if (statCalc != null)
            statCalc.OnRecalculated -= OnStatRecalculated;
    }

}
