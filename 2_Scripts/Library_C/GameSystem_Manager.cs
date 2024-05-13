using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Library_C
{
    public abstract class GameSystem_Manager : MonoBehaviour
    {
        [SerializeField] private SoundSystem_Manager soundSystem_Manager = null;
        [SerializeField] private DataBase_Manager dataBase_Manager = null;

        private void Awake()
        {
            this.Init_Func();
        }

        public virtual void Init_Func()
        { 
            this.soundSystem_Manager.Init_Func();
            this.dataBase_Manager.Init_Func();

            this.Deactivate_Func(true);
        }

        public virtual void Activate_Func()
        {

        }

        public virtual void Deactivate_Func(bool _isInit = false)
        {
            if (_isInit == false)
            {

            }
        }
    }
}