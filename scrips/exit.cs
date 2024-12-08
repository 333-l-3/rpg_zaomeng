using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    
    public void Close()
    {
        Application.Quit();//退出应用
        Debug.Log("程序已关闭");
    }
}
