using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class SaveJson : MonoBehaviour
{
    public GameObject targetObject; // GameObject cible � s�rialiser

    public void SaveComponentsToJson(string filePath)
    {
        if (targetObject == null)
        {
            Debug.LogError("Target GameObject is null. Please assign a valid GameObject.");
            return;
        }

        // R�cup�rer tous les composants attach�s au GameObject cible
        Component[] components = targetObject.GetComponents<Component>();

        // Cr�er une liste de dictionnaires pour stocker les propri�t�s de chaque composant
        List<Dictionary<string, object>> componentDataList = new List<Dictionary<string, object>>();

        // Pour chaque composant, r�cup�rer ses propri�t�s et les ajouter � la liste
        foreach (Component component in components)
        {
            Dictionary<string, object> componentData = new Dictionary<string, object>();

            // Ajouter le nom du type de composant
            componentData["ComponentType"] = component.GetType().Name;

            // Ajouter les propri�t�s du composant en tant que paires cl�-valeur
            foreach (var field in component.GetType().GetFields())
            {
                componentData[field.Name] = field.GetValue(component);
            }

            componentDataList.Add(componentData);
        }

        // Convertir la liste de dictionnaires en JSON
        string jsonData = JsonUtility.ToJson(componentDataList, true);

        // �crire les donn�es JSON dans un fichier
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Components data saved to: " + filePath);
    }
}
