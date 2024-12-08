using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cl1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        Debug.Log("ÒÑÑ¡Ôñpv1");
        pv_1.txt.SetActive(true);
        pv_2.txt.SetActive(false);
    }

}
