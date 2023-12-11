using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInventory : MonoBehaviour
{
    public static ToolInventory Instance;

    public List<ToolAsset> toolAssets;

    [SerializeField]
    private ToolSystem toolSystem;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        foreach (ToolAsset item in toolAssets)
        {
            GameObject tool = Instantiate(toolSystem.gameObject);
            tool.GetComponent<ToolSystem>().tool = item;
            tool.transform.SetParent(transform, false);
        }
    }

   
}
