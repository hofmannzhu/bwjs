using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Text;
using UtilityHelper;
using XBWNInterface.BLL;
using System.Collections;

namespace XBWN.LoanApi.Controllers
{
    /// <summary>
    /// 人脸识别
    /// </summary>
    [RoutePrefix("newxbwnapi/FaceRecognition")]
    public class FaceRecognitionController : ApiController
    {
        [HttpPost]
        [Route("Index")]
        // GET: BankCardManagement
        public HttpResponseMessage Index()
        {
            string result = string.Empty;
            HttpResponseMessage res = new HttpResponseMessage
            { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }


        #region 图片上传
        /// <summary>
        /// 4张人脸上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FilesUpload")]
        public HttpResponseMessage FilesUpload()
        {
            object result = string.Empty;
            int netLoanApplyId = DNTRequest.GetInt("netLoanApplyId", -1);
            string sign = DNTRequest.GetString("sign");
            string orderNo = DNTRequest.GetString("orderNo");
            string equipmentNo = DNTRequest.GetString("equipmentNo");
            string merchantsNo = DNTRequest.GetString("merchantsNo");
            string token = DNTRequest.GetString("token");
            string orderSource = DNTRequest.GetString("orderSource");
            string base64Codes = DNTRequest.GetString("base64Codes");
            string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");

            //string[] arr;
            //arr = base64Codes.Split(',');
            //for (int i = 0; i < arr.Length; i++)
            //{

            //}
            byte[] photoData = new byte[0];
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            photoData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);

            string fileName = string.Empty;
            string contentType = string.Empty;
            string base64Code = string.Empty;
        
            //BitArray photoDataArray = new BitArray(photoData);
            for (int i = 0; i < photoData.Length; i++)
            {
                base64Code = photoData[i].ToString();
                if (!string.IsNullOrEmpty(base64Code))
                {
                    base64Code = base64Code.Replace(" ", "+");
                }
                //fileName=


            }





            NewLoanInterface.cookieValue = token;
            result = NewLoanInterface.ImagesUpload(base64Code, photoData, fileName, contentType, sskdRequestParas);

            HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(result.ToString(), Encoding.GetEncoding("UTF-8"), "text/plain") };
            return res;
        }
        #endregion
        

    }
}