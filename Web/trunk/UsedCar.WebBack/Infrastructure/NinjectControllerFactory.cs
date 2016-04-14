using Ninject;
using Service.Abstract;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

#region Version Info
/* ======================================================================== 
*   本类功能概述
*  
*   作者：wdf       时间：2014/10/8 17:11:35 
*   文件名：NinjectControllerFactory 
*   版本：V1.0.0
* 
*   修改者：            时间：               
*   修改说明： 
* ========================================================================= 
*/
#endregion

namespace Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel m_ninjectKernel;

        /// <summary>
        /// 构造函数
        /// </summary>
        public NinjectControllerFactory()
        {
            m_ninjectKernel = new StandardKernel();
            m_ninjectKernel.Settings.InjectNonPublic = true;
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)m_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            this.m_ninjectKernel.Bind<ISysManage>().To<SysManage>();
            this.m_ninjectKernel.Bind<IDicService>().To<DicService>();
            this.m_ninjectKernel.Bind<ICarBrandService>().To<CarBrandService>();
            this.m_ninjectKernel.Bind<ICarSerieService>().To<CarSerieService>();
            this.m_ninjectKernel.Bind<ICarModelService>().To<CarModelService>();

            this.m_ninjectKernel.Bind<IProvinceService>().To<ProvinceService>();
            this.m_ninjectKernel.Bind<ICityService>().To<CityService>();
        }

    }
}