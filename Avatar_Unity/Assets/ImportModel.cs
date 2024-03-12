using UnityEngine;
using System.Collections;

public class ImportModel : MonoBehaviour
{
    // Chemin vers le dossier contenant les modèles FBX dans le dossier Resources
    public string folderPath = "Models";
    public static int M = -1;
    Object[] models = null;
    GameObject previousHat = null;

    void Start()
    {
        print("start");
        // Charger tous les objets du dossier spécifié
        models = Resources.LoadAll(folderPath, typeof(GameObject));

        // Instancier chaque modèle dans la scène
    }

    public void EVOLVE()
    {
        
        GameObject personnage = GameObject.Find("girl_nonPBR");
        Transform head = personnage.transform.Find("HeadTop_End");
        int modelCount = models.Length;
        if (M < modelCount-1)
        {
            M++;

            if (previousHat != null)
            {
                Destroy(previousHat);
            }

            previousHat = Instantiate(models[M]) as GameObject;

            
            if (head != null)
            {
                // Attacher le chapeau en tant qu'enfant de l'articulation de la tête
                

                // Réinitialiser la position et la rotation du chapeau pour le placer correctement par rapport à l'articulation de la tête
                previousHat.transform.SetParent(head);
                previousHat.transform.localPosition = Vector3.zero;
                previousHat.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogError("L'articulation de la tête (\"HeadTop_End\") n'a pas été trouvée.");
            }
        }
        else
        {
            // Si M dépasse les limites, réinitialiser M à -1
            M = -1;

            // Détruire le chapeau précédent s'il existe
            if (previousHat != null)
            {
                Destroy(previousHat);
            }
        }
    }
}
