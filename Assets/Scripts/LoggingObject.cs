using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoggingObject : ScriptableObject
{
    public static LoggingObject instance;

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }

    public void Log(string log)
    {
        FileStream file;
        BinaryFormatter bF = new BinaryFormatter();

        string data = "";
        if (File.Exists(Application.persistentDataPath + "/log.txt"))
        {
            file = File.Open(Application.persistentDataPath + "/log.txt", FileMode.Open);
            data = (string)bF.Deserialize(file);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/log.txt");
        }

        data += log;

        bF.Serialize(file, data);
        file.Close();
    }
}
