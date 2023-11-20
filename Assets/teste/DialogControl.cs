using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
   [Header("Componentes")]
   public GameObject dialogObj; 
   // public Image profile;
   public Text speechText;
   public Text actorNameText;

   [Header("Settings")]
   public float typingSpeed;

   public void Speech(Sprite avatar, string txt, string actorName){
        dialogObj.SetActive(true);
      //   profile.Sprite = avatar;
        speechText.text = txt;
        actorNameText.text = actorName;
   }
}
