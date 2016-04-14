using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using UsedCar.ViewModels;

#region Version Info
/* ========================================================================
*   本类功能概述
* 
*   作者：WDF          时间：2014/10/27 10:15:06
*   文件名：IDicService
*   版本：V1.0.0
*
*   修改者：           时间：              
*   修改说明：
* ========================================================================
*/
#endregion

namespace Service.Abstract
{
    public interface IDicService
    {
        #region 字典表
        IPagedList<DicName> getDicNameList(string DicTypeCode, int PageIndex, int PageSize);
        IList<DicName> getDicNameList();
        IList<DicName> getDicNameList(string DicTypeCode);
        DicName getDicNameDetail(int DicID);
        DicName getDicNameDetail(string DicCode);
        int createDicName(DicName model);
        int updateDicName(DicName model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DicIDs">逗号分隔字典ID</param>
        /// <returns></returns>
        int deleteDicName(string DicIDs);

        /// <summary>
        /// 验证字典KEY唯一性
        /// </summary>
        /// <param name="DicTypeCode">字典类型</param>
        /// <param name="DicType">字典KEY</param>
        /// <returns></returns>
        bool validDicKeyUnique(string DicTypeCode, string DicKey);
        /// <summary>
        /// 验证字典KEYVALUE唯一性
        /// </summary>
        /// <param name="DicTypeCode">字典类型</param>
        /// <param name="DicValue">字典键值</param>
        /// <returns></returns>
        bool validDicKeyValueUnique(string DicTypeCode, string DicValue);
        int GetDicIDByNameCode(string name, string dicTypeCode);
        #endregion

        #region 字典类型表

        IPagedList<DicType> getDicTypeList(int PageIndex, int PageSize);
        DicType getDicTypeDetail(int DicID);
        int createDicType(DicType model);
        int updateDicType(DicType model);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DicIDs">逗号分隔字典类型ID</param>
        /// <returns></returns>
        int deleteDicType(string DicIDs);
        /// <summary>
        /// 验证字典类型唯一性
        /// </summary>
        /// <param name="TypeCode">字典类型代号</param>
        /// <returns></returns>
        bool validDicTypeUnique(string TypeCode);
        #endregion
    }
}
