using System;
using TMPro;
using UnityEngine;

namespace Fer.Tools
{
    public class FNameToText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void OnValidate()
        {
            UpdateNameToText();
        }

        private void UpdateNameToText()
        {
            _text = GetComponent<TextMeshProUGUI>();
            // This method takes the gameobject name and updates the text with it
            if (_text != null)
            {
                _text.text = gameObject.name;
            }
        }
    }
}