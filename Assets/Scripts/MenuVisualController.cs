using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuVisualController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private RawImage _baseImageMaterial;
    [SerializeField] private RawImage _baseTexture;
    [SerializeField] private SpriteRenderer _CQCTexture;
    [SerializeField] private List<ColorPalette> _colorPalettes;
    [SerializeField] private List<Texture> _textures;

    private int _currentTextureIndex = 0;
    private int _currentColorPaletteIndex = 0;

    void Start()
    {
        _baseTexture.texture = _textures[0];

        _baseImageMaterial.material.SetColor("_Background", _colorPalettes[0].Background);
        _baseImageMaterial.material.SetColor("_Color_1", _colorPalettes[0].Color1);
        _baseImageMaterial.material.SetColor("_Color_2", _colorPalettes[0].Color2);
        _baseImageMaterial.material.SetColor("_Color_3", _colorPalettes[0].Color3);

        _CQCTexture.color = _colorPalettes[0].CQC;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTexture();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchColorPalatte();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(UI.activeSelf)
                UI.SetActive(false);
            else
                UI.SetActive(true);
        }

    }

    public void SwitchTexture()
    {
        if(_currentTextureIndex + 1 == _textures.Count)
        {
            _currentTextureIndex = 0;
        } else
        {
            _currentTextureIndex++;
        }

        _baseTexture.texture = _textures[_currentTextureIndex];
    }

    public void SwitchColorPalatte()
    {
        if (_currentColorPaletteIndex + 1 == _colorPalettes.Count)
        {
            _currentColorPaletteIndex = 0;
        }
        else
        {
            _currentColorPaletteIndex++;
        }

        _baseImageMaterial.material.SetColor("_Background", _colorPalettes[_currentColorPaletteIndex].Background);
        _baseImageMaterial.material.SetColor("_Color_1", _colorPalettes[_currentColorPaletteIndex].Color1);
        _baseImageMaterial.material.SetColor("_Color_2", _colorPalettes[_currentColorPaletteIndex].Color2);
        _baseImageMaterial.material.SetColor("_Color_3", _colorPalettes[_currentColorPaletteIndex].Color3);

        _CQCTexture.color = _colorPalettes[_currentColorPaletteIndex].CQC;
    }
}

[Serializable]
public struct ColorPalette
{
    public Color Background;
    public Color CQC;
    public Color Color1;
    public Color Color2;
    public Color Color3;
}


