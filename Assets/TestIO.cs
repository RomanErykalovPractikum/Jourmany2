using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestIO : MonoBehaviour
{
    public string relativeFilePath = "TextFiles/Quests.txt";

    void Start()
    {

        string absoluteFilePath = Path.Combine(Application.dataPath, relativeFilePath);

        // ��������� ���� � ������������ ��� � ������
        if (File.Exists(absoluteFilePath))
        {
            using (StreamReader sr = new StreamReader(absoluteFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                }
            }
        }
        else
        {
            Debug.LogError("���� �� ������: " + absoluteFilePath);
        }
    }
}
