﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class  Model
{
    public abstract string Name{get;}

    protected void SendEvent(string eventName, object data = null)
    {
        MVC.SendEvent(eventName, data);
    }
    protected T GetModel<T>()
    where T : Model
    {
        return MVC.GetModel<T>() as T;
    }
}