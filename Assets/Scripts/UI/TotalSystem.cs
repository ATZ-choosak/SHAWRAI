using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalSystem : MonoBehaviour
{
    public static TotalSystem Instance;

    public int Money;

    [SerializeField]
    private TextMeshProUGUI money;

    [SerializeField]
    private List<ToolAsset> totalItem;

    [SerializeField]
    private int sellPrice;

    [SerializeField]
    private Transform contentTotal;

    [SerializeField]
    private GameObject havastPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        reCalTotal();
    }

    void reCalTotal()
    {
        foreach (var item in ToolInventory.Instance.toolAssets)
        {
            if (item.tool_type == ToolAsset.toolType.seed)
            {
                GameObject h = Instantiate(havastPrefab);
                h.GetComponent<HavastTotalSystem>().setHavastTotal(item.toolSprite, totalItem.FindAll(i => i.toolName == item.toolName).Count);
                h.transform.SetParent(contentTotal , false);
            }
        }
    }

    public void addTotal(ToolAsset item)
    {
        totalItem.Add(item);
        calculateTotal();
    }

    private void Update()
    {
        money.text = Money.ToString("#,#");
    }

    void calculateTotal()
    {
        sellPrice = 0;

        foreach (Transform item in contentTotal)
        {
            Destroy(item.gameObject);
        }

        reCalTotal();

        foreach (var item in ToolInventory.Instance.toolAssets)
        {
            if (item.tool_type == ToolAsset.toolType.seed)
            {
                sellPrice += totalItem.FindAll(i => i.toolName == item.toolName).Count * item.sellPrice;
            }
        }
    }

    public void Sell()
    {
        Money += sellPrice;
        totalItem.Clear();
        sellPrice = 0;
        calculateTotal();
    }

    public void addMoney(int m)
    {
        Money += m;
    }

}
