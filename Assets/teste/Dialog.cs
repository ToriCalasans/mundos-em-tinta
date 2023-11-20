using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public string speechText;
    public string actorName;

    private DialogControl dc;
    private void Start (){
        dc = FindObjectOfType<DialogControl>();
    }

    public void Interact(){
        
    }

}
