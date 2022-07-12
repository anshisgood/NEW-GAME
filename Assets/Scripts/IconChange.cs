using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconChange : MonoBehaviour
{
    public LayerMask interactableLayerMask = 12;
    public Image defaultIcon;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            defaultIcon.rectTransform.sizeDelta = new Vector2(10, 10);
        }
        else
        {
            defaultIcon.rectTransform.sizeDelta = new Vector2(15, 15);
        }
           
    }
}
