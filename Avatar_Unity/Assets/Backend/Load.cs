using System.IO;
using Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Load : MonoBehaviour
{
    // Chemin vers le dossier contenant les mod�les FBX dans le dossier Resources
    public string folderPath = "Models";
    static GameObject previousHat = null;

    public Button LoadBt;


    public Button CancelBt;
    void Start()
    {
        LoadBt.GetComponent<Button>();
        CancelBt.GetComponent<Button>();
    }
    public void Display(string s)
    {
        Object[] models = Resources.LoadAll(folderPath, typeof(GameObject));
        GameObject personnage = GameObject.Find("girl_nonPBR");
        Transform head = personnage.transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head/mixamorig:HeadTop_End");
        int i;
        bool ch = false;

        if (previousHat != null)
        {
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
            if (models[i] != previousHat)
            {

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


    public CustomAvatar GetLoadFromSave(string filename)
    {
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        CustomAvatar savedAvatar = null;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            savedAvatar = JsonUtility.FromJson<CustomAvatar>(json);

        }
        return savedAvatar;
    }

    public void LoadFromSave(string filepath)
    {
        CustomAvatar loadedAvatar;
        loadedAvatar = GetLoadFromSave(filepath);
        DisplayLastSavedAccessories(loadedAvatar);
        System.Diagnostics.Process.Start(Application.persistentDataPath);
    }


    public void DisplayLastSavedAccessories(CustomAvatar savedAvatar)
    {
        Debug.Log("Yes");
        Display(savedAvatar.getLastAccessory());
    }


    public void setListener()
    {
        LoadBt.onClick.AddListener(delegate { LoadFromSave("save.json"); });
    }


    public void cancel(CustomAvatar currentAvatar)
    {
        if (currentAvatar.accessoriesPathList.Count > 1)
        {
            currentAvatar.deleteLastAccessory();
            DisplayLastSavedAccessories(currentAvatar);
        }
        else
        {
            ClearOld();
        }
    }


    public void setCancelListener(CustomAvatar currentAvatar)
    {
        CancelBt.onClick.AddListener(delegate { cancel(currentAvatar); });
    }


}
