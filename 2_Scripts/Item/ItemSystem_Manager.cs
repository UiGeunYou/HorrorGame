using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem_Manager : MonoBehaviour
{
    public static ItemSystem_Manager instance;
    private Coroutine keySpawnCor;
    private Coroutine canSpawnCor;
    public void Init_Func()
    {
        instance = this;

        this.Deactivate_Func(true);
    }

    public void Activate_Func()
    {
        this.canSpawnCor = StartCoroutine(this.OnSpawnItem_Cor(DataBase_Manager.instance.baseCanClass, DataBase_Manager.instance.canSpawnInterval));
        this.keySpawnCor = StartCoroutine(this.OnSpawnItem_Cor(DataBase_Manager.instance.baseKeyClass, DataBase_Manager.instance.keySpawnInterval));
    }

    private IEnumerator OnSpawnItem_Cor<T>(T _baseItemClass, float _spawnInterval) where T : Item_Script //Generic
    {
        while (true)
        {
            T _itemClass = GameObject.Instantiate<T>(_baseItemClass);
            _itemClass.Activate_Func();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void Deactivate_Func(bool _isInit = false)
    {
        if (_isInit == false)
        {
            if(keySpawnCor != null)
                StopCoroutine(this.keySpawnCor);
            if (canSpawnCor != null)
                StopCoroutine(this.canSpawnCor);
        }

        this.keySpawnCor = null;
        this.canSpawnCor = null;
    }
}
