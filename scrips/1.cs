using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransScene1 : MonoBehaviour
{
    //�������η�Ӧ���ǹ��еģ����ⲿ���Է��ʵ�
    public void TS1()
    {
        SceneManager.LoadScene("SampleScene2");  //����������Ҫ�л��ĳ�������
    }
}

