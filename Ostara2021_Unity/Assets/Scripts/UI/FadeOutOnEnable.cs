using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutOnEnable : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Color _start;
    [SerializeField] Color _end;
    [SerializeField] float _fadeTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("Fade");
    }

    void OnDisable()
    {
        StopCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        var elsaped = 0f;

        _image.color = _start;

        while (elsaped < _fadeTime)
        {
            _image.color = Color.Lerp(_start, _end, elsaped / _fadeTime);
            yield return null;
            elsaped += Time.deltaTime;
        }

        _image.color = _end;
    }
}
