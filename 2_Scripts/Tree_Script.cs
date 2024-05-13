using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Script : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srdr = null;
    public void Init_Func()
    {
        this.Deactivate_Func();
    }

    public void Activate_Func()
    {
        this.srdr.sortingOrder = BackGround_Manager.instance.GetOrderLayer_Func(this.transform);
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {

        }
    }
}
