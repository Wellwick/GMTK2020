using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueImporter : MonoBehaviour
{
    // File class to override the real File from System, thanks a lot Carl.
    private class File
    {
        private static string realFile;

        // So we can ignore the file passed into ReadAllLines
        public static void SetRealFile(string file)
        {
            realFile = file;
        }

        // Doesn't read from the file passed in. Instead it reads from a file, 
        // that is specified in SetRealFile(string file)
        public static string[] ReadAllLines(string ignoreThis)
        {
            return System.IO.File.ReadAllLines(realFile);
        }
    }

    // Console class overrides the real one. Again.
    // Wow, thanks Carl.
    private class Console
    {
        private static List<string> sentences = new List<string>();

        // Doesn't actually write a line, actually puts most of the passed in 
        // string into the List<string> sentences
        public static void WriteLine(string line)
        {
            sentences.Add(line.Substring(1));
        }

        // Returns the sentences in an array
        public static string[] GetStuff()
        {
            return sentences.ToArray();
        }
    }

    // Read's a file in a way that doesn't work with web, so we can't use it.
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
