using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSystem_Manager : MonoBehaviour
{
    public static MonsterSystem_Manager instance;

    private List<Monster_Script> monsterClassList;
    private Coroutine spawnCor;

    public void Init_Func()
    {
        instance = this;
        this.monsterClassList = new List<Monster_Script>();
        this.Deactivate_Func(true);
    }

    public void Activate_Func()
    {
        this.spawnCor = StartCoroutine(this.OnSpawn_Cor());
    }

    private IEnumerator OnSpawn_Cor()
    {
        while (this.monsterClassList.Count < DataBase_Manager.instance.monsterMaxNum)
        {
            Monster_Script _baseMosterClass = DataBase_Manager.instance.baseMonsterClass;
            Monster_Script _monsterClass = GameObject.Instantiate<Monster_Script>(_baseMosterClass);
            _monsterClass.Activate_Func();

            this.monsterClassList.Add(_monsterClass);

            yield return new WaitForSeconds(DataBase_Manager.instance.monsterSpawnInterval);
        }
    }

    public void OnNotifyByCan_Func(Vector2 _canPos)
    {
        bool _isNotify = false;

        foreach(Monster_Script _monsterClass in this.monsterClassList)
        {
            if(Vector2.Distance(_canPos, _monsterClass.GetPos) < DataBase_Manager.instance.notifyDistance)
            {
                _isNotify = true;
                _monsterClass.SetArrivePos_Func(_canPos);
            }
        }
        if(_isNotify == true)
        {
            SoundSystem_Manager.Instance.PlaySfx_Func(SfxType.CanNotify);
        }
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {
            foreach(Monster_Script _monsterClass in this.monsterClassList)
            {
                _monsterClass.Deactivate_Func();
                StopCoroutine(this.spawnCor);
            }
            this.spawnCor = null;
            this.monsterClassList.Clear();
        }
    }
}
