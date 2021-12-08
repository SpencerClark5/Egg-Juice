using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickyScript : MonoBehaviour
{
    GameManager GM;
    [SerializeField] private Button btn = null;
    GameObject objectToDisappear;
    Animator Animation;
    // Start is called before the first frame update
    void Start()
    {
       GM = GameObject.Find("GameManager").GetComponent<GameManager>();
       btn.onClick.AddListener(ButtonClick);
       objectToDisappear = GameObject.Find("PlayButton");
      // ButtonToDisappear = GameObject.Find("ButtonImage");
        Animation = GameObject.Find("ButtonImage").GetComponent<Animator>();
    }

    //when the button is clicked
    private void ButtonClick()
    {

        //play an animation
        Debug.Log("Playing");
        Animation.SetBool("OnClick",true);
        Animation.SetBool("PreRound", false);
        Debug.Log("Plauyed");
        GM.UpdateGameState(GameManager.GameState.Round);
        objectToDisappear.SetActive(false);
       //ButtonToDisappear.SetActive(false);

        //make the button dissapear until next round



    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
