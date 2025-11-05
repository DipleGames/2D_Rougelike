using System.Collections;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
    [Header("캐릭터 목록")]
    [SerializeField] private Character[] characterList;


    [Header("세팅된 플레이어 객체 / 컴퍼넌트")]
    public GameObject player;
    public PlayerController playerController;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        // 1. 씬에 "Player"라는 태그가 부착된 오브젝트를 넣는다.
        player = GameObject.FindGameObjectWithTag("Player");

        // 2. 그 객체의 컴퍼넌트를 담는다.
        playerController = player.GetComponent<PlayerController>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
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
                playerController.character = characterList[0];
                PlayerInit();
                break;

            case KeyCode.Alpha2:
                playerController.character = characterList[1];
                PlayerInit();
                break;
        }
        // =========
    }

    /// <summary>
    /// 플레이어의 스펙을 세팅하는 메서드
    /// </summary>
    void PlayerInit()
    {
        // 플레이어의 이미지.
        spriteRenderer.sprite = playerController.character.sprite;

        // 플레이어의 스펙.
        playerController.hp = playerController.character.hp;
        playerController.mp = playerController.character.mp;
        playerController.speed = playerController.character.speed;
        playerController.exp = playerController.character.exp;
        playerController.level = playerController.character.level;
    }
}
