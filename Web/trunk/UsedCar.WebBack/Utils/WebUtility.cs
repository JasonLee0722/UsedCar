using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Web.Security.Cryptography;
using System.Net;

namespace Common.Utils
{
    public class WEBUtility
    {
        #region Web配置

        /// <summary>
        /// 获取照片允许的尺寸（宽，高）(单位：像素)
        /// </summary>
        public static Size GetPhotoSize
        {
            get
            {
                var pSize = ConfigurationManager.AppSettings["PhotoSize"].ToString().Split(',');
                return new Size(Convert.ToInt32(pSize[0]), Convert.ToInt32(pSize[0]));
            }
        }
        /// <summary>
        /// 获取照片允许的文件大小(单位：KB)
        /// </summary>
        public static int GetPhotoCapacity
        {
            get
            {
                var result = string.Empty;
                result = ConfigurationManager.AppSettings["PhotoCapacity"];
                return Convert.ToInt32(result);
            }
        }
        /// <summary>
        /// 获取列表显示的记录条数
        /// </summary>
        public static int GetPageSize
        {
            get
            {
                var result = string.Empty;
                result = ConfigurationManager.AppSettings["PageSize"];
                return string.IsNullOrEmpty(result.Trim()) ? 12 : Convert.ToInt32(result.Trim());
            }
        }

        /// <summary>
        /// 获取窗口列表显示的记录条数
        /// </summary>
        public static int GetPageSizeForWindow
        {
            get
            {
                var result = string.Empty;
                result = ConfigurationManager.AppSettings["PageSizeForWindow"];
                return string.IsNullOrEmpty(result.Trim()) ? 6 : Convert.ToInt32(result.Trim());
            }
        }

        /// <summary>
        /// 获取字典表值
        /// </summary>
        public static string GetDicName(string value)
        {
            var result = string.Empty;
            result = ConfigurationManager.AppSettings[value];
            return string.IsNullOrEmpty(result.Trim()) ? "" : result.Trim();
        }
        /// <summary>
        /// 获取微信服务平台接口的域名
        /// </summary>
        public static string WeiXinMPDomain
        {
            get
            {
                var result = string.Empty;
                result = ConfigurationManager.AppSettings["WeiXinMPDomain"];
                return string.IsNullOrEmpty(result.Trim()) ? "127.0.0.1" : result.Trim(); //58.211.71.39
            }
        }
        /// <summary>
        /// 获取WebApiHost
        /// </summary>
        /// <returns></returns>
        public static string WebApiHost
        {
            get
            {
                var result = string.Empty;
                result = ConfigurationManager.AppSettings["WebApiHost"];
                return string.IsNullOrEmpty(result.Trim()) ? "http://localhost" : result.Trim();
            }
        }

        #endregion

        #region 截取字符串

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="stringToSub">原字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="endstring">截取之后尾部跟随的字符窜如：“...”</param>
        /// <returns></returns>
        public static string GetSubString(string stringToSub, int length, string endstring)
        {
            string str = "";
            if (stringToSub == null)
            {

                return str;
            }
            else
            {
                if (stringToSub.Length > length)
                {
                    str = stringToSub.Substring(0, length) + endstring;
                }
                else
                {
                    str = stringToSub;
                }
                return str;
            }
        }
        #endregion

