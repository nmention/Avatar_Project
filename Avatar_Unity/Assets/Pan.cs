using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HUDManager : MonoBehaviour
{
    public string resourcesFolderPath = "Models"; // Chemin du dossier Resources

    public GameObject hudElementPrefab; // Préfab à utiliser pour afficher chaque élément dans le HUD
    public Transform contentPanel; // Panneau où afficher les éléments

    void Start()
    {
        LoadAndDisplayElements();
    }

    void LoadAndDisplayElements()
    {
        string[] elementPaths = Directory.GetFiles(Application.dataPath + "/Resources/" + resourcesFolderPath, "*.prefab");

        foreach (string path in elementPaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(path);
            GameObject elementPrefab = Resources.Load<GameObject>(resourcesFolderPath + "/" + fileName);

            if (elementPrefab != null)
            {
                GameObject hudElement = Instantiate(hudElementPrefab, contentPanel);
                hudElement.GetComponentInChildren<Text>().text = fileName;

                // Ajoutez ici d'autres modifications à l'élément HUD si nécessaire
            }
            else
            {
                Debug.LogWarning("Impossible de charger le prefab : " + fileName);
            }
        }
    }
}
