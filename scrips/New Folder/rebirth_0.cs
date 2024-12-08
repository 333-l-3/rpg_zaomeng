using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class rebirth_0 : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float slider_reblood;
    public GameObject player;
    private float a = 0,b;
    private bool flag = false;
    // Update is called once per frame

    void Update()
    {
        if(flag) b += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            flag = true;
            a = b;
            Debug.Log("3s ºóË¢ÐÂÐ¡¹Ö");
        }
        if ( b - a > 3&& flag) Rebirth();
    }
    private void Rebirth()
    {
        player.SetActive(true);
        slider.value = slider_reblood;
        flag = false;
    }
}
