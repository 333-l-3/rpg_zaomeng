using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peng : MonoBehaviour
{
    // Start is called before the first frame update

    

    // 触发器事件，当一个物体进入另一个物体的触发器时被调用
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("进入触发器：" + other.gameObject.name);
    }

    
}
