﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class MVC
{
    //存储MVC
    public static Dictionary<string,Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();

    //注册
    public static void RegisterModel(Model modle)
    {
        Models[modle.Name] = modle;
    }
    public static void RegisterView(View view)
    {
        //防止重复注册
        if (Views.ContainsKey(view.Name))
            Views.Remove(view.Name);

        //注册关心的事件
        view.RegisterEvents();

        //缓存
        Views[view.Name] = view;


    }
    public static void RegisterController(string eventNamem, Type controllerType)
    {
        CommandMap[eventNamem] = controllerType;

    }
    public static T GetModel<T>()
        where T:Model
    {
        foreach (Model m in Models.Values)
        {
            if (m is T)
                return (T)m ;
        }
        return null;
    }
    public static T GetView<T>()
    where T : View
    {
        foreach (View v in Views.Values)
        {
            if (v is T)
                return (T)v;
        }
        return null;
    }

    //发送事件
    public static void SendEvent(string eventName, object data = null)
    {
        //控制器响应事件
        if (CommandMap.ContainsKey(eventName))
        {
            Type t = CommandMap[eventName];
            Controller c = Activator.CreateInstance(t) as Controller;
            //控制器执行
            c.Execute(data);
        }

        //视图响应事件
        foreach (View v in Views.Values)
        {
            if (v.AttentionEvents.Contains(eventName))
            {
                //视图响应
                v.HandleEvent(eventName, data);
            }
        }
    }

}

