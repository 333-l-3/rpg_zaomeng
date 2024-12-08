using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.HDROutputUtils;

public class sc_g : MonoBehaviour
{
    // Start is called beforue the first frame update
    public GameObject bac;
    public bool u=false;
  
    
    // Update is called once per frame
    void Update()
    {
        u = Input.GetButton("au");
        auto();
    }
    void auto()
    {
        if (Input.GetKeyDown(KeyCode.T) && u) { Debug.Log("±³¾°¿ªÊ¼¹ö¶¯"); u = false;StartCoroutine(Screen()); }
    }
    IEnumerator Screen()
    {
        float rode = bac.GetComponent<Renderer>().transform.localPosition.x - 20;
        while (true)
        {
            bac.GetComponent<Renderer>().transform.localPosition = new Vector3(bac.GetComponent<Renderer>().transform.localPosition.x-Time.deltaTime*10, (float)-0.73, 0);
            if (bac.GetComponent<Renderer>().transform.localPosition.x < rode)
            { break; }
            yield return null;
        }
    }
    void Stop()
    {
        StopCoroutine(Screen());
    }


    }
