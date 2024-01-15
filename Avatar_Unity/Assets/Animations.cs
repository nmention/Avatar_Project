using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            print("animator");
            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetTrigger("BeginAnimation");
            }
        }
         if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetTrigger("Stop");
            }

         if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("Speed");
            }
    }
}
