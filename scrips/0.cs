
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //��������������ռ�

public class TransScene : MonoBehaviour
{
    //�������η�Ӧ���ǹ��еģ����ⲿ���Է��ʵ�
    public void TS()
    {
        SceneManager.LoadScene("SampleScene1");  //����������Ҫ�л��ĳ�������
    }
}
