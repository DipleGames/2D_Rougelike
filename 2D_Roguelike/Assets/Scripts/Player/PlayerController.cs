using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    
    // ===== 이동 지점 =====
    public Vector3 targetPoint { get; private set; }


    #region 플레이어 체력 및 마나
    [Header("현재 체력 / 현재 마나")]
    [SerializeField] private float _hp;
    [SerializeField] private float _mp;

    public event Action<float, float> OnHpChanged;
    public event Action<float, float> OnMpChanged;

    public float Hp
    {
        get => _hp;
        set
        {
            float max = playerStats ? playerStats.MaxHp : Mathf.Infinity;
            float nv  = Mathf.Clamp(value, 0f, max);
            if (Mathf.Approximately(_hp, nv)) return;
            float ov = _hp;
            _hp = nv;
            OnHpChanged?.Invoke(ov, _hp); // ui 처리 해야함
            if (_hp <= 0f) Die();
        }
    }

    public float Mp
    {
        get => _mp;
        set
        {
            float max = playerStats ? playerStats.MaxMp : Mathf.Infinity;
            float nv = Mathf.Clamp(value, 0f, max);
            if (Mathf.Approximately(_mp, nv)) return;
            float ov = _mp;
            _mp = nv;
            OnMpChanged?.Invoke(ov, _mp); // ui 처리 해야함
        }
    }
    #endregion
    
    void Awake()
    {
        playerStats.statCalc.OnDefaultCalculated += OnInitialize; // 1. 캐릭터 선택시 "스텟 계산기"에서 기초 스텟을 적용한 뒤 현재 체력(풀피) 현재 마나(풀마나) 반영
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var tp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint = new Vector3(tp.x, tp.y, transform.position.z);

            PlayerManager.Instance.spriteRenderer.flipX = transform.position.x < targetPoint.x;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, playerStats.Speed * Time.deltaTime);
    }

    void OnInitialize()
    {
        Hp = playerStats.MaxHp;
        Mp = playerStats.MaxMp;
    }

    public void Die()
    {
        // 사망 처리
    }
}
