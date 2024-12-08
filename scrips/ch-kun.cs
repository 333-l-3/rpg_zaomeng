using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
public class player_control: MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject i_kun;
    private Button btn_Start;
    private int Fall = 0;
    void Start()
    {
        i_kun = GameObject.Find("kun");
        btn_Start = GameObject.Find("secret-ch").GetComponent<Button>();//通过Find查找名称获得我们要的Button组件
        btn_Start.onClick.AddListener(OnStartButtonClick);//监听点击事件
    }
    
    // Update is called once per frame
    void Update()
    {
        if (this.i_kun.transform.localPosition.x > 3.39 && Fall == 1)
        {
            i_kun.GetComponent<Renderer>().transform.localPosition = new Vector2(this.i_kun.transform.localPosition.x + -Time.time / 50, this.i_kun.transform.localPosition.y);
        }
        else
        {
            if(this.i_kun.transform.localPosition.x <= 3.39)
            {
                Debug.Log("加载完毕");
                this.enabled = false;
            }
        }
    }
    public void OnStartButtonClick()
    {
        Debug.Log("点击事件");
        this.Fall = 1;
    }
}
