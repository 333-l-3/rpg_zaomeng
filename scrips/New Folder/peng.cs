using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peng : MonoBehaviour
{
    // Start is called before the first frame update

    

    // �������¼�����һ�����������һ������Ĵ�����ʱ������
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("���봥������" + other.gameObject.name);
    }

    
}
