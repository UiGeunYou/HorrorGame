using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DB_Manager : ScriptableObject
{
    public static DB_Manager Instance;

    [Header("»ç¿îµå")]
    [SerializeField] private BgmData[] bgmDataArr = null;
    [SerializeField] private SfxData[] sfxDataArr = null;
    private Dictionary<BgmType, BgmData> bgmDataDic;
    private Dictionary<SfxType, SfxData> sfxDataDic;

    public virtual void Init_Func()
    {
        Instance = this;

        this.bgmDataDic = new Dictionary<BgmType, BgmData>();
        foreach (BgmData _bgmData in this.bgmDataArr)
            this.bgmDataDic.Add(_bgmData.bgmType, _bgmData);

        this.sfxDataDic = new Dictionary<SfxType, SfxData>();
        foreach (SfxData _sfxData in this.sfxDataArr)
            this.sfxDataDic.Add(_sfxData.sfxType, _sfxData);
    }

    public BgmData GetBgmData_Func(BgmType _bgmType)
    {
        return this.bgmDataDic[_bgmType];
    }
    public SfxData GetSfxData_Func(SfxType _sfxType)
    {
        return this.sfxDataDic[_sfxType];
    }

    [System.Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1f;
    }

    [System.Serializable]
    public class BgmData : SoundData
    {
        public BgmType bgmType;
    }

    [System.Serializable]
    public class SfxData : SoundData
    {
        public SfxType sfxType;
    }
}
