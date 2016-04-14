using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Data;
using System.IO;
using Common.Utils;
using UsedCar.ViewModels;
using Service.Abstract;
//using PagedList;

namespace UsedCar.WebBack.Controllers
{

    [ValidateUserLogin]
    public class DicController : BaseController
    {
        #region 属性
        [Ninject.Inject]
        private ICarBrandService m_ICarBrand { get; set; }
        [Ninject.Inject]
        private ICarSerieService m_ICarSerie { get; set; }
        [Ninject.Inject]
        private ICarModelService m_ICarModel { get; set; }

        #endregion

        public ActionResult Index(string id, int PageIndex = 1)
        {
            ViewBag.DicType = id;
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var model = m_IDicService.getDicNameList(id, PageIndex, WEBUtility.GetPageSize);
            return View(model);
        }

        #region 字典类型
        public ActionResult DicTypeIndex(int PageIndex = 1)
        {
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var model = m_IDicService.getDicTypeList(PageIndex, WEBUtility.GetPageSize);
            return View(model);
        }
        //
        // GET: /Dic/DicTypeEdit/5
        public ActionResult DicTypeEdit(int? id)
        {
            var model = new DicType();
            if (id != null)
            {
                model = m_IDicService.getDicTypeDetail(id.Value);
            }
            return View(model);
        }

