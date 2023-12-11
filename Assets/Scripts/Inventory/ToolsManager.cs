using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    public static ToolsManager instance;

    public ToolAsset nowTool;

    private void Awake()
    {
        instance = this;
    }

    public void setTool(ToolAsset tool)
    {
        nowTool = tool;
    }

}
