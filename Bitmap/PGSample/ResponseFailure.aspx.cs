using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ni.dp.util;
using PGSample.Models;

/*
	* 2017 Abzer Technology Solutions  Sample Class for Repsonse decoding 
	*  
	*  NOTICE OF LICENSE
	*  File Name : ResponseFailure 
	*  For decoding and displaying reponse string
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

    public partial class ResponseFailure : System.Web.UI.Page
    {
        BitMapModel bmp;
        string[] splittedDataBlock;
        string responseparams1;
        public string merchantId = "";
        public string merchantKey = "";
        string dataWithoutMerchantID = "";
        string blockExistanceField = "";
        string dataWithoutBlockExistenceField = "";     
        Table table = new Table();
        public Dictionary<string, bool> blockExistenceIndicator = new Dictionary<string, bool>();
        public List<KeyValue> fieldExistenceIndicatorPayment = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorCard = new List<KeyValue>(7);
        public List<KeyValue> fieldExistenceIndicatorStatus = new List<KeyValue>(3);
        public List<KeyValue> fieldExistenceIndicatorMerchant = new List<KeyValue>(10);
        public List<KeyValue> fieldExistenceIndicatorFraud = new List<KeyValue>(2);
        public List<KeyValue> fieldExistenceIndicatorDCC = new List<KeyValue>(5);
        public List<KeyValue> fieldExistenceIndicatorToken = new List<KeyValue>(2);
        string[] paymentKeys = { "MerchantOrderNo", "Currency", "Amount", "PayMode", "CardType", "TransactionType" };
        string[] cardKeys = { "ReferenceNumber", "TxnDate", "CardEnrollmentResponse", "EciIndicator", "GtwTraceNo", "GtwIdentifier", "AuthCode" };
        string[] statusKeys = { "StatusFlag", "ErrorCode", "ErrorMessage" };
        string[] merchantKeys = { "udf1", "udf2", "udf3", "udf4", "udf5", "udf6", "udf7", "udf8", "udf9", "udf10" };
        string[] fraudKeys = { "frauddecision", "fraudreason" };
        string[] dccKeys = { "DCCConverted", "DCCConverted Amount", "DCC Currency", "DCCMargin", "DCCExchangeRate" };
        string[] tokenKeys = { "CardToken", "CardNumber" };    

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            bmp = (BitMapModel)Session["bmpObj"];
            string key = bmp.merchantKey;
            string strMessage = Request["responseParameter"];
            string path = Server.MapPath("~/log/responseLog.txt");
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
            {
                writer.WriteLine(strMessage);
                writer.Close();
            }
            responseparams1 = EncDec.Decrypt(key, strMessage.Substring(strMessage.IndexOf("||", 0) + 2));
            Table table = new Table();
            dataWithoutMerchantID = responseparams1;
            blockExistanceField = dataWithoutMerchantID.Substring(0, dataWithoutMerchantID.IndexOf("||", 0));
            dataWithoutBlockExistenceField = dataWithoutMerchantID.Substring(dataWithoutMerchantID.IndexOf("||", 0) + 2);
            splittedDataBlock = dataWithoutBlockExistenceField.Split(new[] { "||" }, StringSplitOptions.None);
            char[] charArr = blockExistanceField.ToCharArray();


  //*****************************************************************************************************
            /* calls Decode method for each data block fetched using blockExistanceField*/
  //*****************************************************************************************************
            
            for (int i = 0,j=0; i < charArr.Length; i++)
            {

                switch (i)
                {
                    case 0:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], paymentKeys);
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
                                dataWithoutBlockExistenceField = dataWithoutBlockExistenceField.Substring(dataWithoutBlockExistenceField.IndexOf("||", 0) + 2);
                                DecodeFields(splittedDataBlock[j], cardKeys);
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
                                dataWithoutBlockExistenceField = dataWithoutBlockExistenceField.Substring(dataWithoutBlockExistenceField.IndexOf("||", 0) + 2);
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
                    case 6:
                        {
                            if (charArr[i] == '1')
                            {
                                DecodeFields(splittedDataBlock[j], tokenKeys);
                                j++;
                            }
                            else
                                continue;
                        }
                        break;
                }

            }
        }

  //*****************************************************************************************************
        /* Intialize method  fills the Data blocks with default values to Decode the response text reveived from the payment gateway*/
  //*****************************************************************************************************
        public void Initialize()
        {
            fieldExistenceIndicatorPayment.Add(new KeyValue("MerchantOrderNo", ""));
            fieldExistenceIndicatorPayment.Add(new KeyValue("Currency", ""));
            fieldExistenceIndicatorPayment.Add(new KeyValue("Amount", ""));
            fieldExistenceIndicatorPayment.Add(new KeyValue("PayMode", ""));
            fieldExistenceIndicatorPayment.Add(new KeyValue("CardType", ""));
            fieldExistenceIndicatorPayment.Add(new KeyValue("TransactionType", ""));
            fieldExistenceIndicatorStatus.Add(new KeyValue("StatusFlag", ""));
            fieldExistenceIndicatorStatus.Add(new KeyValue("ErrorCode", ""));
            fieldExistenceIndicatorStatus.Add(new KeyValue("ErrorMessage", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf1", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf2", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf3", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf4", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf5", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf6", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf7", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf8", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf9", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf10", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf11", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf12", ""));
            fieldExistenceIndicatorMerchant.Add(new KeyValue("udf13", ""));
            fieldExistenceIndicatorFraud.Add(new KeyValue("frauddecision", ""));
            fieldExistenceIndicatorFraud.Add(new KeyValue("fraudreason", ""));
            fieldExistenceIndicatorDCC.Add(new KeyValue("DCCConverted", ""));
            fieldExistenceIndicatorDCC.Add(new KeyValue("DCCConverted Amount", ""));
            fieldExistenceIndicatorDCC.Add(new KeyValue("DCC Currency", ""));
            fieldExistenceIndicatorDCC.Add(new KeyValue("DCCMargin", ""));
            fieldExistenceIndicatorDCC.Add(new KeyValue("DCCExchangeRate", ""));
            fieldExistenceIndicatorToken.Add(new KeyValue("CardToken", ""));
            fieldExistenceIndicatorToken.Add(new KeyValue("CardNumber", ""));
        }

 //*****************************************************************************************************
        /* Decodes the Data blocks using KeyArray(string Array containing Keys ) */
 //*****************************************************************************************************

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
