﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace TagsCloudVisualization
{
    public class BitmapSaver
    {
        private Bitmap ImageBitmap { get; }

        public BitmapSaver(Bitmap imageBitmap)
        {
            ImageBitmap = imageBitmap;
        }

        public void SaveBitmapToDirectory(string savePath)
        {
            if (!PathInRightFormat(savePath))
            {
                throw new ArgumentException("wrong path format");
            }

            using (ImageBitmap)
            {
                ImageBitmap.Save(savePath, ImageFormat.Jpeg);
            }
        }

        private static bool PathInRightFormat(string path)
        {
            var pattern = @"((?:[^\\]*\\)*)(.*[.].+)";
            var match = Regex.Match(path, pattern);
            var directoryPath = match.Groups[1].ToString();

            return Directory.Exists(directoryPath) && match.Groups[2].Success;
        }
    }
}