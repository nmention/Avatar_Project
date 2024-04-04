using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class animationManager : MonoBehaviour
{
    public string animationsFolderPath= "Animations"; // Chemin du dossier contenant les animations FBX
    public GameObject animationButtonPrefab; // Préfab pour représenter chaque animation dans le panneau
    public Transform panel; // Panneau UI pour contenir les animations
    public Animator characterAnimator; // Animator du personnage dans la scène


    void Start()
    {
        LoadAnimations();
    }

    void LoadAnimations()
    {
        // Charge toutes les ressources (animations) dans le dossier spécifié
        Object[] animationObjects = Resources.LoadAll(animationsFolderPath, typeof(GameObject));

        // Parcourt toutes les animations chargées
        foreach (Object obj in animationObjects)
        {
            GameObject animationPrefab = (GameObject)obj;

            // Récupère le nom de l'animation à partir du nom du GameObject
            string animationName = animationPrefab.name;

            // Crée un bouton pour représenter l'animation
            GameObject animationButton = Instantiate(animationButtonPrefab, panel);
            animationButton.GetComponentInChildren<Text>().text = animationName;

            // Ajoute un écouteur de clic au bouton pour jouer l'animation
            animationButton.GetComponent<Button>().onClick.AddListener(() => PlayAnimation(animationName));
        }
    }

    void PlayAnimation(string animationName)
    {
        // Met à jour l'animation de l'Animator du personnage avec l'animation correspondant au nom du bouton
        Debug.Log("Playing animation: " + animationName);
        characterAnimator.Play(animationName);
    }
}