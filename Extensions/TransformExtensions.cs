using System.Collections.Generic;
using UnityEngine;

namespace Fer.Tools
{
    public static class TransformExtensions
    {
        public static List<Transform> childrenList = new List<Transform>();

        /// <summary>
        /// Retrieves all the children of a given Transform.
        /// </summary>
        /// <remarks>
        /// This method can be used with LINQ to perform operations on all child Transforms. For example,
        /// you could use it to find all children with a specific tag, to disable all children, etc.
        /// Transform implements IEnumerable and the GetEnumerator method which returns an IEnumerator of all its children.
        /// </remarks>
        /// <param name="parent">The Transform to retrieve children from.</param>
        /// <returns>An IEnumerable&lt;Transform&gt; containing all the child Transforms of the parent.</returns>    
        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                yield return child;
            }
        }

        /// <summary>
        /// Resets transform's position, scale and rotation
        /// </summary>
        /// <param name="transform">Transform to use</param>
        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void ForEveryChild(this Transform parent, System.Action<Transform> action)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                action(parent.GetChild(i));
            }
        }
        
        public static void GetChildrenRecursively(Transform current)
        {
            childrenList.Clear();
            GetChildrenRecursivelyInternal(current);
        }

        private static void GetChildrenRecursivelyInternal(Transform current)
        {
            childrenList.Add(current);
            int childCount = current.childCount;
            for (int i = 0; i < childCount; i++)
            {
                GetChildrenRecursivelyInternal(current.GetChild(i));
            }
        }

        public static T[] GetComponentsInChildrenRecursively<T>(this GameObject gameObject) where T : Component
        {
            GetChildrenRecursively(gameObject.transform);
            List<T> components = new List<T>();
            for (int i = 0; i < childrenList.Count; i++)
            {
                T component = childrenList[i].GetComponent<T>();
                if(component != null)
                {
                    components.Add(component);
                }
            }
            return components.ToArray();
        }

    }
}