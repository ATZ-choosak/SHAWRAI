using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSystem : MonoBehaviour
{
    public static UiSystem instance;

    [SerializeField]
    private RectTransform selected;

    private void Awake()
    {
        instance = this;
    }

    public void setPosSelected(RectTransform pos)
    {
        selected.position = pos.position;
    }



}
