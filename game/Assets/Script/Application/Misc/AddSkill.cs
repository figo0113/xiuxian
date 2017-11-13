using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSkill : View
{

    private double LeftLimt = 0;
    private double RightLimt = 0;
    private double UpLimt = 0;
    private double DownLimt = 0;

    public override string Name
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new NotImplementedException();
    }
}