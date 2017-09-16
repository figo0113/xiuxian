using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : View {
    public override string Name
    {
        get
        {
            return Consts.V_Start;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }


    public void StartGameClick()
    {

        //初始化
        GameModel gModel = GetModel<GameModel>();
        gModel.IsNewGame = true;
        gModel.initialize();
        Game.Instance.LoadScene(2);
    }

    public void ContinueGameClick()
    {

        //初始化
        GameModel gModel = GetModel<GameModel>();
        gModel.IsNewGame = false;
        gModel.initialize();
        Game.Instance.LoadScene(2);
    }

}
