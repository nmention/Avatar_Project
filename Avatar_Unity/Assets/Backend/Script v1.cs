using UnityEngine;

public class ToggleObjectsInFolder : MonoBehaviour
{
    public static int M = 0;
    // Fonction pour activer/désactiver tous les objets dans le dossier




    public void ToggleAnObjects()
    {
        // Charger tous les objets du dossier
        GameObject[] hats = Resources.LoadAll<GameObject>("");

        // Activer ou désactiver chaque objet
        foreach (GameObject hat in hats)
        {
            print("XSDSD");
            if (hat != null)
            {
                hat.SetActive(!hat.activeSelf);
            }
        }
    }
}