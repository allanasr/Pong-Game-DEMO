using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;

    public Player player;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }
    void Start()
    {
        uiImage.color = color;    
    }


    public void OnClick()
    {
        player.ChanceColor(color);
    }
}
