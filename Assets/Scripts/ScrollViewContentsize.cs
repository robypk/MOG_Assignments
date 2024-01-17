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
        float contentHight = Screen.height * 0.08f;
        float recthight = rectTransform.childCount * contentHight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, recthight);
    }
}
