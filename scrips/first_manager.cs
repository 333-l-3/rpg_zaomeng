using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

using Unity.VisualScripting;
using static UnityEngine.Rendering.HDROutputUtils;
public class first_manager : MonoBehaviour
{
    public Slider slider ;
    public Text text;
    public GameObject image_bak ;
    private float operator1;
    public bool open = false;
    public int a = 1;
    public void load_screen()
    {
        image_bak.gameObject.SetActive(true);
        slider.value = 0;
        slider.gameObject.SetActive(true);
        StartCoroutine(Screen_load());
    }
    
    IEnumerator Screen_load()
    {
        int displayProgress = 0;  //��ʾ����
        int toProgress = 0;   //�����Ľ���

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+a);
        operation.allowSceneActivation = false;
        while(!operation.isDone)
        {
            //if (slider.value < 0.9)
            //{
            //    slider.value = 1.6f * Time.deltaTime;
            //}
            toProgress = (int)operation.progress * 100;
            //����ʵ�ļ��ؽ��ȴ�����ʾ���ȵĻ�
            while (displayProgress < 65 )
            {
                //��ʾ��������
                ++displayProgress;
                //����������Ľ���ֵͨ��SetLoadingPercentage����������Ϸ�еĻ�������valueֵ
                slider.value = (float)displayProgress/100;
                //�ȴ�һ֡ �ڽ�����ǰ֡ �������GUI����Ⱦ�Լ�����������ɺ�Ż����ִ�е���yield return ����Ĵ���
                yield return null;
            }
            if (operation.progress>=0.9f )
            {
                slider.value = 1;
                text.text = operation.progress * 100 + "/100";
                text.text = "������� 3s�������Ϸ";
                yield return new WaitForSeconds(1f);
                text.text = "������� 2s�������Ϸ";
                yield return new WaitForSeconds(1f);
                text.text = "������� 1s�������Ϸ";
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
                open = true;
                Debug.Log("�������");
                Stop();
            } 
            
            yield return null;
        }
        
    }
    private void Stop()
    {
        StopCoroutine(Screen_load());
    }
}
