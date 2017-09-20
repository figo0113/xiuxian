using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILost : View
{
    public Text countDownText;
    public override string Name
    {
        get
        {
            return Consts.V_UILost;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_Lost:
                StartCountDown();
                break;
        }
    }
    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_Lost);
    }
    void Close()
    {
        GameModel gm = GetModel<GameModel>();
        this.gameObject.SetActive(false);
        Game.Instance.LoadScene(2);
        gm.IsInstance = false;
        gm.player.Hp = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Close();
            
        }
    }


    public void StartCountDown()
    {
        this.gameObject.SetActive(true);
        StartCoroutine("DisplayCount");
    }

    IEnumerator DisplayCount()
    {

        int count = 5;
        while (count > 0)
        {
            //显示
            countDownText.text ="("+ count+")";

            //自减
            count--;

            //等待1秒
            yield return new WaitForSeconds(1f);

            if (count <= 0)
                break;
        }

        Close();
    }

}
