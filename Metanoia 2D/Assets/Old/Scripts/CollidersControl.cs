using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollidersControl : MonoBehaviour
{
    [SerializeField]
    private Text _buttonText;
    private bool _spriteEnabled;

    void Start()
    {
        //_spriteEnabled = true;

    }

    public void ShowHideColliders()
    {
        //byte newAlpha = 0;

        if (_spriteEnabled)
        {
            _spriteEnabled = false;
            _buttonText.text = "Mostrar Colisores";
        }
        else
        {
            _spriteEnabled = true;
            _buttonText.text = "Ocultar Colisores";
        }

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject platform in platforms)
        {
            //platform.GetComponent<SpriteRenderer>().color = new Color32(111, 243, 127, newAlpha);
            platform.GetComponent<SpriteRenderer>().enabled = _spriteEnabled;
        }

    }
}
