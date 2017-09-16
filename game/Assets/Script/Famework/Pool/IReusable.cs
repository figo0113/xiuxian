using UnityEngine;
using System.Collections;

public interface IReusable  {


    void OnSpawn();//取出时调用
    void OnUnspawn();//回收时调用

}
