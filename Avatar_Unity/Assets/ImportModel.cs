using UnityEngine;
using System.Collections;

public class ImportModel : MonoBehaviour
{
    // Chemin vers le dossier contenant les mod�les FBX dans le dossier Resources
    public string folderPath = "Models";
    public static int M = -1;
    Object[] models = null;
    GameObject previousHat = null;
    GameObject othersHat = null;
    GameObject personnage = null;
    Transform head=null;

    void Start()
    {
        print("start");
        // Charger tous les objets du dossier sp�cifi�
        models = Resources.LoadAll(folderPath, typeof(GameObject));
        personnage = GameObject.Find("girl_nonPBR");
        head = personnage.transform.Find("mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:Neck/mixamorig:Head/mixamorig:HeadTop_End");
        // Instancier chaque mod�le dans la sc�ne
    }

    public void EVOLVE()
    {
        
        
        
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
    public void display(string s)
    {
        int i;
        bool ch = false;
        print("x3");
        for (i=0; i < models.Length; i++)
        {
            print("x4");
            if (models[i].name == s)
            {
                
                ch = true;
                print("x5");
                break;
            }
        }
        if (ch) {
            print("x6");
            othersHat = Instantiate(models[i]) as GameObject;
            othersHat.transform.SetParent(head);
            othersHat.transform.localPosition = Vector3.zero;
            othersHat.transform.localRotation = Quaternion.identity;

        }
        
    }

}
