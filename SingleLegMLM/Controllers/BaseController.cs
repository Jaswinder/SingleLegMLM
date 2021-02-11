using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.SessionState;
using SingleLegMLM.Data;
using System.Configuration;
using System.Web;
using SingleLegMLM.Models;




namespace SingleLegMLM.Controllers
{
    [SessionState(SessionStateBehavior.Required)]
    public class BaseController : Controller
    {
        public int PlanID=1;
        public int PlanValue = 650;
        public int WithdrawalCharges = 15;
        public int PinCharges = 10;
        public int MinimumBankTransfer = 100;

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!String.IsNullOrEmpty(gUsername))
            {
                filterContext.Controller.ViewBag._MemberId = gMemberId;
                filterContext.Controller.ViewBag._Role = gRole;
                filterContext.Controller.ViewBag._Name = gMemberName;
                filterContext.Controller.ViewBag._Pic = gPic;
                //filterContext.Controller.ViewBag._DisplayMsg = "" ;
            }
           
        }


        public int gMSRNO
        {
            get
            {
                if (Session["MSRNO"] != null)
                {
                    return Convert.ToInt32(Session["MSRNO"]);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session.Timeout = 180;
                Session["MSRNO"] = value;
            }
        }
        public string gMemberId
        {
            get
            {
                if (Session["MemberId"] != null)
                {
                    return Session["MemberId"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["MemberId"] = value.ToString();
            }
        }
        public string gPic
        {
            get
            {
                if (Session["ProfilePic"] != null)
                {
                    return Session["ProfilePic"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["ProfilePic"] = value.ToString();
            }
        }

        public string gIntroId
        {
            get
            {
                if (Session["IntroId"] != null)
                {
                    return Session["IntroId"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["IntroId"] = value.ToString();
            }
        }
        public int gIntroMsrNo
        {
            get
            {
                if (Session["IntroMsrNo"] != null)
                {
                    return Convert.ToInt32(Session["IntroMsrNo"]);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Session.Timeout = 180;
                Session["IntroMsrNo"] = value;
            }

        }

        public string gDepartmentId
        {
            get
            {
                if (Session["DepartmentId"] != null)
                {
                    return Session["DepartmentId"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session.Timeout = 180;
                Session["DepartmentId"] = value;
            }

        }
        public string gUsername
        {
            get
            {
                if (Session["Username"] != null)
                {
                    return Session["Username"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["Username"] = value.ToString();
            }
        }
        public string gMobile
        {
            get
            {
                if (Session["mobile"] != null)
                {
                    return Session["mobile"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["mobile"] = value.ToString();
            }
        }
        public string gMemberName
        {
            get
            {
                if (Session["MemberName"] != null)
                {
                    return Session["MemberName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["MemberName"] = value.ToString();
            }
        }
        public string gRole
        {
            get
            {
                if (Session["role"] != null)
                {
                    return Session["role"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Session["role"] = value.ToString();
            }
        }
        public int ConvertToInt(int? value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public int ConvertToInt(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }
        public long ConvertToLong(long? value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public long ConvertToLong(int? value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public long ConvertToLong(string value)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
                return 0;
            }
        }
        public string ConvertToString(string value)
        {
           if(!String.IsNullOrEmpty(value))
            {
                return value;
            }
            return "";
        }

        public static string HashPassword(string password, string algorithm = "sha256")
        {
            string salt = "345tfe3e$ds23@34$p[lsm,mfoudsl987jd76sy]yui3";
            password = salt + password + "78uyt5";
            return Hash(Encoding.UTF8.GetBytes(password), algorithm);
        }

        private static string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
            }
        }
        public static string CreateRandomPassword(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%*";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public static string CreateEPin(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public bool SendOTP(string MobileNo, string OTP,string name="",string Sender= "2factor")
        {
            if (Sender=="MSG91")
            {
                var client = new RestClient("https://api.msg91.com/api/v2/sendsms");
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("authkey", "224117AalvJWXNYVk5b3c6446");
                string Message = "Your www.ClassLine.in Username is " + MobileNo + " and Password is " + OTP;
                string JsonVal = "{ \"sender\": \"CLSLIN\", \"route\": \"4\", \"country\": \"91\", \"sms\": [ { \"message\": \"" + Message + "\", \"to\": [ \"" + MobileNo + "\" ] }] }";
                request.AddParameter("application/json", JsonVal, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                // AddToDatabase(MobileNo,OTP);
                return response.IsSuccessful;
            }
            if(Sender == "2factor")
            {
                var client = new RestClient("http://2factor.in/API/V1/f259a29c-863e-11ea-9fa5-0200cd936042/ADDON_SERVICES/SEND/TSMS");
                var request = new RestRequest(Method.POST);
                string loginat = "";
                string JsonVal = "{ \"From\": \"ADDINC\", \"To\":  \"" + MobileNo + "\" ,\"TemplateName\":\"RegisterTemplate\", \"VAR1\":  \"" + name + "\", \"VAR2\":  \"" + OTP + "\", \"VAR3\":  \"" + loginat + "\"}";
                request.AddParameter("application/json", JsonVal, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response.IsSuccessful;
            }
            return false;
        }

        public bool SendWelcomeMsg(string MobileNo, string VAR1, string VAR2 = "",string VAR3="", string Sender = "2factor")
        {
            if (Sender == "MSG91")
            {
                //var client = new RestClient("https://api.msg91.com/api/v2/sendsms");
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("content-type", "application/json");
                //request.AddHeader("authkey", "224117AalvJWXNYVk5b3c6446");
                //string Message = "Your www.ClassLine.in Username is " + MobileNo + " and Password is " + OTP;
                //string JsonVal = "{ \"sender\": \"CLSLIN\", \"route\": \"4\", \"country\": \"91\", \"sms\": [ { \"message\": \"" + Message + "\", \"to\": [ \"" + MobileNo + "\" ] }] }";
                //request.AddParameter("application/json", JsonVal, ParameterType.RequestBody);
                //IRestResponse response = client.Execute(request);
                //// AddToDatabase(MobileNo,OTP);
                //return response.IsSuccessful;
                return false;
            }
            if (Sender == "2factor")
            {
                var client = new RestClient("http://2factor.in/API/V1/f259a29c-863e-11ea-9fa5-0200cd936042/ADDON_SERVICES/SEND/TSMS");
                var request = new RestRequest(Method.POST);
                string loginat = "";
                string JsonVal = "{ \"From\": \"ADDINC\", \"To\":  \"" + MobileNo + "\" ,\"TemplateName\":\"WelcomeMSG\", \"VAR1\":  \"" + VAR1 + "\", \"VAR2\":  \"" + VAR2 + "\", \"VAR3\":  \"" + VAR3 + "\"}";
                request.AddParameter("application/json", JsonVal, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                return response.IsSuccessful;
            }
            return false;
        }

        public bool SendSMS(string MobileNo, string OTP)
        {
            var client = new RestClient("https://api.msg91.com/api/v2/sendsms");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authkey", "224117AalvJWXNYVk5b3c6446");
            string Message =  OTP;
            string JsonVal = "{ \"sender\": \"CLSLIN\", \"route\": \"4\", \"country\": \"91\", \"sms\": [ { \"message\": \"" + Message + "\", \"to\": [ \"" + MobileNo + "\" ] }] }";
            request.AddParameter("application/json", JsonVal, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //AddToDatabase(MobileNo, OTP);
            return response.IsSuccessful;
        }

        //public void AddToDatabase(string MobileNo, string OTP)
        //{
        //    try
        //    {
        //        DigiClassEntities db = new DigiClassEntities();
        //        SMSMessage msg = new SMSMessage();
        //        msg.Message = OTP;
        //        msg.SendTo = MobileNo;
        //        msg.SentDate = DateTime.Now;
        //        msg.UserId = gUserId;


        //        if (gRole == "Teacher")
        //        {
        //            var teacher = db.Teachers.FirstOrDefault(x => x.User.Username == MobileNo);
        //            College college = db.Colleges.FirstOrDefault(x => x.ID == teacher.CollegeId);
        //            msg.CollegeId = college.ID;
        //        }
        //        else if (gRole == "Student")
        //        {
        //            var student = db.Students.FirstOrDefault(x => x.User.Username == MobileNo);
        //            College college = db.Colleges.FirstOrDefault(x => x.ID == student.CollageId);
        //            msg.CollegeId = college.ID;

        //        }
        //        else if (gRole == "Principal")
        //        {
        //            var teacher = db.Principals.FirstOrDefault(x => x.User.Username == MobileNo);
        //            College college = db.Colleges.FirstOrDefault(x => x.ID == teacher.CollegeId);
        //            msg.CollegeId = college.ID;

        //        }
        //        else if (gRole == "Management")
        //        {
        //            var teacher = db.Managements.FirstOrDefault(x => x.User.Username == MobileNo);
        //            College college = db.Colleges.FirstOrDefault(x => x.ID == teacher.CollegeId);
        //            msg.CollegeId = college.ID;

        //        }
        //        else
        //        {
        //            var user = db.Users.FirstOrDefault(x => x.Username == MobileNo);
        //            College college = user.Colleges.FirstOrDefault();
        //            msg.CollegeId = college.ID;

        //        }




        //        db.SMSMessages.Add(msg);
        //        db.SaveChanges();
        //    }
        //    catch(Exception ex)
        //    {

        //    }



        //}

        public IDbDataParameter CreateParameter(DbType parameterType, int size, string name, ParameterDirection direction,object value)
        {
            return new SqlParameter
            {
                DbType = parameterType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
               
            };
        }


    }
}