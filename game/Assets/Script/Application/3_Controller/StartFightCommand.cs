using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StartFightCommand : Controller
{
    public override void Execute(object data)
    {
        FightArgs e = data as FightArgs;
        FightModel fm = GetModel<FightModel>();
        fm.LoadFightModel(e);
        Game.Instance.LoadScene(3);
    }
}
