using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public partial class DataBase_Manager : DB_Manager
{
    public static DataBase_Manager instance;

    public override void Init_Func()
    {
        instance = this;

        base.Init_Func();
    }
}
