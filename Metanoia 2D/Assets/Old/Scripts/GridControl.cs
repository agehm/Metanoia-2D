using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridControl : MonoBehaviour {

    [SerializeField]
    private Text _buttonText;
    [SerializeField]
    private GameObject _GridImage;
    private bool _spriteEnabled;

    public void ShowHideGrid()
    {
        if (_spriteEnabled)
        {
            _spriteEnabled = false;
            _buttonText.text = "Mostrar Grid 100x100px";
        }
        else
        {
            _spriteEnabled = true;
            _buttonText.text = "Ocultar Grid 100x100px";
        }

        _GridImage.GetComponent<Image>().enabled = _spriteEnabled;
    }
}
