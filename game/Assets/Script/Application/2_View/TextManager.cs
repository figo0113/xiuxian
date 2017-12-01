using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TextManager : View
{
    public string value;
    private Vector3 mTarget;
    private Vector3 mScreen;

    public float textWidth = 100;
    public float textHeight = 50;

    private Vector2 mPoint;
    public float FreeTime = 1.5f;

    void Start()
    {
       //修改文字
        Text text = GetComponent<Text>();
        text.text = value;
        //开启自动销毁线程  
        StartCoroutine("Free");
    }
    void Update()
    {
        //使文本在垂直方向山产生一个偏移  
        transform.Translate(Vector3.up * 0.5F * Time.deltaTime);
    }
    IEnumerator Free()
    {
        yield return new WaitForSeconds(FreeTime);
        Destroy(this.gameObject);
    }

    public override string Name
    {
        get
        {
            return Consts.V_TextManager;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {

    }
}
