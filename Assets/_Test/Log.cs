// Contain declaration for Conditional attribute
using System;
using System.Diagnostics;
using UnityEngine;

// Prevent Type conflict with System.Diagnostics.Log
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace Ultility
{
    /// <summary>
    /// Debug log (only run on Editor)
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Use this to turn log ON/OFF.
        /// Default is ON.
        /// </summary>
        /// <param name="message"></param>
        public static void EnableLog(bool enabledLog = true)
        {
            Debug.unityLogger.logEnabled = enabledLog;
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoGreen(object message, Object context = null)
        {
            Debug.Log($"<color=green> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoRed(object message, Object context = null)
        {
            Debug.Log($"<color=red> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoYellow(object message, Object context = null)
        {
            Debug.Log($"<color=yellow> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoOrange(object message, Object context = null)
        {
            Debug.Log($"<color=orange> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoCyan(object message, Object context = null)
        {
            Debug.Log($"<color=cyan> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void Info(object message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        [Conditional("USE_CHEAT")]
        public static void InfoFormat(object message, params object[] args)
        {
            Debug.LogFormat("InfoFormat: " + message, args);
        }

        [Conditional("USE_CHEAT")]
        public static void Warning(object message)
        {
            Debug.LogWarning("Warning : " + message);
        }

        [Conditional("USE_CHEAT")]
        public static void Warning(object message, Object context)
        {
            Debug.LogWarning("Warning : " + message, context);
        }

        [Conditional("USE_CHEAT")]
        public static void Error(object message)
        {
            Debug.LogError("Error : " + message);
        }

        [Conditional("USE_CHEAT")]
        public static void Error(object message, Object context)
        {
            Debug.LogError("Error : " + message, context);
        }


        [Conditional("DEBUG")]
        public static void Warning(bool condition, object message)
        {
            if (!condition) Debug.LogWarning(message);
        }

        [Conditional("DEBUG")]
        public static void Warning(bool condition, object message, Object context)
        {
            if (!condition) Debug.LogWarning(message, context);
        }

        [Conditional("DEBUG")]
        public static void Warning(bool condition, Object context, string format, params object[] args)
        {
            if (!condition) Debug.LogWarning(string.Format(format, args), context);
        }

        //---------------------------------------------
        //------------- Assert ------------------------

        /// Thown an exception if condition = false
        [Conditional("ASSERT")]
        public static void Assert(bool condition)
        {
            if (!condition) throw new UnityException();
        }

        /// Thown an exception if condition = false, show message on console's log
        [Conditional("ASSERT")]
        public static void Assert(bool condition, string message)
        {
            if (!condition) throw new UnityException(message);
        }

        /// Thown an exception if condition = false, show message on console's log
        [Conditional("ASSERT")]
        public static void Assert(bool condition, string format, params object[] args)
        {
            if (!condition) throw new UnityException(string.Format(format, args));
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfoGreen(object message, Object context = null)
        {
            Debug.Log($"<color=green> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfoRed(object message, Object context = null)
        {
            Debug.Log($"<color=red> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfoYellow(object message, Object context = null)
        {
            Debug.Log($"<color=yellow> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfoOrange(object message, Object context = null)
        {
            Debug.Log($"<color=orange> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfoCyan(object message, Object context = null)
        {
            Debug.Log($"<color=cyan> {message} </color>", context);
        }

        /// <summary>
        /// Default debug message
        /// </summary>
        /// <param name="message"></param>
        public static void EditorInfo(object message)
        {
            Debug.Log(message);
        }

        public static void EditorError(object message)
        {
            Debug.LogError("Error : " + message);
        }
    }
}