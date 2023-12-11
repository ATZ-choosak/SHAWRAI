using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HavastTotalSystem : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TextMeshProUGUI total;

    public void setHavastTotal(Sprite img , int t)
    {
        icon.sprite = img;
        total.text = "X " + t.ToString();
    }
}
