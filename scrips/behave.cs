using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behave : MonoBehaviour
{
    public Animator animator;  // ������������һ�����붯�������
    public Rigidbody2D rigidBody;
    // ...

    void Update()
    {

        animator.SetFloat("trs", Mathf.Abs(rigidBody.velocity.x));
    }
}
