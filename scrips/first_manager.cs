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
        int displayProgress = 0;  //显示进度
        int toProgress = 0;   //真正的进度

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+a);
        operation.allowSceneActivation = false;
        while(!operation.isDone)
        {
            //if (slider.value < 0.9)
            //{
            //    slider.value = 1.6f * Time.deltaTime;
            //}
            toProgress = (int)operation.progress * 100;
            //当真实的加载进度大于显示进度的话
            while (displayProgress < 65 )
            {
                //显示进度自增
                ++displayProgress;
                //把自增过后的进度值通过SetLoadingPercentage方法传到游戏中的滑动条的value值
                slider.value = (float)displayProgress/100;
                //等待一帧 在结束当前帧 摄像机和GUI被渲染以及其它函数完成后才会继续执行当行yield return 后面的代码
                yield return null;
            }
            if (operation.progress>=0.9f )
            {
                slider.value = 1;
                text.text = operation.progress * 100 + "/100";
                text.text = "加载完毕 3s后进入游戏";
                yield return new WaitForSeconds(1f);
                text.text = "加载完毕 2s后进入游戏";
                yield return new WaitForSeconds(1f);
                text.text = "加载完毕 1s后进入游戏";
                yield return new WaitForSeconds(1f);
                operation.allowSceneActivation = true;
                open = true;
                Debug.Log("加载完成");
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
