using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedSystem : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI time;

    [SerializeField]
    private BaseSystem system;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    private ToolAsset seed;

    bool onceTiming = false;

    public bool glowing;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        updateSprite();
    }

    void updateSprite()
    {
        if (seed != null)
        {
            if (system.IsPlant)
            {
                if (system.IsWater && system.Ispreuan)
                {
                    if (!onceTiming && !system.IsHavest)
                    {
                        StartCoroutine(TimingToGlow());
                        glowing = true;
                        onceTiming = true;
                    }
                }
                else
                {
                    if (!system.IsHavest)
                    {
                        spriteRenderer.sprite = seed.drySeed;
                    }
                }
            }
        }
    }

    [SerializeField]
    private Slider timeLoad;

    IEnumerator TimingToGlow()
    {
        float t = 0;

        timeLoad.gameObject.SetActive(true);

        while (t < seed.TimeToGlow)
        {
            time.text = (Mathf.Round(seed.TimeToGlow - t)).ToString() + "s";
            timeLoad.value = t / seed.TimeToGlow;
            int index = (int)((t / seed.TimeToGlow) * (seed.seedState.Length - 1));
            spriteRenderer.sprite = seed.seedState[index];
            t += 0.1f;
            yield return new WaitForSeconds(0.1f);
            
        }

        spriteRenderer.sprite = seed.seedState[seed.seedState.Length - 1];

        timeLoad.gameObject.SetActive(false);
        system.IsHavest = true;
        onceTiming = false;
        glowing = false;
        time.text = "";

    }

    public void setSeed(ToolAsset s)
    {
        if (!system.IsHavest && !glowing)
        {
            seed = s;
        }
        
    }

    public void resetPlace()
    {
        TotalSystem.Instance.addTotal(seed);
        seed = null;
        spriteRenderer.sprite = null;
    }
}
