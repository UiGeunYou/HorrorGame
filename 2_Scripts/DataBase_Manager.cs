using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DataBase_Manager
{
    public int goal =10;
    public float moveSpeed = 100f;
    public float stepSfxInterval = .5f;

    [Header("∏ÛΩ∫≈Õ")]
    public int monsterMaxNum = 10;
    public float monsterSpawnInterval = 10f;
    public float monsterMoveSpeed = 1f;
    public float monsterRunSpeed = 3f;
    public Monster_Script baseMonsterClass = null;

    [Header("ø≠ºË")]
    public float keySpawnInterval = 3f;
    public float keyDuration = 10f;
    public float keyLightRadius = 5f;
    public Key_Script baseKeyClass = null;

    [Header("±¯≈Î")]
    public float canSpawnInterval = 3f;
    public float canDuration = 10f;
    public float notifyDistance = 10f;
    public Can_Script baseCanClass = null;
    [SerializeField] private SfxType[] canSfxTypeArr = null;
    [SerializeField] private Sprite[] canSpriteArr = null;
    public SfxType GetCanSfxType_Func()
    {
        return this.canSfxTypeArr[Random.Range(0, this.canSfxTypeArr.Length)];
    }

    public Sprite GetCanSprite_Func()
    {
        return this.canSpriteArr[Random.Range(0, this.canSpriteArr.Length)];
    }
}
