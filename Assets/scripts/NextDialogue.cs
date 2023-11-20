using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    int index = 2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if (Personagem.dialogue)
            {
                if (index < transform.childCount)
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                    index += 1;
                }
                else
                {
                    index = 2;
                    Personagem.dialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
