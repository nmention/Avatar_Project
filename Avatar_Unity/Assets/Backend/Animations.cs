using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Data;
using System.Runtime.CompilerServices;






public class Animations : MonoBehaviour
{
    private Animator animator;
    private Avatar avatar;

    private CustomAvatar customAvatar;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        customAvatar = new CustomAvatar();




    }








    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {

            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetTrigger("BeginAnimation");
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Stop");
            print(customAvatar.getJson());


        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Speed");
        }
    }
}

