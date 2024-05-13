using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSystem_Manager : Library_C.GameSystem_Manager
{
    public static GameSystem_Manager instance;
    [SerializeField] private PlayerSystem_Manager playerSystem_Manager = null;
    [SerializeField] private BackGround_Manager backGround_Manager = null;
    [SerializeField] private MonsterSystem_Manager monsterSystem_Manager = null;
    [SerializeField] private Animation gameOverAnim = null;
    [SerializeField] private ItemSystem_Manager itemSystemManager = null;
    [SerializeField] private TextMeshProUGUI scoreTmp = null;
    [SerializeField] private GameObject clearObj = null;
    private int currentScore;

    public override void Init_Func()
    {
        instance = this;
        this.playerSystem_Manager.Init_Func();
        this.backGround_Manager.Init_Func();
        this.monsterSystem_Manager.Init_Func();
        this.itemSystemManager.Init_Func();
        this.gameOverAnim.gameObject.SetActive(false);
        this.clearObj.SetActive(false);

        base.Init_Func();

        this.Activate_Func();
    }

    public override void Activate_Func()
    {
        base.Activate_Func();

        PlayerSystem_Manager.instance.Activate_Func();
        BackGround_Manager.instance.Activate_Func();
        MonsterSystem_Manager.instance.Activate_Func();
        ItemSystem_Manager.instance.Activate_Func();

        this.currentScore = 0;
        this.scoreTmp.text = $"{this.currentScore}/{DataBase_Manager.instance.goal}";

        SoundSystem_Manager.Instance.PlayBgm_Func(BgmType.Ingame);
    }

    public void AddScore_Func(int _score)
    {
        this.currentScore += _score;
        int _goal = DataBase_Manager.instance.goal;
        this.scoreTmp.text = $"{this.currentScore}/{_goal}";

        if(_goal <= this.currentScore)
        {
            this.clearObj.SetActive(true);
            this.Deactivate_Func();
        }
    }

    public void OnGameOver_Func()
    {
        this.gameOverAnim.gameObject.SetActive(true);
        this.gameOverAnim.Play();

        SoundSystem_Manager.Instance.PlaySfx_Func(SfxType.GameOver);

        this.Deactivate_Func();
    }

    public override void Deactivate_Func(bool _isInit = false)
    {
        if(_isInit == false) 
        {
            PlayerSystem_Manager.instance.DeActivate_Func();
            BackGround_Manager.instance.Deactivate_Func();
            MonsterSystem_Manager.instance.Deactivate_Func();
            ItemSystem_Manager.instance.Deactivate_Func();
        }
        base.Deactivate_Func(_isInit);
    }

    public void CallBtn_ReTry_Func()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
