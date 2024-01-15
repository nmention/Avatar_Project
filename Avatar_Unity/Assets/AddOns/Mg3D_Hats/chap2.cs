using UnityEngine;

public class ToggleChapeau : MonoBehaviour
{
    public GameObject Hat1; // R�f�rence � l'objet � activer/d�sactiver
    public GameObject Hat2;

    public Animator Girl_Controller;
    public static int M=0;

    
    // Fonction pour activer/d�sactiver l'objet
    public void changement()
    {
        if (M % 2 == 0) { 
            Hat1.SetActive(!Hat1.activeSelf); 
        }
        if (M % 2 ==  1)
        {
            Hat1.SetActive(!Hat1.activeSelf);
            Hat2.SetActive(!Hat2.activeSelf);
        }
        
        M++;
    }
}
