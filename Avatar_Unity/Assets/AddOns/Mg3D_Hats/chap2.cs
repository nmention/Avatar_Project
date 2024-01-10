using UnityEngine;

public class ToggleChapeau : MonoBehaviour
{
    public GameObject Hat1; // Référence à l'objet à activer/désactiver
    public GameObject Hat2;
    public static int M=0;
    // Fonction pour activer/désactiver l'objet
    public void changement()
    {
        if (M == 0) { 
            Hat1.SetActive(!Hat1.activeSelf); 
        }
        if (M == 1)
        {
            Hat1.SetActive(!Hat1.activeSelf);
            Hat2.SetActive(!Hat2.activeSelf);
        }
        if(M == 2)
        {
            Hat2.SetActive(!Hat2.activeSelf);
        }
        M++;
    }
}
