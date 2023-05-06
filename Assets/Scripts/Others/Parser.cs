using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class Parser : MonoBehaviour
{
    private string inputFilePathRelativeToAssets = "Scripts/Putin.cs";
    private string outputFilePathRelativeToAssets = "Scripts/Output.txt";

    void Start()
    {
        string inputAbsoluteFilePath = Path.Combine(Application.dataPath, inputFilePathRelativeToAssets);
        List<string> quotes = ParseQuotesFromFile(inputAbsoluteFilePath);

        Debug.Log("Сообщения в кавычках:");
        foreach (string quote in quotes)
        {
            Debug.Log(quote);
        }

        string outputAbsoluteFilePath = Path.Combine(Application.dataPath, outputFilePathRelativeToAssets);
        WriteQuotesToFile(quotes, outputAbsoluteFilePath);
    }

    public static List<string> ParseQuotesFromFile(string filePath)
    {
        List<string> quotes = new List<string>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> quotesInLine = ExtractQuotesFromLine(line);
                    quotes.AddRange(quotesInLine);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Не удалось прочитать файл: " + e.Message);
        }

        return quotes;
    }

    public static List<string> ExtractQuotesFromLine(string line)
    {
        List<string> quotes = new List<string>();

        // Используйте регулярное выражение для поиска текста в кавычках
        Regex regex = new Regex("\"([^\"]*)\"");
        MatchCollection matches = regex.Matches(line);

        foreach (Match match in matches)
        {
            quotes.Add(match.Groups[1].Value);
        }

        return quotes;
    }

    public static void WriteQuotesToFile(List<string> quotes, string filePath)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (string quote in quotes)
                {
                    sw.WriteLine(quote);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Не удалось записать файл: " + e.Message);
        }
    }
}
