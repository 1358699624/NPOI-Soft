
/**
 * Description:Excel数据导出
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using YY_Dal;
using YY_Model;
using YY_Services;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace YY_NpoiExportAndImport.Controllers
{
    public class ExcelOperationController : Controller
    {
        private readonly NpoiExcelOperationService _excelExport;

        private readonly SchoolUserInfoContext _userInfoContext;
        public ExcelOperationController(SchoolUserInfoContext schoolUserInfoContext, NpoiExcelOperationService excelExport)
        {
            _userInfoContext = schoolUserInfoContext;
            _excelExport = excelExport;
        }

        /// <summary>
        /// 导出Excel文档展示界面
        /// </summary>
        /// <returns></returns>
        public IActionResult ExportExcelData()
        {
            return View();
        }

        /// <summary>
        /// Excel文档生成并导出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DataExportSimple()
        {
            bool result = _excelExport.ExcelDataExport(out string resultMsg, out string excelFilePath);

            return Json(result == true ? new { code = 1, data = excelFilePath } : new { code = 0, data = resultMsg });
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="page">当前页码</param>
        /// <param name="limit">显示条数</param>
        /// <param name="userName">用户姓名</param>
        /// <returns></returns>

        List<UserInfo> listData;

        public JsonResult GetUserInfo(int page = 1, int limit = 5, string userName = "")
        {
            try
            {
               
                var totalCount = 0;
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    listData = _userInfoContext.UserInfos.Where(x => x.UserName.Contains(userName)).OrderByDescending(m => m.Id).ToList();//.OrderByDescending(m => m.Id).ToList();//.Skip((page - 1) * limit).Take(limit).ToList();
                    totalCount = _userInfoContext.UserInfos.Count(x => x.UserName.Contains(userName));
                }
                else
                {
                    listData = _userInfoContext.UserInfos.OrderByDescending(m => m.Id).ToList();//.Skip((page - 1) * limit).Take(limit).ToList(); 
                    totalCount = _userInfoContext.UserInfos.Count();
                }

                return Json(new { code = 0, count = totalCount, data = listData });
            }
            catch (Exception ex)
            {
                return Json(new { code = 1, msg = ex.Message });
            }
        }
        /// <summary>
        /// Excel文档生成并导出(数据库数据)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DataExportOutPage()
        {
            listData = _userInfoContext.UserInfos.OrderByDescending(m => m.Id).ToList();
            bool result = _excelExport.DataExportOutPage(listData, out string resultMsg, out string excelFilePath);

            return Json(result == true ? new { code = 1, data = excelFilePath } : new { code = 0, data = resultMsg });
        }


    }
}