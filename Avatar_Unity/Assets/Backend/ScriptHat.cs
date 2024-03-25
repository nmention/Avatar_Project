using UnityEngine;


public class ToggleObject : MonoBehaviour
{
    public GameObject Hat; // R�f�rence � l'objet � activer/d�sactiver

    // Fonction pour activer/d�sactiver l'objet
    public void APPARITITIITIT()
    {
        if (Hat != null)
        {
            Hat.SetActive(!Hat.activeSelf);
        }
    }
}
