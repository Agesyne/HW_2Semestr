﻿using System;
using System.Collections.Generic;
using System.IO;

namespace EventLoopGame
{
    /// <summary>
    /// Read file class
    /// </summary>
    public static class ReadFileMap
    {
        /// <summary>
        /// Read map from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>The map</returns>
        public static string[] ReadMap(string fileName)
        {
            StreamReader fileReader = null;
            string[] arrayMap = null;
            try
            {
                fileReader = new StreamReader(fileName);
                var listMap = new List<string>();
                
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    listMap.Add(line);
                    line = fileReader.ReadLine();
                }

                arrayMap = new string[listMap.Count];
                listMap.CopyTo(arrayMap);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fileReader.Close();
            }

            return arrayMap;
        }
    }
}
