using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Chargez les donn�es de la sc�ne
        LoadSceneData();
        
    }

    // Update is called once per frame
    void Update()
    {
        SaveSceneData();
    }

    public SceneData levelToSave; // Une instance de votre classe SceneData

    public void SaveSceneData()
    {
        // Sauvegardez les donn�es actuelles
        levelToSave = new SceneData();
        LevelObjectType[] levelObjectToSave = transform.root.GetComponentsInChildren<LevelObjectType>();

        foreach (var item in levelObjectToSave)
        {
            SaveLevelObjectType(item);

        }

        string json = JsonUtility.ToJson(levelToSave);
        System.IO.File.WriteAllText("sceneData.json", json);
    }

    public void LoadSceneData()
    {
        if (System.IO.File.Exists("sceneData.json"))
        {
            string json = System.IO.File.ReadAllText("sceneData.json");
            levelToSave = JsonUtility.FromJson<SceneData>(json);
        }
        else
        {
            Debug.LogWarning("Le fichier de donn�es de sc�ne n'existe pas. Les donn�es de la sc�ne seront initialis�es � leurs valeurs par d�faut.");
            levelToSave = new SceneData();
            levelToSave.Level = new List<LevelObject>(); // Initialisation de la liste Level
            // Initialisez vos donn�es de sc�ne avec des valeurs par d�faut
        }

    }

    public void SaveLevelObjectType(LevelObjectType levelObject)
    {
        // Instancier un LevelObject
        LevelObject newLevelObject = new LevelObject();

        // Recopier les donn�es de chaque plateforme dans ce level Object
        newLevelObject.position = new Vector3Ser(levelObject.transform.position);
        newLevelObject.rotation = new QuaternionSer(levelObject.transform.rotation);
        newLevelObject.typeObject = levelObject.TypeObject;

        // Ajouter dans la liste levelToSave.Level
        levelToSave.Level.Add(newLevelObject);
    }

}
