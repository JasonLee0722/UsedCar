using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Abstract;
using PagedList;
using UsedCar.ViewModels;
using Common.Utils;

#region Version Info
/* ========================================================================
*   本类功能概述
* 
*   作者：WDF          时间：2014/10/27 10:13:45
*   文件名：DicService
*   版本：V1.0.0
*
*   修改者：           时间：              
*   修改说明：
* ========================================================================
*/
#endregion

namespace Service.Concrete
{
    public class DicService : IDicService
    {
        #region 字典表
        public IPagedList<DicName> getDicNameList(string DicTypeCode, int PageIndex, int PageSize)
        {
            //GET api/dic/all/page{pageIndex}
            string url = string.Format("{0}/api/dic/all/page{1}", WEBUtility.WebApiHost, PageIndex);
            var models = NetUtility.GetHttpWithToken<IList<DicName>>(url);
            return models.ToPagedList(PageIndex, PageSize);
        }
        public IList<DicName> getDicNameList()
        {
            //GET api/dic/all
            string url = string.Format("{0}/api/dic/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<DicName>>(url);
        }
        public IList<DicName> getDicNameList(string DicTypeCode)
        {
            //return db.DicNames.Where(m => m.DicTypeCode == DicTypeCode).OrderBy(m => m.Sort).ToList();

            //GET api/dicname/all
            string url = string.Format("{0}/api/dicname/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<DicName>>(url);
        }
        public DicName getDicNameDetail(int DicID)
        {
            //GET api/dicname/{id}
            string url = string.Format("{0}/api/dicname/{1}", WEBUtility.WebApiHost, DicID);
            return NetUtility.GetHttpWithToken<DicName>(url);
        }
        public DicName getDicNameDetail(string DicCode)
        {
            //GET api/dicname/{id}
            string url = string.Format("{0}/api/dicname/{1}", WEBUtility.WebApiHost, DicCode);
            return NetUtility.GetHttpWithToken<DicName>(url);
        }
        public int createDicName(DicName model)
        {

            //POST api/dicname/add
            string url = string.Format("{0}/api/dicname/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int updateDicName(DicName model)
        {
            //POST api/dicname/edit
            string url = string.Format("{0}/api/dicname/edit", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int deleteDicName(string DicIDs)
        {
            //POST api/dicname/delete?id={id}
            string url = string.Format("{0}/api/dicname/delete?id={1}", WEBUtility.WebApiHost, DicIDs);
            return NetUtility.PostHttpWithToken(url);
        }
        public bool validDicKeyUnique(string DicTypeCode, string DicKey)
        {
            throw new NotImplementedException();
            //return db.DicNames.Where(m => m.DicTypeCode == DicTypeCode && m.Name == DicKey).Count() > 0;
        }

        public bool validDicKeyValueUnique(string DicTypeCode, string DicValue)
        {
            throw new NotImplementedException();
            //return db.DicNames.Where(m => m.DicTypeCode == DicTypeCode && m.KeyValue == DicValue).Count() > 0;
        }

        public int GetDicIDByNameCode(string name, string dicTypeCode)
        {
            //var model = db.DicNames.AsNoTracking().Where(m => m.DicTypeCode == dicTypeCode && m.Name == name && m.State == 1).FirstOrDefault();
            //return model == null ? 0 : model.ID;
            throw new NotImplementedException();

        }
        #endregion

        #region 字典类型表
        public IPagedList<DicType> getDicTypeList(int PageIndex, int PageSize)
        {

            //GET api/dictype/all
            string url = string.Format("{0}/api/dictype/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<DicType>>(url);
            return models.ToPagedList<DicType>(PageIndex, PageSize);
        }

        public DicType getDicTypeDetail(int DicID)
        {
            //GET api/dictype/{id}
            string url = string.Format("{0}/api/dictype/{1}", WEBUtility.WebApiHost, DicID);
            return NetUtility.GetHttpWithToken<DicType>(url);
        }

        public int createDicType(DicType model)
        {
            //POST api/dictype/add
            string url = string.Format("{0}/api/dictype/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int updateDicType(DicType model)
        {
            //POST api/dictype/edit
            string url = string.Format("{0}/api/dictype/edit", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }

        public int deleteDicType(string DicIDs)
        {

            //POST api/dictype/delete?id={id}
            string url = string.Format("{0}/api/dictype/delete?id={1}", WEBUtility.WebApiHost, DicIDs);
            return NetUtility.PostHttpWithToken(url);
        }
        public bool validDicTypeUnique(string TypeCode)
        {
            //TypeCode = string.IsNullOrWhiteSpace(TypeCode) ? "" : TypeCode.Trim();
            //return db.DicTypes.Where(m => m.TypeCode == TypeCode).Count() > 0;
            throw new NotImplementedException();

        }
        #endregion

    }
}
