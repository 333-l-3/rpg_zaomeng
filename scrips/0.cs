
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //首先引入此命名空间

public class TransScene : MonoBehaviour
{
    //访问修饰符应该是公有的，让外部可以访问到
    public void TS()
    {
        SceneManager.LoadScene("SampleScene1");  //引号中是你要切换的场景名字
    }
}
