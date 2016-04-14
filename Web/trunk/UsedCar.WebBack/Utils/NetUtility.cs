using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using UsedCar.ViewModels;

namespace Common.Utils
{
    /// <summary>
    /// 通过WebClient/HttpWebRequest实现http的post/get方法
    /// </summary>
    public class NetUtility
    {

        #region basic验证的WebRequest/WebResponse

        /// <summary>
        /// 通过 WebRequest/WebResponse 类访问远程地址并返回结果，需要Basic认证；(GET方法)
        /// 调用端自己处理异常
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="timeout">访问超时时间，单位毫秒；如果不设置超时时间，传入0</param>
        /// <param name="encoding">如果不知道具体的编码，传入null</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Request_WebRequest(string uri, int timeout, Encoding encoding, string username, string password)
        {
            string result = string.Empty;

            WebRequest request = WebRequest.Create(new Uri(uri));

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                request.Credentials = GetCredentialCache(uri, username, password);
                request.Headers.Add("Authorization", GetAuthorization(username, password));
            }

            if (timeout > 0)
                request.Timeout = timeout;

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = encoding == null ? new StreamReader(stream) : new StreamReader(stream, encoding);

            result = sr.ReadToEnd();

            sr.Close();
            stream.Close();

            return result;
        }

        #region # 生成 Http Basic 访问凭证 #

        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));

            return credCache;
        }

        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        #endregion


        #endregion

        #region POST方法(WebClient)

        /// <summary>
        /// 通过WebClient类Post数据到远程地址，需要Basic认证；
        /// 调用端自己处理异常
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="paramStr">name=张三&age=20</param>
        /// <param name="encoding">请先确认目标网页的编码方式</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Request_WebClient(string uri, string paramStr, Encoding encoding, string username, string password)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            string result = string.Empty;

            WebClient wc = new WebClient();

            // 采取POST方式必须加的Header
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            byte[] postData = encoding.GetBytes(paramStr);

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                wc.Credentials = GetCredentialCache(uri, username, password);
                wc.Headers.Add("Authorization", GetAuthorization(username, password));
            }

            byte[] responseData = wc.UploadData(uri, "POST", postData); // 得到返回字符流
            return encoding.GetString(responseData);// 解码                  
        }


        #endregion

        #region Get方法(HttpWebRequest)
        /// <summary>
        /// GET方式获取URL资源表示的数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentType"></param>
        /// <param name="token">认证令牌</param>
        /// <returns>返回动态类型（State(bool),Content(string)）</returns>
        public static dynamic GetHttp(string url, string contentType = "application/json", string token = "")
        {
            HttpWebRequest httpWebRequest = null;
            StreamReader streamReader = null;
            HttpWebResponse httpWebResponse = null;
            dynamic objReVal = new System.Dynamic.ExpandoObject();
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = 20000;
                if (!string.IsNullOrEmpty(token))
                {
                    //httpWebRequest.Headers["Authorization"] = "Bearer " + token;
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                }
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
                string responseContent = streamReader.ReadToEnd();

                objReVal.State = true;
                objReVal.Content = responseContent;
                return objReVal;
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex, "NetUtility_GetHttp", EnumLogType.SysErr);
                objReVal.State = false;
                objReVal.Content = "服务器错误！";
                return objReVal;
            }
            finally
            {
                if (httpWebResponse != null)
                    httpWebResponse.Close();
                if (streamReader != null)
                    streamReader.Close();
                if (httpWebRequest != null)
                    httpWebRequest.Abort();
            }
        }

        public static string GetHttp(string url, HttpContext httpContext)
        {
            string queryString = "?";

            foreach (string key in httpContext.Request.QueryString.AllKeys)
            {
                queryString += key + "=" + httpContext.Request.QueryString[key] + "&";
            }

            queryString = queryString.Substring(0, queryString.Length - 1);
            return url + queryString;
        }


        #endregion

        #region POST方法(httpWebRequest)

        //body是要传递的参数,格式"roleId=1&uid=2"
        //post的cotentType填写:
        //"application/x-www-form-urlencoded"
        //soap填写:"text/xml; charset=utf-8"
        public static string PostHttp(string url, string body, string contentType)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 20000;

            byte[] btBodys = Encoding.UTF8.GetBytes(body);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();

            return responseContent;

        }

        #endregion

        #region 请求网络数据
        private void TestNetPost()
        {
            // 通知提醒模板
            string m_action = "CommonAPI/SendTemplateMessageForTrafficViolation/";
            // 微信公众号URL
            string m_weChatUrl = "http://www.ridoz.cn"; //ConfigurationManager.AppSettings["weChat"].ToString();
            //添加信息
            Dictionary<string, string> dicFormData = new Dictionary<string, string>();
            dicFormData.Add("keyword1", "strCodes");
            dicFormData.Add("keyword2", "strNotes");

            string url = string.Format("{0}/{1}", m_weChatUrl, m_action);
            string content = PostFormDataFormat(dicFormData);
            string result = GetPostResponse(url, content);

        }
        /// <summary>
        /// POST Response 返回动态类型＂State(bool),Content(string)＂
        /// </summary>
        /// <param name="url">Http Url</param>
        /// <param name="postContent">Http Url参数(name=张三＆age=20)</param>
        /// <param name="contentType"></param>
        /// <param name="token">认证令牌</param>
        /// <returns>返回动态类型＂State(bool),Content(string)＂</returns>
        public static dynamic GetPostResponse(string url, string postContent = "", string contentType = "application/json", string token = "")
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            dynamic objReVal = new System.Dynamic.ExpandoObject();
            try
            {
                // 设置POST(请求)相关参数   
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = contentType;//"application/x-www-form-urlencoded";
                request.KeepAlive = false;
                request.AllowAutoRedirect = true;
                if (!string.IsNullOrEmpty(token))
                {
                    //request.Headers["Authorization"] = "Bearer " + token;
                    request.Headers.Add("Authorization", "Bearer " + token);
                }
                //request.UserAgent =
                //    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1;" +
                //    " .NET CLR 2.0.50727; .NET CLR 3.0.04506.648;" +
                //    " .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                //CookieContainer cookieContainer = new CookieContainer();
                //request.CookieContainer = cookieContainer;

                //name=张三&age=20
                if (postContent != "")
                {
                    byte[] postData = Encoding.UTF8.GetBytes(postContent);
                    request.ContentLength = postData.Length;

                    // 提交请求数据   
                    Stream outputStream = request.GetRequestStream();
                    outputStream.Write(postData, 0, postData.Length);
                    outputStream.Close();
                }
                else
                {
                    request.ContentLength = 0;
                }

                response = request.GetResponse() as HttpWebResponse;
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string strResponse = reader.ReadToEnd();
                objReVal.State = true;
                objReVal.Content = strResponse;
                return objReVal;
            }
            catch (Exception ex)
            {
                Logger.LogWriter(ex, "NetUtility_GetPostResponse", EnumLogType.SysErr);
                objReVal.State = false;
                objReVal.Content = "服务器错误！";
                return objReVal;
            }
            finally
            {
                if (request != null)
                    request.Abort();
                if (response != null)
                    response.Close();
                if (reader != null)
                    reader.Close();
            }
        }
        /// <summary>
        /// 格式化Post表单数据
        /// </summary>
        /// <param name="dicFormData"></param>
        /// <returns>name=张三&age=20</returns>
        public static string PostFormDataFormat(Dictionary<string, string> dicFormData)
        {
            StringBuilder sbContent = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in dicFormData)
            {
                sbContent.AppendFormat("&" + kvp.Key + "={0}", kvp.Value);
            }
            sbContent.Remove(0, 1);
            return sbContent.ToString().Trim();
        }


        /// <summary>
        /// 通过GET方式获取网络内容
        /// </summary>
        /// <param name="_URL"></param>
        /// <returns></returns>
        public static string GetHttpWebResponseContentByGET(string _URL)
        {

            HttpWebRequest httpReq;
            HttpWebResponse httpResp;

            string strBuff = "";
            char[] cbuffer = new char[256];
            int byteRead = 0;

            Uri httpURL = new Uri(_URL);
            //HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
            httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            //通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换
            httpResp = (HttpWebResponse)httpReq.GetResponse();
            //GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容
            //若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
            Stream respStream = httpResp.GetResponseStream();
            //返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8） 
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            byteRead = respStreamReader.Read(cbuffer, 0, 256);

            while (byteRead != 0)
            {
                string strResp = new string(cbuffer, 0, byteRead);
                strBuff = strBuff + strResp;
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
            }

            respStream.Close();
            return strBuff;
        }

        #endregion

        #region AccessToken
        /// <summary>
        /// 使用用户名及密码获取Token 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string GetAccessToken(string UserName, string Password)
        {
            //{ grant_type: "password", username: username, password: password, ran: Math.random() }
            //添加信息
            Dictionary<string, string> dicFormData = new Dictionary<string, string>();
            dicFormData.Add("grant_type", "password");
            dicFormData.Add("username", UserName);
            dicFormData.Add("password", Password);
            dicFormData.Add("ran", new Random().Next().ToString());

            string url = string.Format("{0}/token", WEBUtility.WebApiHost);
            string content = PostFormDataFormat(dicFormData);
            var reposeData = GetPostResponse(url, content);
            if (reposeData.State)
            {
                //HttpContext.Current.Request.Cookies["access_token"].Value = reposeData.Content;
                //{"access_token":"RKdPpa-_8DOzU_cJ8GJfIPCxGxxuVxMMhK7EFl9UQbEACyaf8dxlIsdFCDsbWa_xCJSvs5S8SvLevZ8Ivr9T6LfkanQqaZ0pYSSLZwvx7VwkgEeI7iYU-ltrzyISEUSZa_Z-4Cz5OVmmo_7zuSM7E95SXkflhw7y4Xkb4gORUgxItBMSrdd2YHhCCaJKgonccU6LowGWx2dxAXLEHby3bQ","token_type":"bearer","expires_in":7199}
                var _AccessToken = JsonConvert.DeserializeObject<UsedCar.ViewModels.AccessToken>(reposeData.Content);
                //var user = JsonConvert.DeserializeObject(json.Content);
                if (_AccessToken != null)
                {
                    if (HttpContext.Current.Request.Cookies.Get("access_token") != null)
                    {
                        HttpContext.Current.Request.Cookies.Remove("access_token");
                    }
                    var httpCookie = new HttpCookie("access_token", _AccessToken.access_token);
                    httpCookie.Expires = new DateTime(_AccessToken.expires_in * 1000);
                    HttpContext.Current.Request.Cookies.Add(httpCookie);
                    return _AccessToken.access_token;
                }
                //return reposeData.Content;
            }
            return string.Empty;
        }
        /// <summary>
        /// 从Cookie中获取缓存的Token,如果过期或不存在则利用当前登录用户信息去申请,若未登录则返回空字符
        /// </summary>
        /// <returns></returns>
        public static string GetAccessTokenFromCache()
        {
            //var Request = HttpContext.Current.Request;
            //var token = HttpContext.Current.Request.Cookies["access_token"].Value;
            var tokenHttpCookie = HttpContext.Current.Request.Cookies.Get("access_token");
            var token = tokenHttpCookie == null ? "" : tokenHttpCookie.Value;
            if (string.IsNullOrEmpty(token))
            {
                var user = (UsedCar.ViewModels.SysUser)HttpContext.Current.Session[WEBUtility.UserSessionName()];
                if (user != null)
                {
                    return GetAccessToken(user.LoginName, user.LoginPwd);
                }
                return string.Empty;
            }
            else
            {
                return token;
            }
        }

        #endregion

        #region 快捷访问
        /// <summary>
        /// 通过GET获取API数据，并返回指定的对象
        /// </summary>
        /// <typeparam name="T">要返回的对象类</typeparam>
        /// <param name="url">API（GET方式）</param>
        /// <returns></returns>
        public static T GetHttpWithToken<T>(string url)
        {
            var _token = GetAccessTokenFromCache();
            dynamic json = GetHttp(url, token: _token);
            if (json.State)
            {
                if (!string.IsNullOrEmpty(json.Content))
                {
                    var model = JsonConvert.DeserializeObject<T>(json.Content);
                    //var model = JsonConvert.DeserializeObject(json.Content);
                    if (model != null)
                    {
                        return model;
                    }
                }
            }
            return default(T);
        }
        /// <summary>
        /// 通过POST传递表单数据来更新API资源，并返回0或1（1：成功影响；0：未影响；）
        /// </summary>
        /// <param name="url">API（POST方式）</param>
        /// <param name="dicFormData">Post表单数据</param>
        /// <returns></returns>
        public static int PostHttpWithToken(string url, Dictionary<string, string> dicFormData = null)
        {
            string content = dicFormData == null ? "" : PostFormDataFormat(dicFormData);
            return PostHttpWithToken(url, content, "application/json");
        }
        /// <summary>
        /// 通过POST传递对象来更新API资源，并返回0或1（1：成功影响；0：未影响；）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int PostHttpWithToken(string url, object model)
        {
            string SerializeJson = JsonConvert.SerializeObject(model);
            return PostHttpWithToken(url, SerializeJson);
        }
        /// <summary>
        /// 通过POST传递字符串来更新API资源，并返回0或1（1：成功影响；0：未影响；）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static int PostHttpWithToken(string url, string content, string contentType = "application/x-www-form-urlencoded")
        {
            //"application/x-www-form-urlencoded"
            var _token = GetAccessTokenFromCache();
            dynamic json = GetPostResponse(url, content, token: _token);
            if (json.State)
            {
                //var _json = JsonConvert.DeserializeObject(json.Content);
                //string SerializeJson = JsonConvert.SerializeObject(_json);
                var model = JsonConvert.DeserializeObject<Message>(json.Content);
                //return json.Content;
                if (model.State)
                {
                    return 1;
                }
            }
            return 0;
        }
        #endregion
    }
}