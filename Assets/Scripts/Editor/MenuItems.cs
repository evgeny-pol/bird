using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuItems
{
    [MenuItem("My Tools/Sort Root Game Objects")]
    private static void SortRootGameObjects()
    {
        Sort(SceneManager.GetActiveScene().GetRootGameObjects());
    }

    [MenuItem("My Tools/Sort Child Game Objects")]
    private static void SortChildObjects()
    {
        Sort(Selection.activeGameObject.transform.Cast<Transform>().Select(t => t.gameObject));
    }

    private static void Sort(IEnumerable<GameObject> gameObjects)
    {
        int newIndex = 0;

        foreach (GameObject go in gameObjects.OrderBy(go => go.name))
        {
            if (newIndex != go.transform.GetSiblingIndex())
                go.transform.SetSiblingIndex(newIndex);

            newIndex++;
        }
    }
}
