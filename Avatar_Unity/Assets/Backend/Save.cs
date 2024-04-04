using UnityEngine;
using Autodesk.Fbx;
using System.IO;



public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    

    
   

  
    
    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void writeJson(string filename, string json)
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + filename,json);
        

    }


    public static string readJson(string pathname)
    {
        return "";
    }

   
}



