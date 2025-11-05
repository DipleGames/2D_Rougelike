using System.Collections;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
    [Header("캐릭터 목록")]
    [SerializeField] private Character[] characterList;


    [Header("세팅된 플레이어 객체 / 컴퍼넌트")]
    public GameObject player;
    public PlayerController playerController;
    public PlayerStats playerStats;
    public StatCalculator statCalculator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        // 1. 씬에 "Player"라는 태그가 부착된 오브젝트를 넣는다.
        player = GameObject.FindGameObjectWithTag("Player");

        // 2. 그 객체의 컴퍼넌트를 담는다.
        playerStats = player.GetComponent<PlayerStats>();
        statCalculator = player.GetComponent<StatCalculator>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        // ========= 임시 코드
        KeyCode key = KeyCode.None;
        if (Input.GetKeyDown(KeyCode.Alpha1)) key = KeyCode.Alpha1;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) key = KeyCode.Alpha2;

        switch (key)
        {
            case KeyCode.Alpha1:
                playerStats.character = characterList[0];
                InitPlayer();
                break;

            case KeyCode.Alpha2:
                playerStats.character = characterList[1];
                InitPlayer();
                break;
        }
        // =========
    }

    public void InitPlayer()
    {
        // 캐릭터 기본 선택
        spriteRenderer.sprite = playerStats.character.sprite;
        statCalculator.DefaultCulculate();
    }
}
