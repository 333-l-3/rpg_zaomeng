using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class pv_1 : MonoBehaviour
{
    public static GameObject txt;				

	void Start()
    {
        txt = GameObject.Find("sun");
        txt.SetActive(false); 

    }
}