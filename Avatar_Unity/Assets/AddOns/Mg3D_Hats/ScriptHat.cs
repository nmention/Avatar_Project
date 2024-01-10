using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject Hat; // Référence à l'objet à activer/désactiver

    // Fonction pour activer/désactiver l'objet
    public void APPARITITIITIT()
    {
        if (Hat != null)
        {
            Hat.SetActive(!Hat.activeSelf);
        }
    }
}
