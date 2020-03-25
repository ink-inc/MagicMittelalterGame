using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Dieses Skript ist für das Logging verantwortlich
 */

public enum Spezialcode { Strich }

public class Logger : MonoBehaviour
{
    public static Logger instance;
    private string logtext;

    [Tooltip("%dataPath% for application path")]
    public string path = "%dataPath%/AutoLog.txt"; //The log file will be saved here

    [Tooltip("Write log file after every log() method call")]
    public bool instantWrite = false; //Write log file after every log() method call?

    [Tooltip("Write log text to console?")]
    public bool writeToConsole = false; //Write log text to console?

    [Tooltip("Entries with a value greater or equal to this will be printed to console, if activated")]
    public int consolePriority = 1; //Entries with a value greater or equal to this will be printed to console, if activated

    public bool active = true;
    public bool dontDestroyOnLoad = true;

    [Tooltip("Automatically write to log file every X seconds (0 = no automated writing)")]
    public float autoLogWrite = 5; //Automatisch Logdatei schreiben, 0 = nicht automatisch

    private void Awake()
    {
        path = path.Replace("%dataPath%", Application.dataPath);
        if (instance != null)
        {
            Logger.log("Console instance found on '" + instance.gameObject.name + "', removing this instance (" + this.gameObject.name + ")");
            Destroy(this);
        }
        else
        {
            instance = this; //Set static instance
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(instance);
            }
            log("Logging started on path: " + path, this.gameObject, 1000);
            Debug.Log("Logger started");
        }
        StartCoroutine(autoLogger());
    }

    private IEnumerator autoLogger()
    {
        while (true)
        {
            if (autoLogWrite == 0)
            {
                yield return new WaitForSeconds(10);
            }
            else
            {
                yield return new WaitForSeconds(autoLogWrite);
                writeLog(false, false, true);
            }
        }
    }

    public static void clear()
    {
        Debug.ClearDeveloperConsole();
        Logger.log("Console cleared.", "Logger", 0);
    }

    public static void debug(string text, int prioritaet)
    {
        if (instance.writeToConsole && prioritaet >= Logger.instance.consolePriority)
        {
            if (text.StartsWith("%") && text.EndsWith("%"))
                return;
            Debug.Log(text);
        }
    }

    public static void log(string text)
    {
        log(text, "General", 0);
    }

    public static void log(string text, int prioritaet)
    {
        log(text, "General", prioritaet);
    }

    public static void log(Spezialcode code)
    {
        bool wtc = instance.writeToConsole;
        instance.writeToConsole = false;
        if (code == Spezialcode.Strich)
        {
            log("%STRICH%", 0);
        }
        instance.writeToConsole = wtc;
    }

    public static void log(string text, GameObject sender)
    {
        log(text, sender, 0);
    }

    public static void log(string text, GameObject sender, int prioritaet)
    {
        log(text, sender.name, prioritaet);
    }

    public static void log(string text, string sender)
    {
        log(text, sender, 0);
    }

    public static void log(string text, string sender, int prioritaet)
    {
        if (instance == null || !instance.active)
            return;
        if (instance.writeToConsole)
            debug(text, prioritaet);
        text = "[" + System.DateTime.Now.ToString("HH:mm:ss.fff") + "][" + prioritaet + "] " + sender + ": " + text; //Add Timestamp and Format (name of sender object)
        if (text.Contains("%STRICH%"))
        {
            text = "";
            for (int i = 0; i < 100; i++)
            {
                text += "-";
            }
        }
        instance.logtext += text + "\n";
        if (instance.instantWrite)
            writeLog(false, false, true); //Write log
    }

    public void OnGUI()
    {
        if (!Debug.isDebugBuild)
            return;
        if (GUI.Button(new Rect(100 - 90, 10, 250, 30), "Logdatei schreiben"))
        {
            Debug.LogWarning("Logtaste!");
            log("Logtaste gedrückt...", instance.gameObject);
            writeLog(false, true, false);
            Debug.Log("Log geschrieben!");
        }
    }

    public static void writeLog()
    {
        writeLog(false, false, false);
    }

    public static void writeLog(bool reset, bool openFile, bool silent)
    {
        if (!silent)
            log("Logdatei geschrieben [" + instance.path + "]", instance.gameObject);
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(instance.path))
        {
            sw.Write(instance.logtext);
        }
        if (reset) //Reset the log text
        {
            instance.logtext = "";
            if (!silent)
                log("Log geschrieben und zurückgesetzt [" + instance.path + "]", instance.gameObject);
        }
        if (openFile) //Open log file
        {
            System.Diagnostics.Process.Start(instance.path);
        }
    }

    public static void writeLog(bool reset, bool openFile, bool silent, string path)
    {
        string oldPath = instance.path;
        instance.path = path;
        writeLog(reset, openFile, silent);
        instance.path = oldPath;
    }
}