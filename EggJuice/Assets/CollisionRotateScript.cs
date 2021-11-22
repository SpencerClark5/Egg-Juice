using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionRotateScript : MonoBehaviour
{
    [SerializeField] private Button button;
    private RotateClickScript clickScript;
    [SerializeField] private BoxCollider2D bigbox;
    [SerializeField] private GameObject cornerBoxGameObject;
    private BoxCollider2D cornerBox;
    private bool rotated = false;
    // Start is called before the first frame update
    void Start()
    {
        button.enabled = true;
        clickScript = button.GetComponent<RotateClickScript>();
        cornerBox = cornerBoxGameObject.GetComponent<BoxCollider2D>();
        clickScript.collisionObject = this.gameObject;
    }

    public void rotate()
    {
        // rotate collision boy
        if (rotated)
        {
            rotated = false;
            cornerBox.offset.Set(-0.75f, 0.25f);
           // bigbox
        }
        else
        {
            rotated = true;
            cornerBox.offset.Set(-0.25f, 0.75f);
        }
    }
    
}
