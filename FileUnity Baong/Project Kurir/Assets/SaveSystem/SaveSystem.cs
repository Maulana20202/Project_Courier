using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSystem
{

    const string SAVES_PATH = "/saves";
    public static void save<T>(T obj, string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + SAVES_PATH;
        Directory.CreateDirectory(path);

        FileStream stream = new FileStream(path + key, FileMode.Create);

        formatter.Serialize(stream, obj);
        stream.Close();
    }

    public static T Load<T>(string key){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + SAVES_PATH;

        T Data = default;

        if(File.Exists(path + key)){

             FileStream stream = new FileStream(path + key, FileMode.Open);

            Data = (T)formatter.Deserialize(stream);
            stream.Close();

        } else {
            Debug.LogError("Save Not Found In" + path + key);
        }

        return Data;
    }

    public static bool SaveExist(string key){

        string path = Application.persistentDataPath + SAVES_PATH;

        return File.Exists(path + key);
    }
}
