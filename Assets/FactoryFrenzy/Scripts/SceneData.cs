using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Vector3Ser
{
    public float x, y, z;
    private Vector3 position;

    public Vector3Ser(Vector3 position)
    {
        this.position = position;
    }
}
[System.Serializable]
public class QuaternionSer
{
    public float x, y, z, w;
    private Quaternion rotation;

    public QuaternionSer(Quaternion rotation)
    {
        this.rotation = rotation;
    }
}

[System.Serializable]
public class LevelObject
{
    public Vector3Ser position;
    public QuaternionSer rotation;
    public string typeObject;
}


[System.Serializable]
public class SceneData 
{
    public List<LevelObject> Level;
    public SceneData()
    {
        Level = new List<LevelObject>();
    }
}