        #region 获取客户端信息
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            //先获取["HTTP_X_FORWARDED_FOR"]，后获取["REMOTE_ADDR"]
            return !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ? System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Replace("，", ",").Split(',')[0] : System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        /// <summary>
        /// 后台获取IP，仅获取REMOTE_ADDR
        /// </summary>
        /// <returns></returns>
        public static string GetClientLocalIP()
        {
            //获取["REMOTE_ADDR"]
            return System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        #endregion

        #region 其它
        /// <summary>
        /// 用户登录状态会话KEY
        /// </summary>
        /// <returns></returns>
        public static string UserSessionName()
        {
            return "UsedCar.UserInfo";
        }

        /// <summary>
        /// 获取上传文件的物理路径
        /// </summary>
        /// <param name="uploadFolder">指定的上传文件夹</param>
        /// <param name="fileUrl">文件URL</param>
        /// <returns></returns>
        public static string GetUpFilePhysicalPath(string uploadFolder, string fileUrl)
        {
            uploadFolder = uploadFolder.Replace('/', '\\');
            fileUrl = fileUrl.Replace('/', '\\');
            string fileFullName = System.Web.Hosting.HostingEnvironment.MapPath(Path.Combine(uploadFolder, fileUrl));
            //System.Web.HttpServerUtilityBase
            return fileFullName;
        }

        //清除html代码
        public static string ClearHtmlCode(string text)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text)) return string.Empty;
            //排除<数字>的标签，eg："<123>"
            text = Regex.Replace(text, @"<[\/?a-zA-Z]{1,}.*?>", "");
            return text;
        }

        /// <summary>
        /// 获取指定条件的不重复的随机数
        /// </summary>
        /// <param name="Number">随机数个数</param>
        /// <param name="minNum">随机数下限</param>
        /// <param name="maxNum">随机数上限</param>
        /// <returns></returns>
        public static int[] GetRandomArray(int Number, int minNum, int maxNum)
        {
            //int[] index = new int[Number];
            //for (int i = 0; i < Number; i++)
            //    index[i] = i;
            //Random r = new Random();
            ////用来保存随机生成的不重复的数
            //int[] result = new int[Number];
            //int site = maxNum;//设置上限
            //int id;
            //for (int j = 0; j < Number; j++)
            //{
            //    id = r.Next(minNum, site - 1);
            //    //在随机位置取出一个数，保存到结果数组
            //    result[j] = index[id];
            //    //最后一个数复制到当前位置
            //    index[id] = index[site - 1];
            //    //位置的上限减少一
            //    site--;
            //}
            //return result;
            int j;
            int[] b = new int[Number];
            Random r = new Random();
            for (j = 0; j < Number; j++)
            {
                int i = r.Next(minNum, maxNum + 1);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (b[k] == i)
                    {
                        num = num + 1;
                    }
                }
                if (num == 0)
                {
                    b[j] = i;
                }
                else
                {
                    j = j - 1;
                }
            }
            return b;
        }
        #endregion

        #region 密码管理
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        /// <summary>
        /// 创建MD5密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CreateMd5(string password)
        {
            MD5 md5Hash = MD5.Create();
            string hashResult = GetMd5Hash(md5Hash, string.Format("车联网{0}孙跃王东风{0}中心平台软件", password));
            return hashResult;
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile("车联网中心平台软件" + password, "MD5");
        }
        /// <summary>
        /// 创建通行令牌
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="md5PWD"></param>
        /// <returns></returns>
        public static string CreatePassToken(string LoginName, string md5PWD)
        {
            DateTime dt = DateTime.Now;
            int tSurvival = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute;
            string srcString = "车联网中心平台软件" + LoginName + "AdMINLoginOn" + md5PWD + tSurvival.ToString();

            MD5 md5Hash = MD5.Create();
            string hashResult = GetMd5Hash(md5Hash, srcString);
            return hashResult;
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(srcString, "MD5");
        }

        #endregion

        #region 判断浏览器
        /// <summary>
        /// 判断是否在微信内置浏览器中
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static bool SideInWeixinBroswer(HttpContextBase httpContext)
        {
            var userAgent = httpContext.Request.UserAgent;
            if (string.IsNullOrEmpty(userAgent) || (!userAgent.Contains("MicroMessenger") && !userAgent.Contains("Windows Phone")))
            {
                //在微信外部
                return false;
            }
            //在微信内部
            return true;
        }

        #endregion

        #region 中文转拼音
        /// <summary>
        /// 获取中文全拼
        /// </summary>
        /// <param name="CNString"></param>
        /// <returns></returns>
        public static string GetSpelling(string CNString)
        {
            string splling = FormatWithCNString(CNString);
            return splling.Replace(" ", "").ToUpper();
        }
        /// <summary>
        /// 获取中文简拼
        /// </summary>
        /// <param name="CNString"></param>
        /// <returns></returns>
        public static string GetSimpleSpelling(string CNString)
        {
            string splling = FormatWithCNString(CNString);
            string[] arrspll = splling.Split(' ');
            string sspell = "";
            for (int i = 0; i < arrspll.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(arrspll[i]))
                {
                    sspell += arrspll[i].Substring(0, 1).ToUpper();
                }
            }
            return sspell;
        }
        /// <summary>
        /// 中文字符转换拼音函数
        /// </summary>
        /// <param name="_strCN">传入中文字符</param>
        /// <returns>返回拼音</returns>
        public static string FormatWithCNString(string _strCN)
        {
            ///去除汉字空格
            _strCN = _strCN.Trim();
            ///使用StringBuilder优化字符串连接
            StringBuilder result = new StringBuilder();

            if (_strCN.IndexOf("重庆") >= 0)
            {
                ///如果汉字中包含"重庆"直接替换成"chong qing"
                _strCN = _strCN.Replace("重庆", "chong qing");
            }
            ///每个汉字为2字节
            byte[] arr = new byte[2];
            ///汉字的编码
            int charCode = 0;
            int arr1 = 0;
            int arr2 = 0;
            char[] arrChar = _strCN.ToCharArray();

            ///遍历输入的字符
            for (int j = 0; j < arrChar.Length; j++)
            {
                ///根据系统默认编码得到字节码 
                arr = Encoding.Default.GetBytes(arrChar[j].ToString());
                if (arr.Length == 1)
                {
                    ///如果只有1字节说明该字符不是汉字，结束本次循环
                    result.Append(arrChar[j].ToString());
                    continue;

                }
                ///取字节1
                arr1 = (short)(arr[0]);
                ///取字节2
                arr2 = (short)(arr[1]);
                ///计算汉字的编码 
                charCode = arr1 * 256 + arr2 - 65536;

                ///如果不在汉字编码范围内则不改变
                if (charCode > -10254 || charCode < -20319)
                {
                    result.Append(arrChar[j]);
                }
                else
                {
                    ///根据汉字编码范围查找对应的拼音并保存到结果中，由于charCode的键不一定存在，所以要找比他更小的键上一个键  
                    if (!CodeCollections.ContainsKey(charCode))
                    {
                        for (int i = charCode; i <= 0; --i)
                        {
                            if (CodeCollections.ContainsKey(i))
                            {
                                result.Append(" " + CodeCollections[i] + " ");
                                break;
                            }
                        }
                    }
                    else
                    {
                        result.Append(" " + CodeCollections[charCode] + " ");
                    }
                }
            }
            return result.ToString().Trim().Replace("  ", " "); ;
        }

        #region 定义汉字拼音编码字典
        /// <summary>
        /// 汉字拼音编码字典
        /// </summary>
        private static readonly Dictionary<int, string> CodeCollections = new Dictionary<int, string>
        {
            { -20319, "a" }, { -20317, "ai" }, { -20304, "an" }, { -20295, "ang" }, { -20292, "ao" }, { -20283, "ba" }, { -20265, "bai" },
            { -20257, "ban" }, { -20242, "bang" }, { -20230, "bao" }, { -20051, "bei" }, { -20036, "ben" }, { -20032, "beng" }, { -20026, "bi" },
            { -20002, "bian" }, { -19990, "biao" }, { -19986, "bie" }, { -19982, "bin" }, { -19976, "bing" }, { -19805, "bo" },
            { -19784, "bu" }, { -19775, "ca" }, { -19774, "cai" }, { -19763, "can" }, { -19756, "cang" }, { -19751, "cao" }, { -19746, "ce" },
            { -19741, "ceng" }, { -19739, "cha" }, { -19728, "chai" }, { -19725, "chan" }, { -19715, "chang" }, { -19540, "chao" },
            { -19531, "che" }, { -19525, "chen" }, { -19515, "cheng" }, { -19500, "chi" }, { -19484, "chong" }, { -19479, "chou" },
            { -19467, "chu" }, { -19289, "chuai" }, { -19288, "chuan" }, { -19281, "chuang" }, { -19275, "chui" }, { -19270, "chun" },
            { -19263, "chuo" }, { -19261, "ci" }, { -19249, "cong" }, { -19243, "cou" }, { -19242, "cu" }, { -19238, "cuan" },
            { -19235, "cui" }, { -19227, "cun" }, { -19224, "cuo" }, { -19218, "da" }, { -19212, "dai" }, { -19038, "dan" }, { -19023, "dang" },
            { -19018, "dao" }, { -19006, "de" }, { -19003, "deng" }, { -18996, "di" }, { -18977, "dian" }, { -18961, "diao" }, { -18952, "die" },
            { -18783, "ding" }, { -18774, "diu" }, { -18773, "dong" }, { -18763, "dou" }, { -18756, "du" }, { -18741, "duan" },
            { -18735, "dui" }, { -18731, "dun" }, { -18722, "duo" }, { -18710, "e" }, { -18697, "en" }, { -18696, "er" }, { -18526, "fa" },
            { -18518, "fan" }, { -18501, "fang" }, { -18490, "fei" }, { -18478, "fen" }, { -18463, "feng" }, { -18448, "fo" }, { -18447, "fou" },
            { -18446, "fu" }, { -18239, "ga" }, { -18237, "gai" }, { -18231, "gan" }, { -18220, "gang" }, { -18211, "gao" }, { -18201, "ge" },
            { -18184, "gei" }, { -18183, "gen" }, { -18181, "geng" }, { -18012, "gong" }, { -17997, "gou" }, { -17988, "gu" }, { -17970, "gua" },
            { -17964, "guai" }, { -17961, "guan" }, { -17950, "guang" }, { -17947, "gui" }, { -17931, "gun" }, { -17928, "guo" },
            { -17922, "ha" }, { -17759, "hai" }, { -17752, "han" }, { -17733, "hang" }, { -17730, "hao" }, { -17721, "he" }, { -17703, "hei" },
            { -17701, "hen" }, { -17697, "heng" }, { -17692, "hong" }, { -17683, "hou" }, { -17676, "hu" }, { -17496, "hua" },
            { -17487, "huai" }, { -17482, "huan" }, { -17468, "huang" }, { -17454, "hui" }, { -17433, "hun" }, { -17427, "huo" },
            { -17417, "ji" }, { -17202, "jia" }, { -17185, "jian" }, { -16983, "jiang" }, { -16970, "jiao" }, { -16942, "jie" },
            { -16915, "jin" }, { -16733, "jing" }, { -16708, "jiong" }, { -16706, "jiu" }, { -16689, "ju" }, { -16664, "juan" },
            { -16657, "jue" }, { -16647, "jun" }, { -16474, "ka" }, { -16470, "kai" }, { -16465, "kan" }, { -16459, "kang" }, { -16452, "kao" },
            { -16448, "ke" }, { -16433, "ken" }, { -16429, "keng" }, { -16427, "kong" }, { -16423, "kou" }, { -16419, "ku" }, { -16412, "kua" },
            { -16407, "kuai" }, { -16403, "kuan" }, { -16401, "kuang" }, { -16393, "kui" }, { -16220, "kun" }, { -16216, "kuo" },
            { -16212, "la" }, { -16205, "lai" }, { -16202, "lan" }, { -16187, "lang" }, { -16180, "lao" }, { -16171, "le" }, { -16169, "lei" },
            { -16158, "leng" }, { -16155, "li" }, { -15959, "lia" }, { -15958, "lian" }, { -15944, "liang" }, { -15933, "liao" },
            { -15920, "lie" }, { -15915, "lin" }, { -15903, "ling" }, { -15889, "liu" }, { -15878, "long" }, { -15707, "lou" }, { -15701, "lu" },
            { -15681, "lv" }, { -15667, "luan" }, { -15661, "lue" }, { -15659, "lun" }, { -15652, "luo" }, { -15640, "ma" }, { -15631, "mai" },
            { -15625, "man" }, { -15454, "mang" }, { -15448, "mao" }, { -15436, "me" }, { -15435, "mei" }, { -15419, "men" },
            { -15416, "meng" }, { -15408, "mi" }, { -15394, "mian" }, { -15385, "miao" }, { -15377, "mie" }, { -15375, "min" },
            { -15369, "ming" }, { -15363, "miu" }, { -15362, "mo" }, { -15183, "mou" }, { -15180, "mu" }, { -15165, "na" }, { -15158, "nai" },
            { -15153, "nan" }, { -15150, "nang" }, { -15149, "nao" }, { -15144, "ne" }, { -15143, "nei" }, { -15141, "nen" }, { -15140, "neng" },
            { -15139, "ni" }, { -15128, "nian" }, { -15121, "niang" }, { -15119, "niao" }, { -15117, "nie" }, { -15110, "nin" },
            { -15109, "ning" }, { -14941, "niu" }, { -14937, "nong" }, { -14933, "nu" }, { -14930, "nv" }, { -14929, "nuan" }, { -14928, "nue" },
            { -14926, "nuo" }, { -14922, "o" }, { -14921, "ou" }, { -14914, "pa" }, { -14908, "pai" }, { -14902, "pan" }, { -14894, "pang" },
            { -14889, "pao" }, { -14882, "pei" }, { -14873, "pen" }, { -14871, "peng" }, { -14857, "pi" }, { -14678, "pian" },
            { -14674, "piao" }, { -14670, "pie" }, { -14668, "pin" }, { -14663, "ping" }, { -14654, "po" }, { -14645, "pu" }, { -14630, "qi" },
            { -14594, "qia" }, { -14429, "qian" }, { -14407, "qiang" }, { -14399, "qiao" }, { -14384, "qie" }, { -14379, "qin" },
            { -14368, "qing" }, { -14355, "qiong" }, { -14353, "qiu" }, { -14345, "qu" }, { -14170, "quan" }, { -14159, "que" },
            { -14151, "qun" }, { -14149, "ran" }, { -14145, "rang" }, { -14140, "rao" }, { -14137, "re" }, { -14135, "ren" }, { -14125, "reng" },
            { -14123, "ri" }, { -14122, "rong" }, { -14112, "rou" }, { -14109, "ru" }, { -14099, "ruan" }, { -14097, "rui" }, { -14094, "run" },
            { -14092, "ruo" }, { -14090, "sa" }, { -14087, "sai" }, { -14083, "san" }, { -13917, "sang" }, { -13914, "sao" }, { -13910, "se" },
            { -13907, "sen" }, { -13906, "seng" }, { -13905, "sha" }, { -13896, "shai" }, { -13894, "shan" }, { -13878, "shang" },
            { -13870, "shao" }, { -13859, "she" }, { -13847, "shen" }, { -13831, "sheng" }, { -13658, "shi" }, { -13611, "shou" },
            { -13601, "shu" }, { -13406, "shua" }, { -13404, "shuai" }, { -13400, "shuan" }, { -13398, "shuang" }, { -13395, "shui" },
            { -13391, "shun" }, { -13387, "shuo" }, { -13383, "si" }, { -13367, "song" }, { -13359, "sou" }, { -13356, "su" },
            { -13343, "suan" }, { -13340, "sui" }, { -13329, "sun" }, { -13326, "suo" }, { -13318, "ta" }, { -13147, "tai" }, { -13138, "tan" },
            { -13120, "tang" }, { -13107, "tao" }, { -13096, "te" }, { -13095, "teng" }, { -13091, "ti" }, { -13076, "tian" },
            { -13068, "tiao" }, { -13063, "tie" }, { -13060, "ting" }, { -12888, "tong" }, { -12875, "tou" }, { -12871, "tu" },
            { -12860, "tuan" }, { -12858, "tui" }, { -12852, "tun" }, { -12849, "tuo" }, { -12838, "wa" }, { -12831, "wai" }, { -12829, "wan" },
            { -12812, "wang" }, { -12802, "wei" }, { -12607, "wen" }, { -12597, "weng" }, { -12594, "wo" }, { -12585, "wu" }, { -12556, "xi" },
            { -12359, "xia" }, { -12346, "xian" }, { -12320, "xiang" }, { -12300, "xiao" }, { -12120, "xie" }, { -12099, "xin" },
            { -12089, "xing" }, { -12074, "xiong" }, { -12067, "xiu" }, { -12058, "xu" }, { -12039, "xuan" }, { -11867, "xue" },
            { -11861, "xun" }, { -11847, "ya" }, { -11831, "yan" }, { -11798, "yang" }, { -11781, "yao" }, { -11604, "ye" }, { -11589, "yi" },
            { -11536, "yin" }, { -11358, "ying" }, { -11340, "yo" }, { -11339, "yong" }, { -11324, "you" }, { -11303, "yu" },
            { -11097, "yuan" }, { -11077, "yue" }, { -11067, "yun" }, { -11055, "za" }, { -11052, "zai" }, { -11045, "zan" },
            { -11041, "zang" }, { -11038, "zao" }, { -11024, "ze" }, { -11020, "zei" }, { -11019, "zen" }, { -11018, "zeng" },
            { -11014, "zha" }, { -10838, "zhai" }, { -10832, "zhan" }, { -10815, "zhang" }, { -10800, "zhao" }, { -10790, "zhe" },
            { -10780, "zhen" }, { -10764, "zheng" }, { -10587, "zhi" }, { -10544, "zhong" }, { -10533, "zhou" }, { -10519, "zhu" },
            { -10331, "zhua" }, { -10329, "zhuai" }, { -10328, "zhuan" }, { -10322, "zhuang" }, { -10315, "zhui" }, { -10309, "zhun" },
            { -10307, "zhuo" }, { -10296, "zi" }, { -10281, "zong" }, { -10274, "zou" }, { -10270, "zu" }, { -10262, "zuan" }, { -10260, "zui" },
            { -10256, "zun" }, { -10254, "zuo" }
        };
        #endregion


        #endregion

    } //辅助类结束
    /*******************************************************************/

}
