using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Key_Script : Item_Script
{
    [SerializeField] private Light2D light2D;
    protected override float GetDurationTime => DataBase_Manager.instance.keyDuration;

    protected override void OnPassTime_Func(float _per)
    {
        base.OnPassTime_Func(_per);
        this.light2D.pointLightOuterRadius = DataBase_Manager.instance.keyLightRadius * _per;
    }

    public override void OnCollidePlayer_Func()
    {
        GameSystem_Manager.instance.AddScore_Func(1);

        SoundSystem_Manager.Instance.PlaySfx_Func(SfxType.Key);

        this.Deactivate_Func();
    }
}
