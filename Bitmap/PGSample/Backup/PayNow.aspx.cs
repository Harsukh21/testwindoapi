using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ni.dp.util;


namespace PGSample
{ 
    //*****************************************************************************************************
    //******************************Created By Abdul Niyas*************************************************
    //******************************Network International************************************************** 
    //***************************** Dubai,UAE +971 566224687*********************************************** 
    //*****************************************************************************************************
    public partial class PayNow : System.Web.UI.Page
    {
        string requestparams1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            //Harcoded merchant key

            //string key = "QN3PFOQ+PKSU8pWThKXq9t4mLxcCCwyvi7+cvj/h4H0=";

            string key = "K7MCfw+AFMN1HEKmhATQzK2HT5eiFymimN9eu+Yb95s=";

            string strMessage = txtOrdNo.Text;
            strMessage += txtMerchantOrderNumber.Text+ "|" +
           txtCurrency.Text + "|" +
           txtAmount.Text + "|" +
           txtSuccessURL.Text + "|" +
           txtFailureURL.Text + "|" +
           txtTransactionType.Text + "|" +
           txtTransactionMode.Text + "|" +
           txtPayModeType.Text + "|" +
           txtCreditCardNumber.Text + "|" +
           txtCVV.Text + "|" +
           txtExpiryMonth.Text + "|" +
           txtExpiryYear.Text + "|" +
           txtCardType.Text + "|" +
           txtBillToFirstName.Text + "|" +
           txtBillToLastName.Text + "|" +
           txtBillToStreet1.Text + "|" +
           txtBillToStreet2.Text + "|" +
           txtBillToCity.Text + "|" +
           txtBillToState.Text + "|" +
           txtBillToPostalCode.Text + "|" +
           txtBillToCountry.Text + "|" +
           txtBillToEmail.Text + "|" +
           txtBillToPhoneNumber1.Text + "|" +
           txtBillToPhoneNumber2.Text + "|" +
           txtBillToPhoneNumber3.Text + "|" +
           txtBillToMobileNumber.Text + "|" +
           txtGatewayID.Text + "|" +
           txtCustomerID.Text + "|" +
           txtShipToFirstName.Text + "|" +
           txtShipToLastName.Text + "|" +
           txtShipToStreet1.Text + "|" +
           txtShipToStreet2.Text + "|" +
           txtShipToCity.Text + "|" +
           txtShipToState.Text + "|" +
           txtShipToPostalCode.Text + "|" +
           txtShipToCountry.Text  + "|" +
           txtShipToPhoneNumber1.Text + "|" +
           txtShipToPhoneNumber2.Text + "|" +
           txtShipToPhoneNumber3.Text + "|" +
           txtShipToMobileNumber.Text + "|" +
           txtTransactionSource.Text + "|" +
           txtProductInfo.Text + "|" +
           txtIsUserLoggedIn.Text + "|" +
           txtItemTotal.Text + "|" +
           txtItemCategory.Text + "|" +
           txtIgnoreValidationResult.Text + "|" +
           txtudf1.Text + "|" +
           txtudf2.Text + "|" +
           txtudf3.Text + "|" +
           txtudf4.Text + "|" +
           txtudf5.Text + "|";

            EncDec aesEncrypt = new EncDec();
            requestparams1 = aesEncrypt.Encrypt(key, strMessage);


             
            /***Merchant ID is concatenated with encrypted requestparameter****/
            requestparams.Value = "201703301000001|" + requestparams1;
            txtVerify.Text = requestparams1;
            //TextBox5.Text = requestparams.Value;
        }
    }
}