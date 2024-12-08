using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class pv_2 : MonoBehaviour
{
    public static GameObject txt;				

	void Start()
    {
        txt = GameObject.Find("tangu_kun");
        txt.SetActive(false);

    }
}