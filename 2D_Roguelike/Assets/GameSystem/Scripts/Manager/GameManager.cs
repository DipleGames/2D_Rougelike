using UnityEngine;
using System;
public enum GameState { Playing, Boss, GameOver }

public class GameManager : SingleTon<GameManager>
{
    public event Action<float> OnThreatGuageChanged; 
    private float _maxThreatGuage = 100f;
    [SerializeField] private float _threatGuage = 0f;
    public float ThreatGuage
    {
        get => _threatGuage;
        set
        {
            float nv = Mathf.Clamp(value, 0f, _maxThreatGuage);
            _threatGuage = nv;
            OnThreatGuageChanged?.Invoke(_threatGuage);
            if (_threatGuage >= _maxThreatGuage) 
            {
                GuageMaxEvent();
            }
        }
    }

    public void SwitchGame()
    {
        Time.timeScale =Time.timeScale == 0f ? 1f : 0f;
    }

    public void IncreaseThreatGuage(float amount)
    {
        ThreatGuage += amount;
    }

    public void GuageMaxEvent()
    {
        Debug.Log("분노게이지 맥스 보스스테이지 입장");
        ThreatGuage = 0f;
    }
}
