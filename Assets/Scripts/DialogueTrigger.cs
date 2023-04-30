using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange;

    [Header("Ink JSCON")]
    [SerializeField] private TextAsset inkJSON;


    // Start is called before the first frame update
    void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false); // Som udgangspunkt er visualCue ikke synligt
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // Kan kun trigges fra et Ojbekt med tag "Player"
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            playerInRange = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying )
         {
            visualCue.SetActive(true);
        //    if ( InputManager.GetInstance().GetInteractPressed()) {
        //        DialogueManager.GetInstance().EnterDialogMode(inkJSON);
                //Debug.Log(inkJSON.text);
         //    }
        }
        else {
            visualCue.SetActive(false);
        }
    }
}
