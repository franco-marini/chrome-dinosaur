using UnityEngine;
using System;

public class Utils
{
  static public GameObject GetPrefabResource(string prefab)
  {
    string[] prefabs = { "Spawner", "Enemy" };
    string exists = Array.Find(prefabs, ele => ele == prefab);
    if (exists != null)
    {
      return Resources.Load<GameObject>("Prefabs/" + prefab);
    }
    else
    {
      return null;
    }
  }

  static public float GetFloatWith1Decimal(float value)
  {
    return Mathf.Round(value * 10.0f) * 0.1f;
  }

  static public float GetFloatWith2Decimal(float value)
  {
    return Mathf.Round(value * 100f) / 100f;
  }
}
