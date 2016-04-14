using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Configuration;

using UsedCar.Domain;
using UsedCar.WebAPIs.Models;

namespace UsedCar.WebAPIs.Controllers
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [Authorize]
    [RoutePrefix("api/user")]
    public class SysUserController : ApiController
    {
        private int m_pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["page:size"]);
        private string m_errorMessage = EnumService.GetDescription(MessageContent.error); 

        private SysUserRepository m_sysUserRepo = new SysUserRepository();

        /// <summary>
        /// 查询所有用户信息（身份验证）
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        [ResponseType(typeof(PagingInfo<SysUser>))]
        public IQueryable<PagingInfo<SysUser>> UsersOfPage(int page)
        {
            //return m_sysRepo.GetSysUsersOfPage(page, m_pageSize);
            return null;
        }

        /// <summary>
        /// 查询用户信息，条件：ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("find")]
        [ResponseType(typeof(SysUser))]
        public async Task<IHttpActionResult> UserById(int id)
        {
            var user = await m_sysUserRepo.GetSysUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// 用户登陆，验证登录名、密码。
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="loginPwd">密码</param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public SysUser SysUserLogin(string loginName, string loginPwd)
        {
            var user = m_sysUserRepo.GetSysUserOfLogin(loginName, loginPwd);
            //设置空值，返回的JSON数据会自动过滤
            //user.LoginPwd = null;
            return user;
        }
    }
}
