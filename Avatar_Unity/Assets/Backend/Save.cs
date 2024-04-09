using UnityEngine;

using System.IO;
using TMPro;
using UnityEngine.UI;
using Data;






public class Save : MonoBehaviour
{
    // Start is called before the first frame update
   public Button saveBt;

    
   

  
    
    void Start()
    {
        saveBt = GetComponent<Button>();
        //
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void writeJson(string filename, CustomAvatar customAvatar)
    {
        foreach (var item in customAvatar.accessoriesPathList)
        {
            print(item);
        }
        print(customAvatar.date);
        string json = customAvatar.getJson();
        Debug.Log("json object :");
        Debug.Log(json);
        string filePath = Path.Combine(Application.persistentDataPath,filename);
         try
        {
            // Write the JSON string to the file
            Debug.Log(Application.persistentDataPath);
            File.WriteAllText(filePath, json);
            Debug.Log("JSON file written successfully.");
        }
        catch (IOException e)
        {
            Debug.LogError("Error writing JSON file: " + e.Message);
        }
        
        


    }

    public void doSomething()
    {

    }


    public static string readJson(string pathname)
    {
        return "";
    }

    public void setListener()
    {
        saveBt.onClick.AddListener(delegate{writeJson("save.json",UIManager.customAvatar);});
    }

   
}



