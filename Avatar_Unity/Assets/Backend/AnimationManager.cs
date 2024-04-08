using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor.Animations;

public class AnimationManager : MonoBehaviour
{
    public string animationsFolderPath = "Animations"; // Chemin du dossier contenant les animations .anim
    public GameObject animationButtonPrefab; // Pr�fab pour repr�senter chaque animation dans le panneau
    public Transform panel; // Panneau UI pour contenir les animations
    public Animator characterAnimator; // Animator du personnage dans la sc�ne
    void Start()
    {

        LoadAnimations();
    }

    void LoadAnimations()
    {
        // R�cup�re la liste des fichiers .anim dans le dossier sp�cifi�
        string[] animationFiles = Directory.GetFiles(Application.dataPath + "/" + animationsFolderPath, "*.anim");

        // Parcourt tous les fichiers .anim trouv�s
        foreach (string file in animationFiles)
        {
            // R�cup�re le nom du fichier sans extension
            string animationName = Path.GetFileNameWithoutExtension(file);

            // Cr�e un bouton pour repr�senter l'animation
            GameObject animationButton = Instantiate(animationButtonPrefab, panel);
            animationButton.GetComponentInChildren<Text>().text = animationName;

            // Ajoute un �couteur de clic au bouton pour jouer l'animation
            animationButton.GetComponent<Button>().onClick.AddListener(() => PlayAnimation(animationName));
        }
    }
    void PlayAnimation(string animationName)
    {

        characterAnimator.Play(animationName,0);
    }
}

