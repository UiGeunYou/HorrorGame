using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Manager : MonoBehaviour
{
    public static BackGround_Manager instance;
    [SerializeField] private Tree_Script[] treeClassArr = null;
    [SerializeField] private Transform[] mapRangeTrfArr = null;
    [SerializeField] private Animation[] grassAnimArr = null;


    public void Init_Func()
    {
        instance = this;
        foreach (Tree_Script _treeClass in this.treeClassArr)
            _treeClass.Init_Func();
        this.Deactivate_Func();
    }

    public void Activate_Func()
    {
        foreach (Tree_Script _treeClass in this.treeClassArr)
            _treeClass.Activate_Func();
        foreach(Animation _grassAnim in this.grassAnimArr)
        {
            AnimationState _state = _grassAnim[_grassAnim.clip.name];
            _state.speed = Random.Range(.95f, 1.05f);
        }
    }

    public Vector2 GetMapMinPos_Func()
    {
        return this.mapRangeTrfArr[0].position;
    }

    public Vector2 GetMapMaxPos_Func()
    {
        return this.mapRangeTrfArr[1].position;
    }

    public Vector2 GetRandPos_Func()
    {
        Vector2 _minPos = this.GetMapMinPos_Func();
        Vector2 _maxPos = this.GetMapMaxPos_Func();

        return new Vector2(Random.Range(_minPos.x, _maxPos.x),Random.Range(_minPos.y, _maxPos.y));
    }

    public int GetOrderLayer_Func(Transform _trf)
    {
        return -(int)(_trf.position.y * 10);
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if(_isInit == false)
        {
            foreach (Tree_Script _treeClass in this.treeClassArr)
                _treeClass.Deactivate_Func();
        }
    }
}
