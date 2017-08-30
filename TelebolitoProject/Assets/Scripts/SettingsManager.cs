using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SettingsManager {

    private static bool wereDataLoaded = false;
    private static string settingsFileName = "Settings.txt";

    private static int maxScore = 0;

    #region Getters and Setters

    public static bool WereDataLoaded
    {
        get
        {
            return wereDataLoaded;
        }

        set
        {
            wereDataLoaded = value;
        }
    }

    public static int MaxScore
    {
        get
        {
            return maxScore;
        }

        set
        {
            maxScore = value;
        }
    }

    #endregion

    public static void loadSettingsFromFile()
    {
        if (File.Exists(Application.persistentDataPath + "/" + settingsFileName))
        {
            wereDataLoaded = true;
            StreamReader sr = new StreamReader(settingsFileName);
            string bestScore = sr.ReadLine();
            try
            {
                maxScore = int.Parse(bestScore);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            sr.Close();
        }
        else
        {
            saveMaxScore(maxScore.ToString());
        }
    }

    public static void saveMaxScore(string score)
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath+"/"+settingsFileName, false);
        sw.WriteLine(score);
        sw.Close();
    }
}
