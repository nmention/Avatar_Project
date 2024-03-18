using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;

public class Avatar : MonoBehaviour
{


    
    public string Name
    {
        get; set;
    }
    public DateTime LastModification
    {
        get; set;
    }

    public string Hat
    {
        get; set;
    }


    public void saveAvatarAsJson(string pathname)
    {
        print("yes");
        print(this.Name);
        print("yes");
       
        string save = JsonSerializer.ToJsonString(this);
        print(save);

    }




    
    
    // Start is called before the first frame update
    void Start()
    {
        Avatar avatar = new Avatar();
        avatar.Name = "test";
        avatar.Hat = "casquette";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
