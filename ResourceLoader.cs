using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace GefestCapital
{
    public static class ResourceLoader
    {
        public static T LoadResourceRecursively<T>(string resourceName) where T : Object
        {
            // Load all resources of type T in Resources and its subfolders
            T[] allResources = Resources.LoadAll<T>("");

            // Find the first resource that matches the name
            T resource = allResources.FirstOrDefault(r => r.name == resourceName);

            if (resource == null)
            {
                Debug.LogError($"Resource with name {resourceName} not found!");
                return null;
            }

            return resource;
        }
    }
}

