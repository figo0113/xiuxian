using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : ApplicationBase<Game>
{
    [HideInInspector]
    public StaticData StaticData = null;//静态数据
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);

    }


    void OnLevelWasLoaded(int level)
    {
        //事件参数
        SceneArgs e = new SceneArgs();
        e.SceneIndex = level;
        //发布事件
        SendEvent(Consts.E_EnterScene, e);
    }

    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);



        StaticData = StaticData.Instance;//全局单例赋值

        //注册命令（controller）
        ReigisterController(Consts.E_StartUp, typeof(StartUpCommand));

        //启动游戏
        SendEvent(Consts.E_StartUp);

    }
    
}
