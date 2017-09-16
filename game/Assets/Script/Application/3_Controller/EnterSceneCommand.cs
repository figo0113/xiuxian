using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class EnterSceneCommand : Controller
{
    public override void Execute(object data)
    {
        SceneArgs e = data as SceneArgs;

        //注册视图（View）
        switch (e.SceneIndex)
        {
            /*case 0: //Init

                break;
            case 1://Start
               base.ReigisterView(GameObject.Find("UIStart").GetComponent<UIStart>());
                break;
            case 2://Select
                base.ReigisterView(GameObject.Find("UISelect").GetComponent<UISelect>());
                break;
            case 3://Level
                base.ReigisterView(GameObject.Find("UIBoard").GetComponent<UIBoard>());
                base.ReigisterView(GameObject.Find("TowerPopup").GetComponent<TowerPopup>());
                base.ReigisterView(GameObject.Find("Map").GetComponent<Spawner>());
                base.ReigisterView(GameObject.Find("Canvas").transform.Find("UICountDown").GetComponent<UICountDown>());
                base.ReigisterView(GameObject.Find("Canvas").transform.Find("UIWin").GetComponent<UIWin>());
                base.ReigisterView(GameObject.Find("Canvas").transform.Find("UILost").GetComponent<UILost>());
                base.ReigisterView(GameObject.Find("Canvas").transform.Find("UISystem").GetComponent<UISystem>());
                break;
            case 4://Complete
                base.ReigisterView(GameObject.Find("UIComplete").GetComponent<UIComplete>());
                break;
            default:
                break;*/
            case 2:
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("UIBackPack").GetComponent<UIBackPack>());               
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("NPCPanel").GetComponent<PanelManager>());
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("NPCPanel").GetComponent<NPCPanelInfo>());
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("MonsterPanel").GetComponent<MonsterPanelManager>());
                //base.ReigisterView(GameObject.Find("UIMain").transform.Find("MonsterPanel").GetComponent<MonsterPanelInfo>());
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("CollectionPanel").GetComponent<CollectionPanelManager>());
                //base.ReigisterView(GameObject.Find("UIMain").transform.Find("CollectionPanel").GetComponent<CollectionPanelInfo>());
                base.ReigisterView(GameObject.Find("UIMain").transform.Find("NodeMap").GetComponent<NodeMap>());
                break;
            case 3:
                base.ReigisterView(GameObject.Find("FightManger").GetComponent<FightManger>());
                base.ReigisterView(GameObject.Find("UIFight").transform.Find("WinBoundary").GetComponent<UIWin>());
                break;
        }
    }
}