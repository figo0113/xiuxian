using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class StartUpCommand : Controller
{
    public override void Execute(object date)
    {
        //注册模型（model）
        ReigisterModel(new GameModel());
        ReigisterModel(new MapModel());
        ReigisterModel(new FightModel());

        //注册命令（controller）
        ReigisterController(Consts.E_EnterScene, typeof(EnterSceneCommand));
        ReigisterController(Consts.E_StartFight, typeof(StartFightCommand));
        ReigisterController(Consts.E_SaveData, typeof(SaveDataCommand));

        //创建存档文件夹
        IOHelper.CreateDirectory(Consts.dirpath);

        //跳转到开始界面
        Game.Instance.LoadScene(1);
    }
}
