using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample.TestHelpers
{
    public class FileIO
    {
        public List<string[]> ParseFile(string filePath, char delimiter)
        {
            List<string[]> data = new List<string[]>();
            StreamReader sr;

            if (!File.Exists(filePath))
                return null;

            sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                data.Add(sr.ReadLine().Trim().Split(delimiter));
            }
            sr.Dispose();
            return data;
        }

    }
}
