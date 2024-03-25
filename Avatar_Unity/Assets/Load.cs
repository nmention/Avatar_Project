using Unity.VisualScripting;
using UnityEngine;
public class Load
{
    // Chemin vers le dossier contenant les modèles FBX dans le dossier Resources
    public string folderPath = "Models";
    static GameObject previousHat = null;
    void Start()
    {
        
    }
    public void Display(string s)
    {
        Object[] models = Resources.LoadAll(folderPath, typeof(GameObject));
        GameObject personnage = GameObject.Find("girl_nonPBR");
        Transform head = personnage.transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head/mixamorig:HeadTop_End");
        int i;
        bool ch = false;
        if (previousHat!= null) { 
        GameObject.Destroy(previousHat);
        }
        for (i = 0; i < models.Length; i++)
        {
            if (models[i].name == s)
            {

                ch = true;
                break;
            }
        }
        if (ch)
        {
            if (models[i]!=previousHat) {

                previousHat = GameObject.Instantiate(models[i]) as GameObject;
                previousHat.transform.SetParent(head);
                previousHat.transform.localPosition = Vector3.zero;
                previousHat.transform.localRotation = Quaternion.identity;
            }          

        }

    }
    public static void ClearOld()
    {
        if (previousHat != null)
        {
            GameObject.Destroy(previousHat);
        }
    }
   

}
