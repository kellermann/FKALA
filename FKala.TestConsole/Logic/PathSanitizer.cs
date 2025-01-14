﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FKala.TestConsole.Logic
{
    public class PathSanitizer
    {
        static Dictionary<string, string> sanitizedCache = new Dictionary<string, string>();
        public static string SanitizePath(string path)
        {
            if (!sanitizedCache.ContainsKey(path))
            {

                if (path == null) throw new ArgumentNullException(nameof(path));

                var invalidChars = Path.GetInvalidFileNameChars();
                var sanitizedPath = new StringBuilder(path.Length);

                foreach (var ch in path)
                {
                    if (Array.Exists(invalidChars, invalidChar => invalidChar == ch))
                    {
                        sanitizedPath.Append('$');
                    }
                    else
                    {
                        sanitizedPath.Append(ch);
                    }
                }

                sanitizedCache.Add(path, sanitizedPath.ToString());
            }
            return sanitizedCache[path];
        }
    }
}
