using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GripLockStatusRenderer : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<bool> _isGripLocked;
    [SerializeField] Color _lockedColor;
    [SerializeField] Color _unlockedColor;
    [SerializeField] Text _text;

    // Update is called once per frame
    void Update()
    {
        if (_isGripLocked.Value == true)
        {
            _text.text = "GRIP LOCKED";
            _text.color = _lockedColor;
        }
        else
        {
            _text.text = "grip unlocked";
            _text.color = _unlockedColor;
        }
    }
}
