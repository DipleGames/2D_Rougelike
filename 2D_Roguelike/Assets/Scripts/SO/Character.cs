using UnityEngine;

[CreateAssetMenu(menuName="Player/character")]
public class Character : ScriptableObject
{
    [Header("캐릭터 스프라이트")]
    public Sprite sprite;

    [Header("캐릭터 기본스펙")]
    public float hp;
    public float mp;
    public float speed;
    public float exp;
    public int level;
}
