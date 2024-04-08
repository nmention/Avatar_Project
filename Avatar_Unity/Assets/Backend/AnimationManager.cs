using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.Animations;

public class AnimationManager : MonoBehaviour
{
    public string animationsFolderPath = "Animations"; // Chemin du dossier contenant les animations .anim
    public GameObject animationButtonPrefab; // Préfab pour représenter chaque animation dans le panneau
    public Transform panel; // Panneau UI pour contenir les animations
    public Animator characterAnimator; // Animator du personnage dans la scène
    void Start()
    {

        LoadAnimations();
    }

    void LoadAnimations()
    {
        // Récupère la liste des fichiers .anim dans le dossier spécifié
        string[] animationFiles = Directory.GetFiles(Application.dataPath + "/" + animationsFolderPath, "*.anim");

        // Parcourt tous les fichiers .anim trouvés
        foreach (string file in animationFiles)
        {
            // Récupère le nom du fichier sans extension
            string animationName = Path.GetFileNameWithoutExtension(file);

            // Crée un bouton pour représenter l'animation
            GameObject animationButton = Instantiate(animationButtonPrefab, panel);
            animationButton.GetComponentInChildren<Text>().text = animationName;

            // Ajoute un écouteur de clic au bouton pour jouer l'animation
            animationButton.GetComponent<Button>().onClick.AddListener(() => PlayAnimation(animationName));
        }
    }
    void PlayAnimation(string animationName)
    {

        characterAnimator.Play(animationName,0);
    }
}

