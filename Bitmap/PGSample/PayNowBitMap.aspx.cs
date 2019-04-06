using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ni.dp.util;

/*
	* 2017 Abzer Technology Solutions  Sample Class For Bitmap 
	*  
	*  NOTICE OF LICENSE
	*  File Name : PayNowBitMap 
	*  For generating the request string 
	*  DISCLAIMER
	*  
	* 
	*  @author Abzer Developers <info@abzer.com>
	*  @copyright  Abzer Developers
	*  @license   
	*  
*/
namespace PGSample
{
    public partial class PayNowNew : System.Web.UI.Page
    {
        string requestparams1;
        string key = "xxxxxxx";
        string merchantID = "20170xxxxxxxx";
        string strMessage = "";
        BitMapModel bmp = new BitMapModel();
        List<String> tranMode = new List<string> { "", "INTERNET", "MOTO", "RECURRING" };
        List<String> tranTypes = new List<string> { "", "SALE", "AUTHORIZATION" };
        List<String> payModeTypes = new List<string> { "", "CC", "DC", "DD" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["bmpObj"] = null;
                //bmp = new BitMapModel();
                Initialize();
                
                //DataBind();
            }
            else
            {
                if ((BitMapModel)Session["bmpObj"] != null)
                { bmp = (BitMapModel)Session["bmpObj"]; }
            }
        }


