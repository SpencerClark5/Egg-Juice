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
    // Start is called before the first frame update
    void Start()
    {
       GM = GameObject.Find("GameManager").GetComponent<GameManager>();
       btn.onClick.AddListener(ButtonClick);
       objectToDisappear = GameObject.Find("PlayButton");
    }

    //when the button is clicked
    private void ButtonClick()
    {

        //play an animation
        //switch the game state
        Debug.Log("Click");
        GM.UpdateGameState(GameManager.GameState.Round);
        objectToDisappear.SetActive(false);

        //make the button dissapear until next round



    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