        //
        // POST: /Dic/DicTypeEdit/5
        [HttpPost]
        public ActionResult DicTypeEdit(int? id, DicType model, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    if (m_IDicService.createDicType(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_IDicService.updateDicType(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }
        //
        // GET: /Dic/DicTypeDelete/5
        public ActionResult DicTypeDelete(int id)
        {
            try
            {
                if (m_IDicService.deleteDicType(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        //
        // GET: /Dic/validDicTypeUnique
        public ActionResult validDicTypeUnique(string TypeCode)
        {
            if (m_IDicService.validDicTypeUnique(TypeCode))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 字典编辑

        //
        // GET: /Dic/DicEdit/5
        public ActionResult DicEdit(int? id, string DicType = "Other")
        {
            var model = new DicName() { DicTypeCode = DicType, State = 1 };
            if (id != null)
            {
                model = m_IDicService.getDicNameDetail(id.Value);
            }
            return View(model);
        }

        //
        // POST: /Dic/DicEdit/5
        [HttpPost]
        public ActionResult DicEdit(int? id, DicName model, FormCollection collection)
        {
            try
            {
                model.Name = model.Name.Trim();
                if (id == null)
                {
                    if (m_IDicService.createDicName(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_IDicService.updateDicName(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }
        //
        // GET: /Dic/DicDelete/5
        public ActionResult DicDelete(int id)
        {
            try
            {
                if (m_IDicService.deleteDicName(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 批量删除字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DicBatchDelete(string id)
        {
            try
            {
                if (m_IDicService.deleteDicName(id) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Dic/validDicKeyUnique
        public ActionResult validDicKeyUnique(string DicTypeCode, string Name)
        {
            if (m_IDicService.validDicKeyUnique(DicTypeCode, Name))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Dic/validDicKeyValueUnique
        public ActionResult validDicKeyValueUnique(string DicTypeCode, string KeyValue)
        {
            if (m_IDicService.validDicKeyValueUnique(DicTypeCode, KeyValue))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region  汽车品牌字典表管理

        #region 汽车品牌信息
        /// <summary>
        /// 汽车品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CarBrandIndex(int PageIndex = 1)
        {
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var model = m_ICarBrand.GetCarBrandList(WEBUtility.GetPageSize, PageIndex);
            return View(model);
        }

        #region 图片上传测试
        public ViewResult PicTest(int? id = 0)
        {
            var model = new CarBrand();
            if (id != 0)
            {
                model = m_ICarBrand.getCarBrandDetail(id.Value);
            }
            else
            {
                model.ID = 0;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult PicTest(int? id, CarBrand model, FormCollection collection, HttpPostedFileBase CarImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CarImage != null)
                    {
                        model.PicType = CarImage.ContentType;
                        model.Pic = new byte[CarImage.ContentLength];
                        CarImage.InputStream.Read(model.Pic, 0, CarImage.ContentLength);
                    }
                    else if (model.ID != 0)
                    {
                        var brand = m_ICarBrand.getCarBrandDetail(model.ID);
                        model.Pic = brand.Pic;
                        model.PicType = brand.PicType;
                    }
                }
                if (model.ID == 0)
                {
                    model.State = 1;
                    model.AddTime = System.DateTime.Now;
                    if (m_ICarBrand.AddCarBrand(model) > 0)
                    {
                        // TODO: Add update logic here
                        TempData["Result"] = "添加成功";
                        return RedirectToAction("PicTest", new { id = id });
                    }
                    else
                    {
                        TempData["Result"] = "未添加任何值";
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {

                    if (m_ICarBrand.EditCarBrand(model) > 0)
                    {
                        TempData["Result"] = "修改成功";
                        return RedirectToAction("PicTest", new { id = model.ID });
                    }
                    else
                    {
                        TempData["Result"] = "未修改任何值";
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }

        }
        public FileContentResult GetImage(int Id)
        {
            CarBrand prod = m_ICarBrand.getCarBrandDetail(Id);
            if (prod.Pic != null)
            {
                return File(prod.Pic, prod.PicType);
            }
            else
            {
                return null;
            }
        }



        #endregion

        public ActionResult CarBrandEdit(int? id)
        {
            var model = new CarBrand();
            if (id != null)
            {
                model = m_ICarBrand.getCarBrandDetail(id.Value);
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult CarBrandEdit(int? id, CarBrand model, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {
                    model.PicType = image.ContentType;
                    model.Pic = new byte[image.ContentLength];
                    image.InputStream.Read(model.Pic, 0, image.ContentLength);
                }
                if (id == null)
                {

                    model.State = 1;
                    model.AddTime = System.DateTime.Now;
                    if (m_ICarBrand.AddCarBrand(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_ICarBrand.EditCarBrand(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }


        public ActionResult validCarBrandUnique(string Brand)
        {
            if (m_ICarBrand.checkNameUnique(Brand))
            {
                //return Json(new { success = false, message = "此账号已被占用！" }, JsonRequestBehavior.AllowGet);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CarBrandDelete(int id)
        {
            try
            {
                if (m_ICarBrand.DeleteCarBrand(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CarBrandBatchDelete(string id)
        {
            try
            {
                if (m_ICarBrand.DeleteCarBrand(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 汽车系列信息
        /// <summary>
        /// 汽车系列信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CarSerieIndex(int PageIndex = 1, int CarBrandId = 0)
        {
            ViewBag.CarBrandId = CarBrandId;
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var model = m_ICarSerie.GetCarSerieList(WEBUtility.GetPageSize, PageIndex, CarBrandId);
            return View(model);
        }

        public ActionResult CarSerieEdit(int? id = 0, int CarBrandId = 0)
        {
            //ViewBag.CarBrandId = CarBrandId;
            var model = new CarSerie();
            if (id != 0)
            {
                model = m_ICarSerie.getCarSerieDetail(id.Value);
                model.BrandID = CarBrandId;
            }
            else
            {
                model.ID = 0;
                model.BrandID = CarBrandId;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult CarSerieEdit(int? id, CarSerie model, FormCollection collection, HttpPostedFileBase CarImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CarImage != null)
                    {
                        model.PicType = CarImage.ContentType;
                        model.Pic = new byte[CarImage.ContentLength];
                        CarImage.InputStream.Read(model.Pic, 0, CarImage.ContentLength);
                    }
                    else if (model.ID != 0)
                    {
                        var Serie = m_ICarSerie.getCarSerieDetail(model.ID);//m_ICarBrand.getCarBrandDetail(model.ID);
                        model.Pic = Serie.Pic;
                        model.PicType = Serie.PicType;
                    }
                }
                if (model.ID == 0)
                {
                    model.AddTime = System.DateTime.Now;
                    model.State = 1;
                    if (m_ICarSerie.AddCarSerie(model) > 0)
                    {
                        // return Json(new { success = true, message = "添加成功！" });
                        TempData["Result"] = "添加成功";
                        return RedirectToAction("CarSerieEdit", new { id = id, CarBrandId = model.BrandID });

                    }
                    else
                    {
                        TempData["Result"] = "未添加任何值";
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    if (m_ICarSerie.EditCarSerie(model) > 0)
                    {
                        // TODO: Add update logic here
                        //return Json(new { success = true, message = "修改成功！" });
                        TempData["Result"] = "修改成功";
                        return RedirectToAction("CarSerieEdit", new { id = id });
                    }
                    else
                    {
                        TempData["Result"] = "未修改任何值";
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }
        public FileContentResult GetImageCarSerie(int Id)
        {
            CarSerie prod = m_ICarSerie.getCarSerieDetail(Id);
            if (prod.Pic != null)
            {
                return File(prod.Pic, prod.PicType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult validCarSerieUnique(string Name)
        {
            if (m_ICarSerie.checkNameUnique(Name))
            {
                //return Json(new { success = false, message = "此账号已被占用！" }, JsonRequestBehavior.AllowGet);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CarSerieDelete(int id)
        {
            try
            {
                if (m_ICarSerie.DeleteCarSerie(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CarSerieBatchDelete(string id)
        {
            try
            {
                if (m_ICarSerie.DeleteCarSerie(id) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region 汽车型号信息
        /// <summary>
        /// 汽车型号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CarModelIndex(int PageIndex = 1, int CarSerieId = 0, int CarBrandId = 0)
        {
            ViewBag.CarBrandId = CarBrandId;
            ViewBag.CarSerieId = CarSerieId;
            ViewBag.NumberStart = (PageIndex - 1) * WEBUtility.GetPageSize + 1;
            var model = m_ICarModel.GetCarModelList(WEBUtility.GetPageSize, PageIndex, CarSerieId);

            return View(model);
        }

        public ActionResult CarModelEdit(int? id = 0, int CarSerieId = 0)
        {

            var model = new CarModel();
            if (id != 0)
            {
                model = m_ICarModel.getCarModelDetail(id.Value);
                model.SerieID = CarSerieId;
            }
            else
            {
                model.ID = 0;
                model.SerieID = CarSerieId;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult CarModelEdit(int? id, CarModel model, FormCollection collection)
        {
            //model.dev_cs = model.dev_cs == null ? 0 : model.dev_cs;
            model.dev_ct = model.dev_ct == null ? 0 : model.dev_ct;
            try
            {
                if (id == null)
                {
                    model.Addtime = System.DateTime.Now;

                    if (m_ICarModel.AddCarModel(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "添加成功！" });
                    }
                    else
                    {
                        throw new Exception("未添加任何值！");
                    }
                }
                else
                {
                    model.ID = Convert.ToInt32(id);
                    if (m_ICarModel.EditCarModel(model) > 0)
                    {
                        // TODO: Add update logic here
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        throw new Exception("未修改任何值！");
                    }
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("保存失败！\r\n详情：\r\n{0}", msg) });
            }
        }

        public ActionResult validCarModelUnique(string Name)
        {
            if (m_ICarModel.checkNameUnique(Name))
            {
                //return Json(new { success = false, message = "此账号已被占用！" }, JsonRequestBehavior.AllowGet);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CarModelDelete(int id)
        {
            try
            {
                if (m_ICarModel.DeleteCarModel(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CarModelBatchDelete(string id)
        {
            try
            {
                if (m_ICarModel.DeleteCarModel(id.ToString()) > 0)
                {
                    return Json(new { success = true, message = "删除成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new Exception("未删除任何值！");
                }
            }
            catch (Exception e)
            {
                var msg = Logger.GetExceptionDetails(e, new List<string> { e.Message }, "\r\n");
                return Json(new { success = false, message = string.Format("删除失败！\r\n详情：\r\n{0}", msg) }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region 品牌、车系、车型选择

        //品牌、车系、车型选择窗口
        public ActionResult CarModelSelect(int? BrandID, int? SerieID, int? ModelID)
        {
            ViewBag.CarBrands = m_ICarBrand.GetCarBrandList();
            ViewBag.CarSeries = m_ICarSerie.GetCarSerieList(BrandID ?? -1);
            ViewBag.CarModels = m_ICarModel.GetCarModelList(SerieID ?? -1);

            ViewBag.BrandID = BrandID;
            ViewBag.SerieID = SerieID;
            ViewBag.ModelID = ModelID;

            return View();
        }
        //车系选择
        public ActionResult GetCarSerieSelect(string CarBrandID)
        {
            var lst = m_ICarSerie.GetCarSerieList(Convert.ToInt32(CarBrandID)).Select(m => new { m.ID, m.Name });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        // 车型选择
        public ActionResult GetCarModelSelect(string CarSerieID)
        {
            var lst = m_ICarModel.GetCarModelList(Convert.ToInt32(CarSerieID)).Select(m => new { m.ID, m.Name });
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        //判断是否必须选择车型
        // GET: /Dic/IsMustSelectModel/id
        public bool IsMustSelectModel(int id)
        {
            return m_ICarBrand.IsMustSelectModel(id);
        }
        #endregion
        #endregion

        #region 车辆导入
        public ActionResult Import()
        {

            return View();
        }

        public ActionResult ImportExcel()
        {
            #region 读取Excel
            string Path = "";
            HttpPostedFileBase excel = Request.Files["fileUpload"];

            if (excel == null)
            {
                return Content("选择文件错误！");
            }
            else
            {

                try
                {
                    string s = excel.FileName;
                    string str = s.Substring(s.LastIndexOf("\\") + 1);
                    string path = "/Temp/" + Guid.NewGuid() + str;
                    excel.SaveAs(Server.MapPath(path));

                    Path = Server.MapPath(path);
                }
                catch { }
            }
            if (Path == "")
            {
                return Content("导入失败！");
            }
            int i = 0;
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;

            strExcel = "select * from [车辆品牌型号模板$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            try
            {
                myCommand.Fill(ds, "table1");
            }
            catch
            {
                return Content("确定excel中要导入的Sheet名称为'车辆品牌型号模板'");
            }
            DataTable dt = ds.Tables[0];
            #endregion

            System.Text.StringBuilder sbError = new System.Text.StringBuilder(); //记录每行导入的结果

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string bland = dt.Rows[j][0].ToString().Trim();
                string serie = dt.Rows[j][1].ToString().Trim();
                string model = dt.Rows[j][2].ToString().Trim();
                int brandID = 0;
                int serieID = 0;
                int modelID = 0;
                #region 品牌
                if (bland != "")
                {
                    CarBrand _cb = m_ICarBrand.getCarBrandDetail(bland);
                    if (_cb == null)
                    {
                        CarBrand cb = new CarBrand();
                        cb.Brand = bland;
                        cb.Sort = GetCharSpellCode(dt.Rows[j][0].ToString().Trim().Substring(0, 1));
                        cb.AddTime = System.DateTime.Now;
                        cb.State = 1;
                        int cbid = m_ICarBrand.AddCarBrand(cb);
                        try
                        {
                            brandID = m_ICarBrand.getCarBrandDetail(bland).ID;
                        }
                        catch
                        {
                            sbError.Append("<br/>第" + (j + 2) + "行\"品牌\"获取ID失败");
                            continue;
                        }
                    }
                    else
                    {
                        brandID = _cb.ID;
                    }
                }
                else
                {
                    sbError.Append("<br/>第" + (j + 2) + "行\"品牌\"未填写");
                    continue;
                }
                if (serie == "")
                {
                    sbError.Append("<br/>第" + (j + 2) + "行导入成功");
                }
                #endregion

                #region 车系
                if (serie != "")
                {
                    CarSerie _cs = m_ICarSerie.getCarSerieDetail(serie);
                    if (_cs == null)    //1.系列名不存在则插入系列名
                    {
                        CarSerie cs = new CarSerie();
                        cs.BrandID = brandID;
                        cs.Name = serie;
                        cs.AddTime = System.DateTime.Now;
                        cs.State = 1;
                        int csid = m_ICarSerie.AddCarSerie(cs);
                        try
                        {
                            serieID = m_ICarSerie.getCarSerieDetail(serie).ID;
                        }
                        catch
                        {
                            sbError.Append("<br/>第" + (j + 2) + "行\"车系\"获取ID失败");
                            continue;
                        }
                    }
                    else
                    {
                        if (_cs.BrandID == brandID) //2.系列名存在且品牌名一致，则不做操作
                        {
                            serieID = _cs.ID;
                        }
                        else    //3.系列名存在但品牌名不一致，则插入系列名
                        {
                            CarSerie cs = new CarSerie();
                            cs.BrandID = brandID;
                            cs.Name = serie;
                            cs.AddTime = System.DateTime.Now;
                            cs.State = 1;
                            int csid = m_ICarSerie.AddCarSerie(cs);
                            try
                            {
                                serieID = m_ICarSerie.getCarSerieDetail(serie).ID;
                            }
                            catch
                            {
                                sbError.Append("<br/>第" + (j + 2) + "行\"车系\"获取ID失败");
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
                if (model == "")
                {
                    sbError.Append("<br/>第" + (j + 2) + "行导入成功");
                }
                #endregion

                #region 车型
                if (model != "")
                {
                    CarModel _cm = m_ICarModel.getCarModelDetail(model);
                    if (_cm == null)    //1.车型名不存在则插入车型名
                    {
                        CarModel cm = new CarModel();
                        cm.SerieID = serieID;
                        cm.Name = model;
                        try
                        {
                            cm.Year = Convert.ToInt32(model.Substring(0, 4));
                        }
                        catch
                        {
                            cm.Year = 0;
                        }
                        cm.MT_AT = (model.IndexOf("自动") > -1) ? "自动" : ((model.IndexOf("手动") > -1) ? "手动" : null);
                        cm.Addtime = System.DateTime.Now;
                        cm.State = 1;
                        //OBD参数
                        //cm.dev_cs = ShortTryParse(dt.Rows[j][8].ToString().Trim());
                        //cm.dev_ct = ShortTryParse(dt.Rows[j][9].ToString().Trim());

                        i = m_ICarModel.AddCarModel(cm);
                        try
                        {
                            modelID = m_ICarModel.getCarModelDetail(model).ID;
                        }
                        catch
                        {
                            sbError.Append("<br/>第" + (j + 2) + "行\"车型\"获取ID失败");
                            continue;
                        }
                    }
                    else
                    {
                        if (_cm.SerieID == serieID)  //2.车型名存在且系列名一致，则不做操作
                        {
                            modelID = _cm.ID;
                        }
                        else    //3.车型名存在但系列名不一致，则插入车型名
                        {
                            CarModel cm = new CarModel();
                            cm.SerieID = serieID;
                            cm.Name = model;
                            try
                            {
                                cm.Year = Convert.ToInt32(model.Substring(0, 4));
                            }
                            catch
                            {
                                cm.Year = 0;
                            }
                            cm.MT_AT = (model.IndexOf("自动") > -1) ? "自动" : ((model.IndexOf("手动") > -1) ? "手动" : null);
                            cm.Addtime = System.DateTime.Now;
                            cm.State = 1;
                            //OBD参数
                            //cm.dev_cs = ShortTryParse(dt.Rows[j][8].ToString().Trim());
                            //cm.dev_ct = ShortTryParse(dt.Rows[j][9].ToString().Trim());

                            i = m_ICarModel.AddCarModel(cm);
                            try
                            {
                                modelID = m_ICarModel.getCarModelDetail(model).ID;
                            }
                            catch
                            {
                                sbError.Append("<br/>第" + (j + 2) + "行\"车型\"获取ID失败");
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
                sbError.Append("<br/>第" + (j + 2) + "行导入成功");
                #endregion

            }
            conn.Dispose();
            if (System.IO.File.Exists(Path))//判断文件是否存在
            {
                System.IO.File.Delete(Path);//执行IO文件删除,需引入命名空间System.IO;    
            }

            if (sbError.ToString() != "")
            {
                return Content(sbError.ToString());
            }
            else
            {
                return Content("导入成功！");
            }

        }

        /// <summary>
        /// 尝试转换为Int类型，失败则默认为0
        /// </summary>
        /// <param name="InData"></param>
        public short ShortTryParse(string InData)
        {
            short Temp = 0;
            short.TryParse(InData, out Temp);
            return Temp;
        }

        ///   得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        ///   </summary> 
        ///   <param   name="CnChar">单个汉字</param> 
        ///   <returns>单个大写字母</returns> 
        private static string GetCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                //   get   the     array   of   byte   from   the   single   char    
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }
            #region table   of   the   constant   list
            //expresstion 
            //table   of   the   constant   list 
            // 'A';           //45217..45252 
            // 'B';           //45253..45760 
            // 'C';           //45761..46317 
            // 'D';           //46318..46825 
            // 'E';           //46826..47009 
            // 'F';           //47010..47296 
            // 'G';           //47297..47613 

            // 'H';           //47614..48118 
            // 'J';           //48119..49061 
            // 'K';           //49062..49323 
            // 'L';           //49324..49895 
            // 'M';           //49896..50370 
            // 'N';           //50371..50613 
            // 'O';           //50614..50621 
            // 'P';           //50622..50905 
            // 'Q';           //50906..51386 

            // 'R';           //51387..51445 
            // 'S';           //51446..52217 
            // 'T';           //52218..52697 
            //没有U,V 
            // 'W';           //52698..52979 
            // 'X';           //52980..53640 
            // 'Y';           //53689..54480 
            // 'Z';           //54481..55289 
            #endregion
            //   iCnChar match     the   constant 
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= .51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }

        #endregion


    }
}
