using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public class Misc
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetCaptionOfActiveWindow()
        {
            var strTitle = string.Empty;
            var handle = GetForegroundWindow();
            // Obtain the length of the text
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }
        public static void ValidateAndLaunch(string url)
        {
            var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(url))
            {
                string matchedUrl = m.Value;
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    matchedUrl = "http://" + matchedUrl;
                }
                if (Uri.IsWellFormedUriString(matchedUrl, UriKind.Absolute))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(matchedUrl) { UseShellExecute = true });
                }
            }
        }
    }
}