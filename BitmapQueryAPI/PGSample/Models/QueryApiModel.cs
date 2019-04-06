using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGSample.Models;
/*
	* 2017 Abzer Technology Solutions  Sample Class for queryApi request string creation
	*  
	*  NOTICE OF LICENSE
	*  File Name : QueryApi.cs 
	*  For creating QueryApi request string
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
    //****************************************************************************************************
    /* This class creates a request string from the data recieved from OrderStatus.aspx page to call the QueryAPi web service*/
   //*****************************************************************************************************
        
    public class QueryApiModel
    {
        //**********************************************************************
        /*Creating proxy class object 'client'  to invoke QuryApi methods*/
        //**********************************************************************

        //ServiceReference1.InvokePMTBitMapWebServiceClient api2 = new ServiceReference1.InvokePMTBitMapWebServiceClient();
        ServiceReferencePMTBitMapWebService_test.InvokePMTBitMapWebServiceClient client = new ServiceReferencePMTBitMapWebService_test.InvokePMTBitMapWebServiceClient();


        public string merchantId = "xxxxxxxxxxxx";
        public string merchantKey = "xxxxxxxxxxxxxxxxxx";
        public string collaboratorId = "NI";
        string dataBlockString = "";
        string blockExistenceIndicatorData = "";
        string fieldExistenceIndicatorTransactionData = "";
        string finalData = "";
        public Dictionary<string, bool> blockExistenceIndicator = new Dictionary<string, bool>();
        public List<KeyValue> fieldExistenceIndicatorTransaction = new List<KeyValue>();


        public QueryApiModel()
        {
            blockExistenceIndicator = new Dictionary<string, bool>();
            blockExistenceIndicator.Add("transactionDataBlock", true);// Transaction Data Block  ==> This is mandatory block 
            fieldExistenceIndicatorTransaction.Add(new KeyValue("ReferenceID", ""));
            fieldExistenceIndicatorTransaction.Add(new KeyValue("merchantOrderNumber", "123456"));
            fieldExistenceIndicatorTransaction.Add(new KeyValue("transactionType", "01"));//default value is 01
        }


        public string Calculate()
        {

            foreach (KeyValuePair<string, bool> data in blockExistenceIndicator)
            {
                switch (data.Key)
                {
                    case "transactionDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorTransaction();
                            finalData += fieldExistenceIndicatorTransactionData + "|" + dataBlockString;
                            dataBlockString = "";
                        }

                        break;
                }
            }
            finalData = finalData.Remove(finalData.Length - 1);
            finalData = blockExistenceIndicatorData + "||" + finalData;
            return finalData;
        }
        public void CalculateFieldExistenceIndicatorTransaction()
        {
            foreach (KeyValue data in fieldExistenceIndicatorTransaction)
            {
                switch (data.Key)
                {
                    case "ReferenceID":
                        fieldExistenceIndicatorTransactionData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                        if (data.Value.Length > 0)
                        {
                            CalculateDataBlock(data.Value);
                        }
                        break;
                    case "merchantOrderNumber":
                        fieldExistenceIndicatorTransactionData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                        if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                        break;

                    case "transactionType":
                        fieldExistenceIndicatorTransactionData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                        if (data.Value.Length > 0)
                        {
                            CalculateDataBlock(data.Value);
                        }
                        break;

                }

            }

        }
        public void CalculateDataBlock(string data)
        {
            dataBlockString += data;
            dataBlockString += "|";

        }

        public string GetOrderStatus(string requestData)
        {
            requestData = merchantId + "||" + collaboratorId + "||" + requestData;

            string msg = client.invokeQueryAPI(requestData);
            return msg;
        }

    }
}