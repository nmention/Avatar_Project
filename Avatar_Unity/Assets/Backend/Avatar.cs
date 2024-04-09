
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Data
{   
    [Serializable]
     public class CustomAvatar
    {
        public DateTime date;

        public String avatarPath;
        
        public List<string> accessoriesPathList;

        public List<GameObject> accessoriesList;



        public CustomAvatar()

        {
            accessoriesList = new List<GameObject>();
            accessoriesPathList = new List<string>();
            avatarPath = "";
            
            date = DateTime.UtcNow;
        }

        public void addAccessories(GameObject accessory, string pathname)
        {
            accessoriesList.Add(accessory);
            accessoriesPathList.Add(pathname);
            
        }

        public void addAccessoryPath(string pathname)
        {
            accessoriesPathList.Add(pathname);
        }

        public int getNbAccessories()
        {
            return accessoriesPathList.Count;
        }

        public string getJson()
        {
            Debug.Log("verif");
            Debug.Log(this);
            string json = JsonUtility.ToJson(this);
            return json;

        }


        public string getLastAccessory()
        {
            return accessoriesPathList.Last();
        }

        public void deleteLastAccessory()
        {
            accessoriesPathList.RemoveAt(accessoriesPathList.Count - 1);
        }


        public void setCurrentTime()
        {
            date = DateTime.UtcNow;
        }


        public override string ToString()
    {
        return "Avatar: " + avatarPath + " " + date + " "  + accessoriesList + " " + accessoriesPathList;
    }





        



    }
}