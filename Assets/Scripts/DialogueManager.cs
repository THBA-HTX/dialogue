using System.Collections;

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime; // Story

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    // UI elements to update during dialog
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel; // for at kunne tilgå dialog panel ..(show and hide)
    [SerializeField] private TextMeshProUGUI dialogueText; // for at kunne ændre text i dialog
    private Story currentStory; // Hvilken story er vi at vise/fortælle
    public bool dialogueIsPlaying { get; private set; } // Er der en dialog igen eller ej.
    private DialogueVariables dialogueVariables;

    //==== VALG FRA PLAYER ==============================================================================================
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    //public Animator animator;

    private Queue<string> sentences;

    public void Awake() {
        if (instance != null)
            Debug.Log("Dialogmanager has more than one instance ...");
        instance = this;
        //sentences = new Queue<string>();
        dialogueVariables = new DialogueVariables();
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    public void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //==== Set player choices op =======================================================================
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialogueVariables.StopListening(currentStory);
    }

    public void Update() {
        // Hvis der ikke er en dialog igang så exit(return) med det samme.
        if (!dialogueIsPlaying) {
            return;
        }

        // Lyt efter at bruger trykker submit
        if (InputManager.GetInstance().GetSubmitPressed()) {
            ContinueStory();
        }
    }


    public void ContinueStory() {
        if (currentStory.canContinue) // Kan vi start dialogen ?
        {
            // Vis dialog
            dialogueText.text = currentStory.Continue();

            // Vis valgmuligheder (if any)
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }


    public void DisplayChoices() {

        List<Choice> currentChoices = currentStory.currentChoices;

        // Check om vi har fået flere valgmuligheder ind, end vores UI kan håndtere.
        if (currentChoices.Count > choicesText.Length) {
            Debug.Log("Der er indlæst flere valgmuligheder end UI kan håndtere");
        }


        int index = 0;
        // Vi indlæser de valgmuligheder der angives i Ink Story objekt ind i GUI.
        foreach (Choice choice in currentChoices) {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // Gå igennem de resterende valg-felter og sæt dem som in-aktive (hidden)
        for (int i = index; i < choices.Length; i++) {
            choices[index].gameObject.SetActive(false);
        }

    }

}

