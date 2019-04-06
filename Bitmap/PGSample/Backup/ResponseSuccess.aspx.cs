using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ni.dp.util;
 

namespace PGSample
{
    public partial class ResponseSuccess : System.Web.UI.Page
    {
        //*****************************************************************************************************
        //******************************Created By Abdul Niyas*************************************************
        //******************************Network International************************************************** 
        //***************************** Dubai,UAE +971 566224687*********************************************** 
        //*****************************************************************************************************
        string responseparams1;
        protected void Page_Load(object sender, EventArgs e)
        {

            string key = "K7MCfw+AFMN1HEKmhATQzK2HT5eiFymimN9eu+Yb95s=";
            string strMessage = Request["responseParameter"];

            EncDec aesEncrypt = new EncDec();



            responseparams1 = EncDec.Decrypt(key, strMessage);

            Response.Write(responseparams1);


        }
    }
}