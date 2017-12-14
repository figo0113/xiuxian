using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TextShow :View
{

    public override string Name
    {
        get
        {
            return Consts.V_TextShow;
        }
    }

    void MidTextShow(string textValue)
    {
        GameObject propertyText = (GameObject)Instantiate(Resources.Load("Prefab/PromptText"));
        //propertyText.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, -1);
        propertyText.transform.parent = GameObject.Find("UIMain").transform;
        propertyText.transform.position = new Vector3(360, 640, 1);
        propertyText.GetComponent<TextManager>().value = textValue;
        propertyText.transform.SetAsLastSibling();
    }

    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_MidTextShow);
    }
    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_MidTextShow:
                string textValue = (string)data;
                MidTextShow(textValue);
                break;
        }
            
    }
}
