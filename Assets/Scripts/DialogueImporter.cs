using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueImporter : MonoBehaviour
{
    private class File
    {
        private static string realFile;
        public static void SetRealFile(string file)
        {
            realFile = file;
        }
        public static string[] ReadAllLines(string ignoreThis)
        {
            return System.IO.File.ReadAllLines(realFile);
        }
    }

    private class Console
    {
        private static List<string> sentences = new List<string>();
        public static void WriteLine(string line)
        {
            sentences.Add(line.Substring(1));
        }
        public static string[] GetStuff()
        {
            return sentences.ToArray();
        }
    }
    public static string[] ReadFile(string file)
    {
        File.SetRealFile(file);
        // The following 3 lines are from https://stackoverflow.com/questions/4220993/c-sharp-how-to-convert-file-readlines-into-string-array
        // I had to use them because of The Hierophant card
        // Don't hate me, future me
        var lines = File.ReadAllLines("c:\\file.txt");
        foreach (var line in lines) {
            Console.WriteLine("\t" + line);
        }

        return Console.GetStuff();
    }
}
