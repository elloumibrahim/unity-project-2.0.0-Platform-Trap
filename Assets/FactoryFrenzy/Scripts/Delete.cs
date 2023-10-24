using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class Delete : MonoBehaviour
{
 

    public InputActionReference deleteRef;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deleteRef.action.triggered)
        {
            onDelete();
        }
    }

    private void onDelete()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (!hit.collider.CompareTag("Undeletable"))
            {
                Destroy(hit.collider.gameObject);
                if (audioManager != null)
                {
                    audioManager.PlayDeletionSound();
                }
               
            }
        }
    }
}
