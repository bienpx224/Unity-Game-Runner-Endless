using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxTextHandler : FxHandler
{

    public enum COLOR_TYPE
    {
        INCREASE, DECREASE, NORMAL
    }
    [SerializeField] private TMPro.TextMeshPro _text;
    public void SetText(string text, COLOR_TYPE color_type = COLOR_TYPE.NORMAL)
    {
        _text.text = text;
        SetupColor(color_type);
        SetupLayer(Constants.LAYER_OVERLAY_NAME);
    }
    public void SetupLayer(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer(layerName);
            for (int j = 0; j < child.gameObject.transform.childCount; j++)
            {
                var child2 = child.gameObject.transform.GetChild(j);
                child2.gameObject.layer = LayerMask.NameToLayer(layerName);
            }
        }
    }
    private void SetupColor(COLOR_TYPE color_type)
    {
        if (color_type == COLOR_TYPE.INCREASE)
        {  // Color = green 
            _text.color = Color.green;
        }
        else if (color_type == COLOR_TYPE.DECREASE)
        { // Setup color = red 
            _text.color = Color.red;
        }
        else if (color_type == COLOR_TYPE.NORMAL)
        {
            _text.color = Color.yellow;
        }
    }
}
