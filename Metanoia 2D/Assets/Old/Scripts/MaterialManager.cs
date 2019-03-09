using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public static MaterialManager instance;

    [SerializeField]
    private Material GrayScale0, GrayScale25, GrayScale50, GrayScale75, GrayScale100;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public Material GetGrayScale0()
    {
        return GrayScale0;
    }

    public Material GetGrayScale25()
    {
        return GrayScale25;
    }

    public Material GetGrayScale50()
    {
        return GrayScale50;
    }

    public Material GetGrayScale75()
    {
        return GrayScale75;
    }

    public Material GetGrayScale100()
    {
        return GrayScale100;
    }
}
