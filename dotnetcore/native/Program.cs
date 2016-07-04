using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    public class Program
    {
        [DllImport("libgtk-x11-2.0.so.0")]
        private static extern void gtk_init (ref int argc, ref IntPtr argv);
        [DllImport("libgtk-x11-2.0.so.0")]
        static extern IntPtr gtk_message_dialog_new(IntPtr parent_window, DialogFlags flags, MessageType type, ButtonsType bt, string msg, IntPtr args);
        [DllImport("libgtk-x11-2.0.so.0")]
        static extern int gtk_dialog_run(IntPtr raw);
        [DllImport("libgtk-x11-2.0.so.0")]
        static extern void gtk_widget_destroy(IntPtr widget);
        [Flags]
        public enum DialogFlags 
        {
            Modal = 1 << 0,
            DestroyWithParent = 1 << 1,
        }

        public enum MessageType
        {
            Info,
            Warning,
            Question,
            Error,
            Other,
        }
        
        public enum ButtonsType
        {
            None,
            Ok,
            Close,
            Cancel,
            YesNo,
            OkCancel,
        }

        public static void Main(string[] args)
        {
            var argc = 0;
            var argv = IntPtr.Zero;
            gtk_init(ref argc, ref argv);
            var diag = gtk_message_dialog_new(IntPtr.Zero, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Hello from .NET Core on Linux!", IntPtr.Zero);
            var res = gtk_dialog_run(diag);
            gtk_widget_destroy(diag);
            Console.WriteLine(res);
        }
    }
}
