using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueVariables
{

    private Dictionary<string, Ink.Runtime.Object> varibles;
    public void StartListening(Story story) {
        story.variablesState.variableChangedEvent += VariableChanged; // ved ændring .. adviseres til "VariableChanged" metode.
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    public void VariableChanged(string varName, Ink.Runtime.Object value) {
        Debug.Log("Variable changed : " + varName + " = " + value);
    }

}
