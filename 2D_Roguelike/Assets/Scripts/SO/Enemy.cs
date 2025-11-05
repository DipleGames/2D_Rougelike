using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/enemy")]
public class Enemy : ScriptableObject
{
    public Sprite sprite;
    public float hp;
    public float speed;
    public float attackDamage;
    public float xpValue;
}
