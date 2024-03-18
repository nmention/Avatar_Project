using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animations : MonoBehaviour
{
    private Animator animator;
    private Avatar avatar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        avatar = new Avatar();
        avatar.Name = "test";
        avatar.Hat = "casquette";

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
                avatar.saveAvatarAsJson("truc");
                
            }

         if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("Speed");
            }
    }
}
