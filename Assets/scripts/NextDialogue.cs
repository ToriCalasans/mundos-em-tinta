using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
int index = 2;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            // if (PlayerMovement.dialog)
            if (Personagem.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if(transform.childCount == index){
                    index = 2;
                    Personagem.dialogue = false;
                    // PlayerMovement.dialog = false;

                }
            }
            else{
                gameObject.SetActive(false);
            }
        }

    }
}
