using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class SaveJson : MonoBehaviour
{
    public GameObject targetObject; // GameObject cible à sérialiser

    public void SaveComponentsToJson(string filePath)
    {
        if (targetObject == null)
        {
            Debug.LogError("Target GameObject is null. Please assign a valid GameObject.");
            return;
        }

        // Récupérer tous les composants attachés au GameObject cible
        Component[] components = targetObject.GetComponents<Component>();

        // Créer une liste de dictionnaires pour stocker les propriétés de chaque composant
        List<Dictionary<string, object>> componentDataList = new List<Dictionary<string, object>>();

        // Pour chaque composant, récupérer ses propriétés et les ajouter à la liste
        foreach (Component component in components)
        {
            Dictionary<string, object> componentData = new Dictionary<string, object>();

            // Ajouter le nom du type de composant
            componentData["ComponentType"] = component.GetType().Name;

            // Ajouter les propriétés du composant en tant que paires clé-valeur
            foreach (var field in component.GetType().GetFields())
            {
                componentData[field.Name] = field.GetValue(component);
            }

            componentDataList.Add(componentData);
        }

        // Convertir la liste de dictionnaires en JSON
        string jsonData = JsonUtility.ToJson(componentDataList, true);

        // Écrire les données JSON dans un fichier
        File.WriteAllText(filePath, jsonData);

        Debug.Log("Components data saved to: " + filePath);
    }
}
