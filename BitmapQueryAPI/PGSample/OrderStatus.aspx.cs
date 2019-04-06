using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ni.dp.util;
using PGSample.Models;
/*
	* 2017 Abzer Technology Solutions  Sample Class For Bitmap 
	*  
	*  NOTICE OF LICENSE
	*  File Name : OrderStatus 
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
    public partial class OrderStatus : System.Web.UI.Page
    {
        public Dictionary<string, bool> block_Existence_Indicator = new Dictionary<string, bool>();
        public List<KeyValue> fieldExistenceIndicatorReference = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorCard = new List<KeyValue>(7);
        public List<KeyValue> fieldExistenceIndicatorStatus = new List<KeyValue>(3);
        public List<KeyValue> fieldExistenceIndicatorMerchant = new List<KeyValue>(10);
        public List<KeyValue> fieldExistenceIndicatorFraud = new List<KeyValue>(2);
        public List<KeyValue> fieldExistenceIndicatorDCC = new List<KeyValue>(5);
        public List<KeyValue> fieldExistenceIndicatorToken = new List<KeyValue>(2);

        QueryApiModel qApi = new QueryApiModel();
        public string merchantId = "";
        public string merchantKey = "";
        string dataWithoutMerchantID = "";
        string blockExistanceField = "";
        string dataWithoutBlockExistenceField = "";
        string[] splittedDataBlock;
        Table table = new Table();
        string[] referenceKeys = { "ReferenceID", "MerchantOrderNumber" };
        string[] currencyKeys = { "Amount", "Currency" };
        string[] statusKeys = { "StatusofTransaction", "TransType", "ErrorCode", "ErrorDescription" };
        string[] merchantKeys = { "PayModeType", "CardType", "CardEnrollmentResponse", "ECI_Values", "Card Number", "Auth Code" };
        string[] fraudKeys = { "FraudDecision", "FraudReason" };
        string[] dccKeys = { "DCC_Converted", "DCC_ConvertedAmount", "DCC_ConvertedCurrency", "DCC_Exchange Rate", "DCC_Margin_Rate" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["qApi"] = null;
                txtReferenceNUmber.Text = qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "ReferenceID").Value;
                txtOrderNUmber.Text = qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "merchantOrderNumber").Value;
                txtTransactionType.Text = qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "transactionType").Value;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "ReferenceID").Value = txtReferenceNUmber.Text;
            qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "merchantOrderNumber").Value = txtOrderNUmber.Text;
            qApi.fieldExistenceIndicatorTransaction.FirstOrDefault(k => k.Key == "transactionType").Value = txtTransactionType.Text;

            string encryptedMsg = qApi.GetOrderStatus(new EncDec().Encrypt(qApi.merchantKey, qApi.Calculate()));
            string decryptedMsg = EncDec.Decrypt(qApi.merchantKey, encryptedMsg);
            txtResult.Text = decryptedMsg;
            Calculate(decryptedMsg);
        }

        public void Calculate(string decryptedMsg)
        {
            dataWithoutMerchantID = decryptedMsg;

            blockExistanceField = dataWithoutMerchantID.Substring(0, dataWithoutMerchantID.IndexOf("||", 0));
            dataWithoutBlockExistenceField = dataWithoutMerchantID.Substring(dataWithoutMerchantID.IndexOf("||", 0) + 2);
            splittedDataBlock = dataWithoutBlockExistenceField.Split(new[] { "||" }, StringSplitOptions.None);
            char[] charArr = blockExistanceField.ToCharArray();
            for (int i = 0, j = 0; i < charArr.Length; i++)
            {

                switch (i)
                {
                    case 0:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], referenceKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                    case 1:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], currencyKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                    case 2:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], statusKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                    case 3:
                        {
                            if (charArr[i] == '1')
                            {
                                 DecodeFields(splittedDataBlock[j], merchantKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                    case 4:
                        {
                            if (charArr[i] == '1')
                            {
                                dataWithoutBlockExistenceField = dataWithoutBlockExistenceField.Substring(dataWithoutBlockExistenceField.IndexOf("||", 0) + 2);
                                DecodeFields(splittedDataBlock[j], fraudKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                    case 5:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], dccKeys);
                                j++;
                            }
                            else
                                continue;
 
                        }
                        break;
                    
                }
            }


        }
        public void DecodeFields(string data, string[] keyArray)
        {

            List<KeyValue> valuesDecrypted = new List<KeyValue>();

            String fieldExistenceBlock = data.Substring(0, data.IndexOf("|", 0));
            char[] charArr = fieldExistenceBlock.ToCharArray();
            string[] fieldData;

            fieldData = data.Substring(data.IndexOf("|", 0) + 1).Split(new[] { "|" }, StringSplitOptions.None);
            int j = 0;
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i].ToString().Equals("1"))
                {
                    valuesDecrypted.Add(new KeyValue(keyArray[i], fieldData[j]));
                    j++;
                }
                else
                {
                    valuesDecrypted.Add(new KeyValue(keyArray[i], ""));
                }

            }
            table.CssClass = "table";
            div1.Controls.Add(table);
            int swap = 0;
 //*****************************************************************************************************
            /* Creating Dynamic table for dispaying decoded response string */
 //*****************************************************************************************************
            foreach (KeyValue a in valuesDecrypted)
            {

                
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                tr.CssClass = (++swap % 2 == 0) ? "trEven" : "trOdd";
                Label dynamic = new Label();
                table.Controls.Add(tr);
                tr.Controls.Add(td);
                dynamic.Text = a.Key;
                td.Controls.Add(dynamic);
                dynamic = new Label();
                td = new TableCell();
                tr.Controls.Add(td);
                dynamic.Text = a.Value;
                td.Controls.Add(dynamic);
            }
        }
    }
}