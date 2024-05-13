using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Script : MonoBehaviour
{
    protected abstract float GetDurationTime {  get; }

    public void Init_Func()
    {
        this.Deactivate_Func(true);
    }

    public virtual void Activate_Func()
    {
        this.transform.position = BackGround_Manager.instance.GetRandPos_Func();
        StartCoroutine(this.OnDuration_Cor());
    }

    private IEnumerator OnDuration_Cor()
    {
        float _durationTime = this.GetDurationTime;
        float _passTime = 0f;

        while (_passTime < _durationTime)
        {
            _passTime += Time.deltaTime;
            this.OnPassTime_Func(_passTime / _durationTime);
            yield return null;
        }

        this.Deactivate_Func();
    }

    protected virtual void OnPassTime_Func(float _per)
    {

    }

    public abstract void OnCollidePlayer_Func();

    public void Deactivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
