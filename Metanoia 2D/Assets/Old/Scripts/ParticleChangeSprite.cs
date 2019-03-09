using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.ParticleSystem;

public class ParticleChangeSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite Default, Alternative;

    //private ParticleSystem.TextureSheetAnimationModule textureAnimation;
    private ParticleSystem particleSystem;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            particleSystem.textureSheetAnimation.SetSprite(0, Alternative);
            //textureAnimation.SetSprite(0, Alternative);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            particleSystem.textureSheetAnimation.SetSprite(0, Default);
            //textureAnimation.SetSprite(0, Default);
        }
    }
}
