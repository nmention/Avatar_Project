using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Networking;


public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public string avatarName;

    public List<GameObject> accessories;
    public GameObject avatar;


    public Save()
    {
        avatarName = avatar.name;
        accessories = new List<GameObject>();
        foreach (GameObject item in accessories)
        {
            this.accessories.Add(item);
        }
    }
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void exportAvatar()
    {
        Save save = new Save();
        string jsonData = JsonUtility.ToJson(avatar);
        

    }
}
