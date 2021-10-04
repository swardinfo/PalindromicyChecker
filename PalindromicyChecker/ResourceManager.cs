using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PalindromicyChecker
{
    /// <summary>
    /// Manages the embedded resources for the application
    /// </summary>
    public class ResourceManager
    {
        #region Methods

        /// <summary>
        /// Returns the text from an embedded file
        /// </summary>
        /// <param name="filename">The filename of the embedded text file to read</param>
        /// <returns>The file contents as a string or an empty string if the resource isn't found</returns>
        public static string ReadMessage(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(n => n.EndsWith(filename));
            if (string.IsNullOrEmpty(resourceName))
                return string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Returns an image from an embedded file
        /// </summary>
        /// <param name="filename">The filename of the embedded image to return</param>
        /// <returns>The embedded image or null if the resource isn't found</returns>
        public static Image GetImage(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(n => n.Contains(filename));
            if (string.IsNullOrEmpty(resourceName))
                return null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                return new Bitmap(stream);
            }
        }

        /// <summary>
        /// Returns an icon from an embedded file
        /// </summary>
        /// <param name="filename">The filename of the embedded icon to return</param>
        /// <returns>The embedded icon or null if the resource isn't found</returns>
        public static Icon GetIcon(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(n => n.Contains(filename));
            if (string.IsNullOrEmpty(resourceName))
                return null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                return new Icon(stream);
            }
        }

        /// <summary>
        /// Returns a font family from an embedded file
        /// </summary>
        /// <param name="filename">The filename of the embedded font family to return</param>
        /// <returns>The embedded font family or null if the resource isn't found</returns>
        public static FontFamily GetFontFamily(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(n => n.Contains(filename));
            if (string.IsNullOrEmpty(resourceName))
                return null;
            PrivateFontCollection fonts = new();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    var length = (int)stream.Length;
                    IntPtr data = Marshal.AllocCoTaskMem(length);
                    var fontData = new byte[length];
                    stream.Read(fontData, 0, length);
                    Marshal.Copy(fontData, 0, data, length);
                    fonts.AddMemoryFont(data, length);
                    Marshal.FreeCoTaskMem(data);
                }
            }
            return fonts.Families[0];
        }

        #endregion
    }
}
