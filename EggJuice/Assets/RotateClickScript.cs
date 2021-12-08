using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateClickScript : MonoBehaviour
{
    [SerializeField] private Button btn = null;
    public GameObject collisionObject;
    

    // Start is called before the first frame update

    void Start()
    {
        btn.onClick.AddListener(ButtonClick);
    }

    private void ButtonClick()
    {
        Debug.Log("collision object is null because it didnt say clicked after this");
        if (collisionObject != null)
        {
            Debug.Log("clicked!");
            // call collisionObjects rotate function
            collisionObject.GetComponent<CollisionRotateScript>().rotate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
