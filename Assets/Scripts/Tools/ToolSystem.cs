using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToolSystem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI amount;

    [SerializeField]
    private Sprite SlotClick, SlotUnClick;

    [SerializeField]
    private Image bg, icon;

    public ToolAsset tool;


    void Start()
    {
        transform.name = tool.name;
        icon.sprite = tool.toolSprite;
    }

    private void Update()
    {
        if (tool && (tool.tool_type == ToolAsset.toolType.seed || tool.tool_type == ToolAsset.toolType.bone))
        {
            amount.text = tool.Amount.ToString();
        }

        bg.sprite = ToolsManager.instance.nowTool == tool ? SlotClick : SlotUnClick;

        
    }

    public void SelecTool()
    {
        //Set pos of Selected UI
        //UiSystem.instance.setPosSelected(GetComponent<RectTransform>());

        //set global tools
        ToolsManager.instance.setTool(tool);
    }

}
