using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;
public class work_slid : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    
    private void Update()
    {
        slider.value += 1.6f * Time.deltaTime;
        if (slider.value > 0.99) {Debug.Log("信息加载完毕"); this.enabled = false; }
    }
}
