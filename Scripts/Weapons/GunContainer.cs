using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunContainer : MonoBehaviour
{
    public static readonly Gun noobSword = new Gun(.75f, 18, "Noob Sword");

    public static List<Gun> guns;
    void Start()
    {
        guns = new List<Gun>();
        guns.Add(noobSword);
        Debug.Log(guns[0]);
    }

    public static Gun GetGun(int n)
    {
        return guns[n];
    }

    public static Gun GetRandomGun()
    {
        return guns[Random.Range(0, guns.Count)];
    }

}