        protected void GenerateString()
        {

            strMessage = bmp.Calculate();
            key = txtKey.Text;
            merchantID = txtMerchantID.Text;
            EncDec aesEncrypt = new EncDec();
            requestparams1 = aesEncrypt.Encrypt(key, strMessage);
            requestparams.Value = merchantID + "||NI||" + requestparams1;
            txtVerify.Text = strMessage;
            string path = Server.MapPath("~/log/Log.txt");
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
            {
                writer.WriteLine(strMessage);
                writer.WriteLine("After encryption ...");
                writer.WriteLine(requestparams.Value);
                writer.Close();
            }
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "merchantOrderNumber").Value = txtMerchantOrderNumber.Text; 
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "currency").Value = txtCurrency.Text;
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "amount").Value = txtAmount.Text;
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "successUrl").Value = txtSuccessURL.Text;
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "failureUrl").Value = txtFailureURL.Text;
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "transactionType").Value = (drpDwnTransactionType.SelectedValue != "") ? ((drpDwnTransactionType.SelectedValue.ToString() == "SALE") ? "01" : "02") : "";
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "transactionMode").Value = drpDwnTrnMode.SelectedValue;//"INTERNET"
            bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "payModeType").Value = drpDwnPayModeType.SelectedValue;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardNumber").Value = txtCreditCardNumber.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "CVV").Value = txtCVV.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "expMonth").Value = txtExpiryMonth.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "expYear").Value = txtExpiryYear.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardType").Value = txtCardType.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardHolderName").Value = txtCardHolderName.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "custMobileNumber").Value = txtCustMobileNumber.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardToken").Value = txtCardToken.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "OTP").Value = txtOTP.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "paymentID").Value = txtPaymentID.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToFirstName").Value = txtBillToFirstName.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToLastName").Value = txtBillToLastName.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToStreet1").Value = txtBillToStreet1.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToStreet2").Value = txtBillToStreet2.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToCity").Value = txtBillToCity.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToState").Value = txtBillToState.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billtoPostalCode").Value = txtBillToPostalCode.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToCountry").Value = txtBillToCountry.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToEmail").Value = txtBillToEmail.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber1").Value = txtBillToPhoneNumber1.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber2").Value = txtBillToPhoneNumber2.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber3").Value = txtBillToPhoneNumber3.Text;
            bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToMobileNumber").Value = txtBillToMobileNumber.Text;
            bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "gatewayID").Value = txtGatewayID.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "custID").Value = txtCustomerID.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToFirstName").Value = txtShipToFirstName.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToLastName").Value = txtShipToLastName.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToStreet1").Value = txtShipToStreet1.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToStreet2").Value = txtShipToStreet2.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToCity").Value = txtShipToCity.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToState").Value = txtShipToState.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPostalCode").Value = txtShipToPostalCode.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToCountry").Value = txtShipToCountry.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber1").Value = txtShipToPhoneNumber1.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber2").Value = txtShipToPhoneNumber2.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber3").Value = txtShipToPhoneNumber3.Text;
            bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToMobileNumber").Value = txtShipToMobileNumber.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "transactionSource").Value  = txtTransactionSource.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "productInfo").Value = txtProductInfo.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "isUserLoggedIn").Value = txtIsUserLoggedIn.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "itemTotal").Value = txtItemTotal.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "itemCategory").Value = txtItemCategory.Text;
            bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "ignoreValidationResult").Value = txtIgnoreValidationResult.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF1").Value = txtudf1.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF2").Value = txtudf2.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF3").Value = txtudf3.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF4").Value = txtudf4.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF5").Value = txtudf5.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF6").Value = txtudf6.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF7").Value = txtudf7.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF8").Value = txtudf8.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF9").Value = txtudf9.Text;
            bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF10").Value = txtudf10.Text;
            bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "DCCReferenceNumber").Value= txtDccNum.Text;
            bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "foreignAmount").Value = txtFrnAmnt.Text;
            bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "ForeignCurrency").Value= txtFrnCurr.Text;
            bmp.merchantId = txtMerchantID.Text;
            bmp.merchantKey = txtKey.Text;
            Session["bmpObj"] = bmp;
            GenerateString();
        }
        protected void ChkBoxShipping_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkBoxShipping.Checked)
            {
                bmp.blockExistenceIndicator["shippingDataBlock"] = true;
                EnableShippingBlock(true);
                
            }
            else
            {
                bmp.blockExistenceIndicator["shippingDataBlock"] = false;
                EnableShippingBlock(false);
            }
            Session["bmpObj"] = bmp;
        }
        protected void ChkBoxPayment_CheckedChanged(object sender, EventArgs e)
        {
            
            
            if (chkBoxPayment.Checked)
            {
                bmp.blockExistenceIndicator["paymentDataBlock"] = true;
                EnablePaymentBlock(true);
            }
            else
            {
                bmp.blockExistenceIndicator["paymentDataBlock"] = false;
                EnablePaymentBlock(false);
            }
            Session["bmpObj"] = bmp;
        }
        protected void ChkBoxMerchant_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkBoxMerchant.Checked)
            {
                bmp.blockExistenceIndicator["merchantDataBlock"] = true;
                EnableMerchantBlock(true);
            }
            else
            {
                bmp.blockExistenceIndicator["merchantDataBlock"] = false;
                EnableMerchantBlock(false);
            }
            Session["bmpObj"] = bmp;
        }
        protected void ChkBoxOtherData_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkBoxOtherData.Checked)
            {
                bmp.blockExistenceIndicator["otherDataBlock"] = true;
                EnableOtherDataBlock(true);
            }
            else
            {
                bmp.blockExistenceIndicator["otherDataBlock"] = false;
                EnableOtherDataBlock(false);
            }
            Session["bmpObj"] = bmp;
        }
        protected void ChkBoxDccData_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkBoxDccData.Checked)
            {
                bmp.blockExistenceIndicator["DCCDataBlock"] = true;
                EnableDCCBlock(true);
            }
            else
            {
                bmp.blockExistenceIndicator["DCCDataBlock"] = false;
                EnableDCCBlock(false);
            }
            Session["bmpObj"] = bmp;
        }

        protected void EnableShippingBlock(bool status)
        {
            txtShipToFirstName.Enabled = status;
            txtShipToLastName.Enabled = status;
            txtShipToStreet1.Enabled = status;
            txtShipToStreet2.Enabled = status;
            txtShipToCity.Enabled = status;
            txtShipToState.Enabled = status;
            txtShipToPostalCode.Enabled = status;
            txtShipToCountry.Enabled = status;
            txtShipToPhoneNumber1.Enabled = status;
            txtShipToPhoneNumber2.Enabled = status;
            txtShipToPhoneNumber3.Enabled = status;
            txtShipToMobileNumber.Enabled = status;


            txtShipToFirstName.Text = "";
            txtShipToLastName.Text = "";
            txtShipToStreet1.Text = "";
            txtShipToStreet2.Text = "";
            txtShipToCity.Text = "";
            txtShipToState.Text = "";
            txtShipToPostalCode.Text = "";
            txtShipToCountry.Text = "";
            txtShipToPhoneNumber1.Text = "";
            txtShipToPhoneNumber2.Text = "";
            txtShipToPhoneNumber3.Text = "";
            txtShipToMobileNumber.Text = "";

        }
        protected void EnablePaymentBlock(bool status)
        {
            txtCreditCardNumber.Enabled = status;
            txtCVV.Enabled = status;
            txtExpiryMonth.Enabled = status;
            txtExpiryYear.Enabled = status;
            txtCardType.Enabled = status;
            txtCardHolderName.Enabled = status;
            txtCustMobileNumber.Enabled = status;
            txtCardToken.Enabled = status;
            txtOTP.Enabled = status;
            txtPaymentID.Enabled = status;
            txtGatewayID.Enabled = status;

            txtCreditCardNumber.Text = "";
            txtCVV.Text = "";
            txtExpiryMonth.Text = "";
            txtExpiryYear.Text = "";
            txtCardType.Text = "";
            txtCardHolderName.Text = "";
            txtCustMobileNumber.Text = "";
            txtCardToken.Text = "";
            txtOTP.Text = "";
            txtPaymentID.Text = "";
            txtGatewayID.Text = "";
        }
        protected void EnableMerchantBlock(bool status)
        {
            txtudf1.Enabled = status;
            txtudf2.Enabled = status;
            txtudf3.Enabled = status;
            txtudf4.Enabled = status;
            txtudf5.Enabled = status;
            txtudf6.Enabled = status;
            txtudf7.Enabled = status;
            txtudf8.Enabled = status;
            txtudf9.Enabled = status;
            txtudf10.Enabled = status;

            txtudf1.Text = "";
            txtudf2.Text = "";
            txtudf3.Text = "";
            txtudf4.Text = "";
            txtudf5.Text = "";
            txtudf6.Text = "";
            txtudf7.Text = "";
            txtudf8.Text = "";
            txtudf9.Text = "";
            txtudf10.Text = "";
        }
        protected void EnableOtherDataBlock(bool status)
        {
            txtCustomerID.Enabled = status;
            txtTransactionSource.Enabled = status;
            txtProductInfo.Enabled = status;
            txtIsUserLoggedIn.Enabled = status;
            txtItemTotal.Enabled = status;
            txtItemCategory.Enabled = status;
            txtIgnoreValidationResult.Enabled = status;

            txtCustomerID.Text = "";
            txtTransactionSource.Text = "";
            txtProductInfo.Text = "";
            txtIsUserLoggedIn.Text = "";
            txtItemTotal.Text = "";
            txtItemCategory.Text = "";
            txtIgnoreValidationResult.Text = "";
        }
        protected void EnableDCCBlock(bool status)
        {
            txtDccNum.Enabled = status;
            txtFrnAmnt.Enabled = status;
            txtFrnCurr.Enabled = status;

            txtDccNum.Text = "";
            txtFrnAmnt.Text = "";
            txtFrnCurr.Text = "";
        }
        protected void Initialize()
        {
            chkBoxTransaction.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "transactionDataBlock").Value;
            chkBoxTransaction.Enabled = false;
            chkBoxBilling.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "billingDataBlock").Value;
            chkBoxBilling.Enabled = false;
            chkBoxShipping.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "shippingDataBlock").Value;
            chkBoxPayment.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "paymentDataBlock").Value;
            chkBoxMerchant.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "merchantDataBlock").Value;
            chkBoxOtherData.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "otherDataBlock").Value;
            chkBoxDccData.Checked = bmp.blockExistenceIndicator.FirstOrDefault(k => k.Key == "DCCDataBlock").Value;
            txtMerchantOrderNumber.Text = bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "merchantOrderNumber").Value;
            txtCurrency.Text = bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "currency").Value;
            txtAmount.Text = bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "amount").Value;
            txtSuccessURL.Text = bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "successUrl").Value;
            txtFailureURL.Text = bmp.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "failureUrl").Value;
            drpDwnTransactionType.DataSource = tranTypes;
            drpDwnTransactionType.DataBind();
            drpDwnPayModeType.DataSource = payModeTypes;
            drpDwnPayModeType.DataBind();
            drpDwnTrnMode.DataSource = tranMode;
            drpDwnTrnMode.DataBind();
            txtCreditCardNumber.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardNumber").Value;
            txtCVV.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "CVV").Value;
            txtExpiryMonth.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "expMonth").Value;
            txtExpiryYear.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "expYear").Value;
            txtCardType.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardNumber").Value;
            txtCardHolderName.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardHolderName").Value;
            txtCustMobileNumber.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "custMobileNumber").Value;
            txtCardToken.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "cardToken").Value;
            txtOTP.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "OTP").Value;
            txtPaymentID.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "paymentID").Value;
            txtBillToFirstName.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToFirstName").Value;
            txtBillToLastName.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToLastName").Value;
            txtBillToStreet1.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToStreet1").Value;
            txtBillToStreet2.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToStreet2").Value;
            txtBillToCity.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToCity").Value;
            txtBillToState.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToState").Value;
            txtBillToPostalCode.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billtoPostalCode").Value;
            txtBillToCountry.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToCountry").Value;
            txtBillToEmail.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToEmail").Value;
            txtBillToPhoneNumber1.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber1").Value;
            txtBillToPhoneNumber2.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber2").Value;
            txtBillToPhoneNumber3.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToPhoneNumber3").Value;
            txtBillToMobileNumber.Text = bmp.fieldExistenceIndicatorBilling.FirstOrDefault(k => k.Key == "billToMobileNumber").Value;
            txtGatewayID.Text = bmp.fieldExistenceIndicatorPayment.FirstOrDefault(k => k.Key == "gatewayID").Value;
            txtCustomerID.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "custID").Value;
            txtShipToFirstName.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToFirstName").Value;
            txtShipToLastName.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToLastName").Value;
            txtShipToStreet1.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToStreet1").Value;
            txtShipToStreet2.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToStreet2").Value;
            txtShipToCity.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToCity").Value;
            txtShipToState.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToState").Value;
            txtShipToPostalCode.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPostalCode").Value;
            txtShipToCountry.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToCountry").Value;
            txtShipToPhoneNumber1.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber1").Value;
            txtShipToPhoneNumber2.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber2").Value;
            txtShipToPhoneNumber3.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToPhoneNumber3").Value;
            txtShipToMobileNumber.Text = bmp.fieldExistenceIndicatorShipping.FirstOrDefault(k => k.Key == "shipToMobileNumber").Value;
            txtTransactionSource.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "transactionSource").Value;
            txtProductInfo.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "productInfo").Value;
            txtIsUserLoggedIn.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "isUserLoggedIn").Value;
            txtItemTotal.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "itemTotal").Value;
            txtItemCategory.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "itemCategory").Value;
            txtIgnoreValidationResult.Text = bmp.fieldExistenceIndicatorOtherData.FirstOrDefault(k => k.Key == "ignoreValidationResult").Value;
            txtudf1.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF1").Value;
            txtudf2.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF2").Value;
            txtudf3.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF3").Value;
            txtudf4.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF4").Value;
            txtudf5.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF5").Value;
            txtudf6.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF6").Value;
            txtudf7.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF7").Value;
            txtudf8.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF8").Value;
            txtudf9.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF9").Value;
            txtudf10.Text = bmp.fieldExistenceIndicatorMerchant.FirstOrDefault(k => k.Key == "UDF10").Value;
            txtDccNum.Text = bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "DCCReferenceNumber").Value;
            txtFrnAmnt.Text = bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "foreignAmount").Value;
            txtFrnCurr.Text = bmp.fieldExistenceIndicatorDCC.FirstOrDefault(k => k.Key == "ForeignCurrency").Value;

            foreach (KeyValuePair<string, bool> data in bmp.blockExistenceIndicator)
            {
                switch (data.Key)
                {
                        case "shippingDataBlock":
                            EnableShippingBlock(data.Value);
                            break;
                        case "paymentDataBlock":
                            EnablePaymentBlock(data.Value);
                            break;
                        case "merchantDataBlock":
                            EnableMerchantBlock(data.Value);
                            break;
                        case "otherDataBlock":
                            EnableOtherDataBlock(data.Value);
                            break;
                        case "DCCDataBlock":
                            EnableDCCBlock(data.Value);
                            break;

                }
            }

        }
    }
}