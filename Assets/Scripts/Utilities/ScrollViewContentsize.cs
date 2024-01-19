using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewContentsize : MonoBehaviour
{


    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        var height = rectTransform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y * rectTransform.childCount;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
    }
}
