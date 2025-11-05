using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public Transform target;

    [Header("적 객체")]
    public Enemy enemy;

    [Header("적 스펙")]
    public float enemyHp;
    public float enemySpeed;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyInit();

        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        EnemyAI();
    }

    void EnemyAI()
    {
         // 방향 벡터 계산
        Vector3 dir = (target.position - transform.position).normalized;

        // 이동
        transform.position += dir * enemySpeed * Time.deltaTime;

        // 플립
        if (transform.position.x > target.position.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
    
    void EnemyInit()
    {
        spriteRenderer.sprite = enemy.sprite;
        enemyHp = enemy.hp;
        enemySpeed = enemy.speed;   
    }
}
