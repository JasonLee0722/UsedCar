using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 日志类型
/// </summary>
public enum EnumLogType
{
    /// <summary>
    /// 业务日志
    /// </summary>
    Business = 1,
    /// <summary>
    /// 服务状态
    /// </summary>
    ServiceState,
    /// <summary>
    /// 系统错误
    /// </summary>
    SysErr
}

/// <summary>
/// 日志记录
/// </summary>
public class Logger
{
    private static readonly object locker = new object();

    /// <summary>
    /// 记录日志
    /// </summary>
    /// <param name="Msg"></param>
    /// <param name="InfoSource"></param>
    /// <param name="LogType"></param>
    /// <returns></returns>
    public static bool LogWriter(string Msg, string InfoSource, EnumLogType LogType = EnumLogType.Business)
    {
        try
        {
            string logpath = GetLogPath(LogType);

            InfoSource = "信息来源：" + InfoSource;
            string LogTime = "发生时间：" + DateTime.Now.ToString();
            string LogInfo = "日志信息：" + Msg;
            lock (locker)
            {
                StringBuilder sblogMsg = new StringBuilder();

                sblogMsg.Append(string.Format("{0}\r\n", InfoSource));
                sblogMsg.Append(string.Format("{0}\r\n", LogTime));
                sblogMsg.Append(LogInfo);
                sblogMsg.Append("\r\n--------------------------------------------------------------------------------------\r\n");

                File.AppendAllText(logpath, sblogMsg.ToString());
            }
            return true;
        }
        catch (Exception)
        {
            return false;
            //throw;
        }
    }
    /// <summary>
    /// 记录日志
    /// </summary>
    /// <param name="e">异常对象</param>
    /// <param name="InfoSource">发生源</param>
    /// <param name="LogType">日志类型</param>
    /// <param name="ErrMsg">附加错误信息</param>
    /// <returns></returns>
    public static bool LogWriter(Exception e, string InfoSource, EnumLogType LogType = EnumLogType.Business, string ErrMsg = "")
    {
        var msg = GetExceptionDetails(e, new List<string> { ErrMsg });
        string ErrTrace = "\r\n\r\n堆栈信息:" + e.StackTrace;
        return Logger.LogWriter(msg + ErrTrace, InfoSource, LogType);
    }
    /// <summary>
    /// 获取指定日志类型的路径
    /// </summary>
    /// <param name="LogType"></param>
    /// <returns></returns>
    public static string GetLogPath(EnumLogType LogType)
    {
        string logTypePath = Enum.GetName(typeof(EnumLogType), LogType);

        string logBasePath = string.Format("{0}\\Log\\{1}", AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'), logTypePath);
        if (!Directory.Exists(logBasePath))
        {
            Directory.CreateDirectory(logBasePath);
        }

        string logpath = string.Format(@"{0}\{1}.log", logBasePath, DateTime.Now.ToString("yyyyMMdd"));
        return logpath;
    }

    /// <summary>
    /// 获取异常详情
    /// </summary>
    /// <param name="e"></param>
    /// <param name="ErrMsg"></param>
    /// <param name="NewLineChar">换行字符串（\r\n）</param>
    /// <returns></returns>
    public static string GetExceptionDetails(Exception e, IList<string> ErrMsg, string NewLineChar = "\r\n")
    {
        //if (ErrMsg.Count == 0)
        //{
        //    ErrMsg.Add(e.Message);
        //}
        ErrMsg.Add(e.Message);
        //ErrMsg = new List<string> { "当前操作失败！", "详情：", e.Message };
        while (e.InnerException != null)
        {
            ErrMsg.Add(e.InnerException.Message);
            e = e.InnerException;
        }
        string strResult = string.Empty;
        foreach (var item in ErrMsg)
        {
            if (!string.IsNullOrEmpty(item))
            {
                strResult += item + NewLineChar;
            }
        }
        return strResult;
    }

}

