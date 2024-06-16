using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Scripts.ScriptableVariables
{
    public class ScriptableContainer<T> : ScriptableObject
    {
        private int _currentIndex;

        public List<T> items = new();
        public T selectedItem;
        public Action onSelectionChanged;

        public void AddItem(T item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }

        public void RemoveItem(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        protected int CurrentIndex
        {
            set
            {
                _currentIndex = value;
                selectedItem = items[_currentIndex];
                onSelectionChanged?.Invoke();
            }
        }

        public void SelectNext()
        {
            CurrentIndex = (_currentIndex - 1 + items.Count) % items.Count;
        }

        public void SelectPrevious()
        {
            CurrentIndex = (_currentIndex + 1) % items.Count;
        }

        public void Select(T item)
        {
            CurrentIndex = items.IndexOf(item);
        }

        public void SelectFirst()
        {
            if (items.First() != null)
            {
                selectedItem = items.First();
            }
        }

        public int Count => items.Count;
    }
}