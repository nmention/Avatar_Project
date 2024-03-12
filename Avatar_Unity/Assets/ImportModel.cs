using UnityEngine;
using System.Collections;

public class ImportModel : MonoBehaviour
{
    // Chemin vers le dossier contenant les mod�les FBX dans le dossier Resources
    public string folderPath = "Models";
    public static int M = -1;
    Object[] models = null;
    GameObject previousHat = null;

    void Start()
    {
        print("start");
        // Charger tous les objets du dossier sp�cifi�
        models = Resources.LoadAll(folderPath, typeof(GameObject));

        // Instancier chaque mod�le dans la sc�ne
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
                // Attacher le chapeau en tant qu'enfant de l'articulation de la t�te
                

                // R�initialiser la position et la rotation du chapeau pour le placer correctement par rapport � l'articulation de la t�te
                previousHat.transform.SetParent(head);
                previousHat.transform.localPosition = Vector3.zero;
                previousHat.transform.localRotation = Quaternion.identity;
            }
            else
            {
                Debug.LogError("L'articulation de la t�te (\"HeadTop_End\") n'a pas �t� trouv�e.");
            }
        }
        else
        {
            // Si M d�passe les limites, r�initialiser M � -1
            M = -1;

            // D�truire le chapeau pr�c�dent s'il existe
            if (previousHat != null)
            {
                Destroy(previousHat);
            }
        }
    }
}
