using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem_Manager : MonoBehaviour
{
    public static SoundSystem_Manager Instance;

    [SerializeField] private AudioSource bgmAS = null;
    [SerializeField] private AudioSource[] sfxAsArr = null;

    private int sfxAsID;

    public void Init_Func()
    {
        Instance = this;

        this.sfxAsID = 0;
    }

    public void PlayBgm_Func(BgmType _bgmType)
    {
        DataBase_Manager.BgmData _bgmData = DataBase_Manager.Instance.GetBgmData_Func(_bgmType);
        this.bgmAS.clip = _bgmData.clip;
        this.bgmAS.volume = _bgmData.volume;
        this.bgmAS.Play();
    }
    public void StopBgm_Func()
    {
        this.bgmAS.Stop();
    }

    public void PlaySfx_Func(SfxType _sfxType)
    {
        DataBase_Manager.SfxData _sfxData = DataBase_Manager.Instance.GetSfxData_Func(_sfxType);

        AudioSource _sfxAS = this.sfxAsArr[this.sfxAsID];
        _sfxAS.volume = _sfxData.volume;
        _sfxAS.PlayOneShot(_sfxData.clip);

        if (this.sfxAsID + 1 < this.sfxAsArr.Length)
            this.sfxAsID++;
        else
            this.sfxAsID = 0;
    }

    private void Reset()
    {
        if(this.bgmAS == null)
        {
            GameObject _bgmObj = new GameObject("BgmAS");
            _bgmObj.transform.SetParent(this.transform);
            this.bgmAS = _bgmObj.AddComponent<AudioSource>();
        }

        if(this.sfxAsArr == null)
        {
            this.sfxAsArr = new AudioSource[10];

            for (int i = 0; i < 10; i++)
            {
                GameObject _sfxObj = new GameObject("SfxAS_" + i);
                _sfxObj.transform.SetParent(this.transform);
                this.sfxAsArr[i] = _sfxObj.AddComponent<AudioSource>();
            }
        }

        this.gameObject.name = typeof(SoundSystem_Manager).Name;
    }
}

public enum BgmType
{
    None = 0,

    Ingame = 10,
}

public enum SfxType
{
    None = 0,

    Step_1 = 10,
    Step_2 = 20,
    Step_3 = 30,
    Step_4 = 40,
    Step_5 = 50,
    Step_6 = 60,
    Step_7 = 70,
    Step_8 = 80,
    Step_9 = 90,
    Step_10 = 100,
    Step_11 = 110,
    Step_12 = 120,

    Can_0 = 130,
    Can_1 = 140,
    Can_2 = 150,
    CanNotify = 160,
    Key = 170,
    GameOver = 180,
}