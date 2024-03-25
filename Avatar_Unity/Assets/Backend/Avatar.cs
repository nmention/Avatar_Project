
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Data
{   
    [Serializable]
     public class CustomAvatar
    {
        public DateTimeOffset date;

        public String avatarPath;
        
        public List<String> accessoriesPathList;

        public List<GameObject> accessoriesList;



        public CustomAvatar()

        {
            accessoriesList = new List<GameObject>();
            accessoriesPathList = new List<string>();
            avatarPath = "";
            
            date = DateTimeOffset.UtcNow;
        }

        public void addAccessories(GameObject accessory, String pathname)
        {
            accessoriesList.Add(accessory);
            accessoriesPathList.Add(pathname);
            
        }

        public int getNbAccessories()
        {
            return accessoriesPathList.Count;
        }

        public string getJson()
        {
            string json = JsonUtility.ToJson(this);
            return json;

        }



    }
}