using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ExitFightommand : Controller
{
    public override void Execute(object data)
    {
        Game.Instance.LoadScene(2);
    }
}