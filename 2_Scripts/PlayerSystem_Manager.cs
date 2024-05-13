using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSystem_Manager : MonoBehaviour
{
    public static PlayerSystem_Manager instance;
    [SerializeField] private Animator anim = null;
    [SerializeField] private SpriteRenderer srdr = null;
    [SerializeField] private Transform lightTrf = null;
    [SerializeField] private Transform[] lightPivotTrfArr = null;

    [SerializeField] private SfxType[] stepSfxTypeArr = null;
    private float stepSfxInterval = 0f;
    private bool isAlive;
    
    public void Init_Func()
    {
        instance = this;

        this.DeActivate_Func();
    }

    public void Activate_Func()
    {
        this.isAlive = true;
    }

    private void Update()
    {
        if (this.isAlive == false)
            return;

        if (0f < this.stepSfxInterval)
        {
            this.stepSfxInterval -= Time.deltaTime;
        }

        Vector2 _moveDir = default;
        string _aniTriggerStr = null;
        bool _isFlipBack = false;
        Transform _lightPivotTrf = null;

        if (Input.GetKey(KeyCode.W) == true)
        {
            _moveDir = Vector2.up;
            _aniTriggerStr = "Up";
            _isFlipBack = true;
            _lightPivotTrf = this.lightPivotTrfArr[0];  
        }

        else if (Input.GetKey(KeyCode.A) == true)
        {
            _moveDir = Vector2.left;
            _aniTriggerStr = "Side";
            _isFlipBack = true;
            _lightPivotTrf = this.lightPivotTrfArr[1];
        }

        else if (Input.GetKey(KeyCode.S) == true)
        {
            _moveDir = Vector2.down;
            _aniTriggerStr = "Down";
            _isFlipBack = true;
            _lightPivotTrf = this.lightPivotTrfArr[2];
        }

        else if (Input.GetKey(KeyCode.D) == true)
        {
            _moveDir = Vector2.right;
            _aniTriggerStr = "Side";
            this.srdr.flipX = true;
            _lightPivotTrf = this.lightPivotTrfArr[3];
        }

        if(_aniTriggerStr != null)
        {
            Vector2 _translationValue = _moveDir * DataBase_Manager.instance.moveSpeed * Time.deltaTime;
            Vector2 _arrivePos = (Vector2)this.transform.position + _translationValue; 

            Vector2 _mapMinPos = BackGround_Manager.instance.GetMapMinPos_Func();
            Vector2 _mapMaxPos = BackGround_Manager.instance.GetMapMaxPos_Func();

            if(_arrivePos.x < _mapMinPos.x)
                _arrivePos.x = _mapMinPos.x;
            else if(_arrivePos.x > _mapMaxPos.x)
                _arrivePos.x = _mapMaxPos.x;
            
            if (_arrivePos.y < _mapMinPos.y)
                _arrivePos.y = _mapMinPos.y;
            else if(_arrivePos.y > _mapMaxPos.y)
                _arrivePos.y = _mapMaxPos.y;

            this.transform.position = _arrivePos;

            this.srdr.sortingOrder = BackGround_Manager.instance.GetOrderLayer_Func(this.transform);
            this.anim.SetTrigger(_aniTriggerStr);
            if (_isFlipBack == true)
            {
                this.srdr.flipX = false;
            }

            this.lightTrf.SetParent(_lightPivotTrf);
            this.lightTrf.localPosition = default;
            this.lightTrf.localRotation = default;

            if(this.stepSfxInterval <= 0f)
            {
                this.stepSfxInterval = DataBase_Manager.instance.stepSfxInterval;

                SfxType _sfxType = this.stepSfxTypeArr[Random.Range(0, this.stepSfxTypeArr.Length)];
                SoundSystem_Manager.Instance.PlaySfx_Func(_sfxType);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (this.isAlive == false)
            return;
        string _tagStr = _col.tag;

        switch (_tagStr)
        {
            case  "Monster":
                {
                    if (_col.TryGetComponent(out Monster_Script _monsterClass) == true)
                    {
                        _monsterClass.OnCollidePlayer_Func();
                    }
                }
                break;
            case "Can":
                {
                    if (_col.TryGetComponent(out Can_Script _canClass) == true)
                    {
                        _canClass.OnCollidePlayer_Func();
                    }
                }
                break;
            case "Key":
                {
                    if (_col.TryGetComponent(out Key_Script _keyClass) == true)
                    {
                        _keyClass.OnCollidePlayer_Func();
                    }
                }
                break;

            default:
                break;
        }
    }

    public void DeActivate_Func(bool _isInit = false)
    {
        if(_isInit == false)
        {

        }

        this.isAlive = false;
    }
}
