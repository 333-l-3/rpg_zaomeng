using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behave : MonoBehaviour
{
    public Animator animator;  // 像引入刚体组件一样引入动画器组件
    public Rigidbody2D rigidBody;
    // ...

    void Update()
    {

        animator.SetFloat("trs", Mathf.Abs(rigidBody.velocity.x));
    }
}
