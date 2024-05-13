using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Script : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srdr;
    private Vector2 arrivePos;
    private bool isRun = false;

    public Vector2 GetPos => this.transform.position;

    public void Init_Func()
    {
        this.Deactivate_Func(true);
    }

    public void Activate_Func()
    {
        this.transform.position = BackGround_Manager.instance.GetRandPos_Func();

        StartCoroutine(this.OnMove_Cor());
    }

    private IEnumerator OnMove_Cor()
    {
        this.arrivePos = this.transform.position;
        while (true)
        {
            Vector2 _thisPos = this.transform.position; 

            if(Vector2.Distance(this.arrivePos, _thisPos) < .1f)
            {
                this.isRun = false;
                this.arrivePos = BackGround_Manager.instance.GetRandPos_Func();
            }

            Vector2 _moveDir = (this.arrivePos - (Vector2)this.transform.position).normalized;
            float _monsterMoveSpeed = this.isRun == false ? DataBase_Manager.instance.monsterMoveSpeed : DataBase_Manager.instance.monsterRunSpeed;
            Vector2 _moveVelocity = _moveDir * _monsterMoveSpeed * Time.deltaTime;
            this.transform.Translate(_moveVelocity);

            this.srdr.sortingOrder = BackGround_Manager.instance.GetOrderLayer_Func(this.transform);

            yield return null;
        }
    }

    public void SetArrivePos_Func(Vector2 _pos)
    {
        this.isRun = true;

        this.arrivePos = _pos;
    }

    public void OnCollidePlayer_Func()
    {
        GameSystem_Manager.instance.OnGameOver_Func();
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {

        }
    }
}
