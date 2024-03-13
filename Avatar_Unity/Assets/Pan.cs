using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HUDManager : MonoBehaviour
{
    public string resourcesFolderPath = "Models"; // Chemin du dossier Resources

    public GameObject hudElementPrefab; // Pr�fab � utiliser pour afficher chaque �l�ment dans le HUD
    public Transform contentPanel; // Panneau o� afficher les �l�ments

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

                // Ajoutez ici d'autres modifications � l'�l�ment HUD si n�cessaire
            }
            else
            {
                Debug.LogWarning("Impossible de charger le prefab : " + fileName);
            }
        }
    }
}
