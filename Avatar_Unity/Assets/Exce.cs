using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void doo()
    {
        SaveJson gameObjectToJson = GetComponent<SaveJson>();
    gameObjectToJson.SaveComponentsToJson("ComponentsData.json");
    }
}
