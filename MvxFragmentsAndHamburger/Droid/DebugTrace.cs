using System;
using Android.Util;
using Cirrious.CrossCore.Platform;

namespace MvxFragmentsAndHamburger
{
    public class DebugTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            switch (level)
            {
                case MvxTraceLevel.Diagnostic:
                    Log.Debug(tag, message());
                    break;
                case MvxTraceLevel.Error:
                    Log.Error(tag, message());
                    break;
                case MvxTraceLevel.Warning:
                    Log.Warn(tag, message());
                    break;
            }
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            switch (level)
            {
                case MvxTraceLevel.Diagnostic:
                    Log.Debug(tag, message);
                    break;
                case MvxTraceLevel.Error:
                    Log.Error(tag, message);
                    break;
                case MvxTraceLevel.Warning:
                    Log.Warn(tag, message);
                    break;
            }
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            switch (level)
            {
                case MvxTraceLevel.Diagnostic:
                    Log.Debug(tag, message, args);
                    break;
                case MvxTraceLevel.Error:
                    Log.Error(tag, message, args);
                    break;
                case MvxTraceLevel.Warning:
                    Log.Warn(tag, message, args);
                    break;
            }
        }
    }
}