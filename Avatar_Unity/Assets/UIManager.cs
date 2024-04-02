using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class UIManager : MonoBehaviour
{
    public string folderPath = "Models"; // Chemin du dossier contenant les mod�les
    public GameObject modelPrefab; // Pr�fab pour repr�senter chaque mod�le
    public Transform panel; // Panneau UI pour contenir les carr�s vides
    public Transform panel2; // Panneau UI pour contenir les carr�s vides
    public Load Imp;
    GameObject buttonObject;
    void Start()
    {
        LoadModels();
        LoadPannel();
    }

    void LoadModels()
    {
        // Obtenez les chemins de tous les fichiers FBX dans le dossier sp�cifi�
        string[] modelPaths = Directory.GetFiles(Application.dataPath + "/Resources/" + folderPath, "*.fbx");
        // print(modelPaths[0]); check path
        foreach (string path in modelPaths)
        {
            // Charger le mod�le depuis le chemin du fichier
            GameObject model = Resources.Load<GameObject>(folderPath + "/" + Path.GetFileNameWithoutExtension(path));
            // print(model); check model
            if (model != null)
            {
                // Cr�ez un bouton pour repr�senter le mod�le
                buttonObject = Instantiate(modelPrefab, panel); // cree le bouton
                buttonObject.GetComponentInChildren<TextMeshProUGUI> ().text = Path.GetFileNameWithoutExtension(path);

                buttonObject.GetComponent<Button>().onClick.AddListener(() => ImportModel(model));
            }
            else
            {
                Debug.LogWarning("Impossible de charger le mod�le : " + Path.GetFileNameWithoutExtension(path));
            }
        }
        buttonObject = Instantiate(modelPrefab, panel); // cree le bouton
        buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = "vide";
        Load x = new Load();
        buttonObject.GetComponent<Button>().onClick.AddListener(() => Load.ClearOld());
    }

    void ImportModel(GameObject model)
    {
        // Importez le mod�le dans la sc�ne
        print("BOOM");
        
        if (Imp == null)
        {
            Imp = new Load();
        }
        print("x1");
        if (model != null) { }
        Imp.Display(model.name);
        print("x2");
        //Instantiate(model, Vector3.zero, Quaternion.identity);
    }

    void LoadPannel()
    {
        //string folderNames = Resources.Load<string>(folderPath + "/" + Path.GetFileNameWithoutExtension("")); // take ressources files name 


    }
}
