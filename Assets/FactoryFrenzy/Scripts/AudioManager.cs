
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip deletionSound; // Le son de suppression que vous souhaitez jouer
    private AudioSource audioSource;

    // Assurez-vous d'attacher un composant AudioSource à l'objet contenant ce script

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource non trouvé. Veuillez attacher un AudioSource à l'objet contenant ce script.");
        }
    }

    public void PlayDeletionSound()
    {
        if (deletionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deletionSound);
        }
        else
        {
            Debug.LogError("Le son de suppression ou AudioSource n'est pas configuré. Veuillez vérifier la configuration de l'AudioManager.");
        }
    }
}
