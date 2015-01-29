﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ntreev.Library.Psd
{
    public class PathResolver : PsdResolver
    {
        private readonly string directory;

        public PathResolver(string directory)
        {
            this.directory = directory;
        }

        public override PsdDocument GetDocument(string path)
        {
            Uri uri = new Uri(path, UriKind.RelativeOrAbsolute);

            string filename = string.Empty;
            if (uri.IsAbsoluteUri == true)
            {
                filename = uri.LocalPath;
            }
            else
            {
                filename = System.IO.Path.Combine(this.directory, path);
                if (File.Exists(filename) == false)
                    throw new FileNotFoundException(string.Format("{0} 을(를) 찾을 수 없습니다.", filename), filename);
            }

            PsdDocument document = new PsdDocument();
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                document.Read(stream, new PathResolver(Path.GetDirectoryName(filename)));
            }
            
            return document;
        }
    }
}
