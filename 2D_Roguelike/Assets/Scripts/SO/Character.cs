using UnityEngine;

[CreateAssetMenu(menuName="Player/character")]
public class Character : ScriptableObject
{
    [Header("캐릭터 스프라이트")]
    public Sprite sprite;

    [Header("캐릭터 기본스펙")]
    public float baseHp;
    public float baseMp;
    public float baseSpeed;
    public float exp;
    public int level;
}
