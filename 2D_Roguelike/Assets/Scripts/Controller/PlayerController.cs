using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("캐릭터 세팅")]
    public Character character;

    [Header("플레이어 스펙")]
    public float hp;
    public float mp;
    public float speed;
    public float exp;
    public int level;

    [Header("이동 지점")]
    public Vector3 targetPoint;

    void Start()
    {
        targetPoint = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;

            if (transform.position.x < targetPoint.x)
            {
                PlayerManager.Instance.spriteRenderer.flipX = true;
            }
            else
            {
                PlayerManager.Instance.spriteRenderer.flipX = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
}
