using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class ApplicationBase<T>:Singleton<T>
    where T:MonoBehaviour
{
    //注册控制器
    protected void ReigisterController(string enentName, Type controllerType)
    {
        MVC.RegisterController(enentName, controllerType);
    }
    protected void SendEvent(string eventName, object args =null)
    {
        MVC.SendEvent(eventName, args);
    }
}
