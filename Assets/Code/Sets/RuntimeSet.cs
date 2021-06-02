// ----------------------------------------------------------------------------
// Runtime Set with Scriptable Objects
// 
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace AngryBirds
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        // Item List of type T which are contained in the Set
        public List<T> Items = new List<T>();

        public void Add(T obj)
        {
            // Add an object to the Item list of type T
            if (!Items.Contains(obj))
                Items.Add(obj);
        }

        public void Remove(T obj)
        {
            // Remove an object from the Item list of type T
            if (Items.Contains(obj))
                Items.Remove(obj);
        }
    }
}