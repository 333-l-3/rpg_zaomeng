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
        btn_Start = GameObject.Find("secret-ch").GetComponent<Button>();//ͨ��Find�������ƻ������Ҫ��Button���
        btn_Start.onClick.AddListener(OnStartButtonClick);//��������¼�
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
                Debug.Log("�������");
                this.enabled = false;
            }
        }
    }
    public void OnStartButtonClick()
    {
        Debug.Log("����¼�");
        this.Fall = 1;
    }
}
