using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_Script : Item_Script
{
    [SerializeField] private SpriteRenderer srdr = null;
    protected override float GetDurationTime => DataBase_Manager.instance.canDuration;

    public override void Activate_Func()
    {
        this.srdr.sprite = DataBase_Manager.instance.GetCanSprite_Func();
        base.Activate_Func();
    }

    public override void OnCollidePlayer_Func()
    {
        SoundSystem_Manager.Instance.PlaySfx_Func(DataBase_Manager.instance.GetCanSfxType_Func());

        MonsterSystem_Manager.instance.OnNotifyByCan_Func(this.transform.position);

        base.Deactivate_Func();
    }
}
