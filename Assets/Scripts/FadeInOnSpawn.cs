using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOnSpawn : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private Color _color;
    [SerializeField] private float _fadeTime = 0.01f;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _color = _renderer.material.color;
        _color.a = 0f;
        _renderer.material.color = _color;
    }

    void Start()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1; f += 0.05f)
        {
            _color.a = f;
            _renderer.material.color = _color;
            yield return new WaitForSeconds (_fadeTime);
        }
    }
}
