using UnityEngine;
using System.Collections;

public class drag : MonoBehaviour
{

    private Vector3 _vec3TargetScreenSpace;// 目标物体的屏幕空间坐标  
    private Vector3 _vec3TargetWorldSpace;// 目标物体的世界空间坐标  
    private Transform _trans;// 目标物体的空间变换组件  
    private Vector3 _vec3MouseScreenSpace;// 鼠标的屏幕空间坐标  
    private Vector3 _vec3Offset;// 偏移  
    private GameObject child;
    private Transform childtrans;

    void Awake() {  _trans = this.transform;

    }
   /* void GetMouseObj()
    {

        if (Input.GetMouseButtonUp(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider.tag.CompareTo("chosehero")==0)
            {
                _trans = hit.collider.gameObject.transform;

            }

        }
    }*/
    IEnumerator OnMouseDown()

    {
        //GetMouseObj();
        if (Input.GetMouseButtonDown(0))
        {
            child = (GameObject)Instantiate(_trans.gameObject, _trans.position, Quaternion.identity);

            childtrans = child.GetComponent<Transform>();
        }

        // 把目标物体的世界空间坐标转换到它自身的屏幕空间坐标   
        _vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(childtrans.position);

        // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）   

        _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

        // 计算目标物体与鼠标物体在世界空间中的偏移量   

        _vec3Offset = childtrans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);



        // 鼠标左键按下   

        while (Input.GetMouseButton(0))
        {

            // 存储鼠标的屏幕空间坐标（Z值使用目标物体的屏幕空间坐标）  

            _vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

            // 把鼠标的屏幕空间坐标转换到世界空间坐标（Z值使用目标物体的屏幕空间坐标），加上偏移量，以此作为目标物体的世界空间坐标  

            _vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

            // 更新目标物体的世界空间坐标   

            childtrans.position = _vec3TargetWorldSpace;


            // 等待固定更新   
          
            yield return new WaitForFixedUpdate();
        }



         //Destroy(child,0.01f);
         
    }


}

