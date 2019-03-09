using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControl : MonoBehaviour
{
    private int grayScale;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetNewMaterial()
    {
        if (grayScale == 0)
        {
            spriteRenderer.material = MaterialManager.instance.GetGrayScale0();
        }
        else if (grayScale == 25)
        {
            spriteRenderer.material = MaterialManager.instance.GetGrayScale25();
        }
        else if (grayScale == 50)
        {
            spriteRenderer.material = MaterialManager.instance.GetGrayScale50();
        }
        else if (grayScale == 75)
        {
            spriteRenderer.material = MaterialManager.instance.GetGrayScale75();
        }
        else if (grayScale == 100)
        {
            spriteRenderer.material = MaterialManager.instance.GetGrayScale100();
        }
    }

    public void DownColorSprite()
    {
        grayScale += 25;

        if (grayScale > 100)
        {
            grayScale = 100;
            return;
        }

        SetNewMaterial();
    }

    public void UpColorSprite()
    {
        grayScale -= 25;

        if (grayScale < 0)
        {
            grayScale = 0;
            return;
        }

        SetNewMaterial();
    }
}
