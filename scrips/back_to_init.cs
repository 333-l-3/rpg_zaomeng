using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_init : MonoBehaviour
{
    // Start is called before the first frame update
    public void onclick_back()
    {
        SceneManager.LoadScene("SampleScene2");
    }


}
