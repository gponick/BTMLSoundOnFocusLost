﻿using System;
using System.IO;

namespace BTMLSoundOnFocusLost
{
    public class Logger
    {
        public static void LogError(Exception ex)
        {
            var filePath = $"{BTMLSoundOnFocusLost.ModDirectory}/BTMLSoundOnFocusLost.log";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Message: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                WriteLogFooter(writer);
            }
        }

        public static void LogLine(String line)
        {
            var filePath = $"{BTMLSoundOnFocusLost.ModDirectory}/BTMLSoundOnFocusLost.log";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
                WriteLogFooter(writer);
            }
        }

        private static void WriteLogFooter(StreamWriter writer)
        {
            writer.WriteLine($"Date: {DateTime.Now}");
            writer.WriteLine();
            writer.WriteLine(new string(c: '-', count: 50));
            writer.WriteLine();
        }
    }
}