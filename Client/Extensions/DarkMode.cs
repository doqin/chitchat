using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Extensions
{
    internal class DarkMode
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public static void EnableDarkTitleBar(Form form)
        {
            var useDarkMode = 1;
            DwmSetWindowAttribute(form.Handle, 20, ref useDarkMode, sizeof(int)); // 20 = DWMWA_USE_IMMERSIVE_DARK_MODE
        }
    }
}
