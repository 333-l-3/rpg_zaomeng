using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cl2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(onclick);
    }

    // Update is called once per frame
    void onclick()
    {
        Debug.Log("��ѡ��pv2");
        pv_1.txt.SetActive(false);
        pv_2.txt.SetActive(true);
    }
}
