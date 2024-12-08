using System.Collections;
using Unity.Mathematics;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Player_basic_attribute;
public class fllow : MonoBehaviour
{
    // ����Slider���  
    public UnityEngine.UI.Slider slider;
    public GameObject player;
    public float bloodtall;
    Vector2 po;
    private float hit_power = 0;
    public float blood;
    public float blood_text_DestoryTime;
    public GameObject text;

    private void Start()
    {
        blood_text_DestoryTime = 0.2f;  
        slider.maxValue = blood;
        slider.value = blood;
    }
    private void Update()
    {
        
        fllow_blood();
        if (slider.value == 0)
            copy();
        
    }
    private void fllow_blood()
    {
        po = new Vector2(player.transform.position.x, (float)(player.transform.position.y + bloodtall));

        slider.GetComponent<RectTransform>().transform.position = Camera.main.WorldToScreenPoint(po);
    }
    private void copy()
    {
         slider.value = 1;
         text.SetActive(false);
         player.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("��⵽�����ܵ�����" + other.gameObject.name);
        hit_power = Player_basic_attribute.Tutorial.hit_power;
        slider.value -= hit_power;
        text.SetActive(true);
        text.GetComponent<Text>().text = hit_power.ToString();
        StartCoroutine("Free");
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("��������");
    }
    IEnumerator Free()  //Э�̣��˺�����ʱ��һ����ʧ
    {
        yield return new WaitForSeconds(blood_text_DestoryTime);
        text.SetActive(false);
        StopCoroutine(Free());
    }
}