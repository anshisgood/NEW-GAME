using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSpinner : MonoBehaviour
{
    public Image image;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -90 * Time.deltaTime));
    }
}
