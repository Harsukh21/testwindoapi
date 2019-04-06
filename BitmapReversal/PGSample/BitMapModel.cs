using PGSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGSample
{
    public class BitMapModel
    {
        /*Block declaration*/

        public Dictionary<string, bool> block_Existence_Indicator = new Dictionary<string, bool>();
        public List<KeyValue> field_Existence_Indicator_Transaction = new List<KeyValue>();
        public Dictionary<string, string>[] field_Existence_Indicator_Billing = new Dictionary<string, string>[13];
        public Dictionary<string, string>[] field_Existence_Indicator_Shipping = new Dictionary<string, string>[12];
        public Dictionary<string, string>[] field_Existence_Indicator_Payment = new Dictionary<string, string>[11];
        public Dictionary<string, string>[] field_Existence_Indicator_Merchant = new Dictionary<string, string>[10];
        public Dictionary<string, string>[] field_Existence_Indicator_OtherData = new Dictionary<string, string>[7];
        public Dictionary<string, string>[] field_Existence_Indicator_DCC = new Dictionary<string, string>[3];

        string dataBlockString = "";
        string blockExistenceIndicatorData = "";
        string fieldExistenceIndicatorTransactionData = "";
        string fieldExistenceIndicatorBillingData = "";
        string fieldExistenceIndicatorShippingData = "";
        string fieldExistenceIndicatorPaymentData = "";
        string fieldExistenceIndicatorMerchantData = "";
        string fieldExistenceIndicatorOtherDataData = "";
        string fieldExistenceIndicatorDCCData = "";
        string finalData = "";

        // Properties for future Extensions  

        public string encryptMethod = "MCRYPT_RIJNDAEL_128";
        public string encryptMode = "MCRYPT_MODE_CBC";
        public string merchantId = "";
        public string merchantKey = "";
        public string iv = "";
        public string collaboratorId = "";
        public string url = "";
        //public string[] payModeTypeCard = new string[] { "CC", "DC", "DD" };
        //public string[] payModeTypeNetBank = new string[] { "NB" };


        //Block Initialization using constructor

        public BitMapModel()
        {
            field_Existence_Indicator_Billing[0] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[1] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[2] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[3] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[4] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[5] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[6] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[7] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[8] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[9] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[10] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[11] = new Dictionary<string, string>();
            field_Existence_Indicator_Billing[12] = new Dictionary<string, string>();


            field_Existence_Indicator_Shipping[0] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[1] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[2] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[3] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[4] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[5] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[6] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[7] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[8] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[9] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[10] = new Dictionary<string, string>();
            field_Existence_Indicator_Shipping[11] = new Dictionary<string, string>();


            field_Existence_Indicator_Payment[0] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[1] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[2] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[3] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[4] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[5] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[6] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[7] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[8] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[9] = new Dictionary<string, string>();
            field_Existence_Indicator_Payment[10] = new Dictionary<string, string>();


            field_Existence_Indicator_Merchant[0] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[1] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[2] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[3] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[4] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[5] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[6] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[7] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[8] = new Dictionary<string, string>();
            field_Existence_Indicator_Merchant[9] = new Dictionary<string, string>();


            field_Existence_Indicator_OtherData[0] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[1] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[2] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[3] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[4] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[5] = new Dictionary<string, string>();
            field_Existence_Indicator_OtherData[6] = new Dictionary<string, string>();


            field_Existence_Indicator_DCC[0] = new Dictionary<string, string>();
            field_Existence_Indicator_DCC[1] = new Dictionary<string, string>();
            field_Existence_Indicator_DCC[2] = new Dictionary<string, string>();


            // Sample Data  for all the blocks


            //block_Existence_Indicator 


            block_Existence_Indicator.Add("transactionDataBlock", true); // Transaction Data Block  ==> This is mandatory block  , 1
            block_Existence_Indicator.Add("billingDataBlock", true);     // Billing Data Block      ==> This is an optional block ,0 
            block_Existence_Indicator.Add("shippingDataBlock", false);    // Shipping Data Block     ==> This is an optional block ,0 
            block_Existence_Indicator.Add("paymentDataBlock", true);    // Payment Data Block      ==> This is mandatory block , 1 if you are using Merchant hosted Payment , else 0 
            block_Existence_Indicator.Add("merchantDataBlock", false);  // Merchant Data Block     ==> This is an optional block ,0
            block_Existence_Indicator.Add("otherDataBlock", false);       // Other Details Data Block==> This is an optional block ,0 
            block_Existence_Indicator.Add("DCCDataBlock", false);        // DCC Data Block          ==> This is an optional block ,0

            // Total Seven blocks so the Block Existence Indicator Bitmap will be : 1001000 
            // If you are selecting the Billing Data Block the Bitmap indicator will be : 1101000
            // If you are selecting the Shipping Data Block the Bitmap indicator will be :1111000

            /// Define the Field Existence Indicator for the Transaction Data Block, All the fields are mandatory *



            //field_Existence_Indicator_Transaction

            field_Existence_Indicator_Transaction.Add(new KeyValue("merchantOrderNumber", DateTime.Now.ToString("MMddyyyyHHmmss")));   // Merchant Order Number :  Unique identifier of the merchant , Like order id , cart id , pay id etc.. As of now we are passing unique timestamp
            field_Existence_Indicator_Transaction.Add(new KeyValue("amount", "100.00"));                                               // Amount 
            field_Existence_Indicator_Transaction.Add(new KeyValue("successUrl", "http://localhost:52630/ResponseSuccess.aspx"));      // Add your sucess URL 
            field_Existence_Indicator_Transaction.Add(new KeyValue("failureUrl", "http://localhost:52630/ResponseFailure.aspx"));      // Add your failure URL 
            field_Existence_Indicator_Transaction.Add(new KeyValue("transactionMode", "INTERNET"));                                    // Transaction Mode  ( Internet, Moto, or Recurring) Default Value Internet
            field_Existence_Indicator_Transaction.Add(new KeyValue("payModeType", "CC"));                                              // (CC)-Credit Card, (DC)-Debit Card, (DD)-Direct Debit, (PAYPAL)-PayPal, (NB)-Net Banking . Note: This field is required for ‘Merchant Hosted’ type of integration.
            field_Existence_Indicator_Transaction.Add(new KeyValue("transactionType", "01"));                                          // 01 for SALE 02 for AUTHORIZATION
            field_Existence_Indicator_Transaction.Add(new KeyValue("currency", "AED"));                                                // AED  Used to specify the currency for the transaction. Currently, only AED is accepted for all transactions (as per ISO Currency Code).

            // Define the Field Existence Indicator for the Billing Data Block , These are optional values 
            //Data for field_Existence_Indicator_Billing

            field_Existence_Indicator_Billing[0].Add("billToFirstName", "Soloman");     // 1. BillToFirstName Optional value  
            field_Existence_Indicator_Billing[1].Add("billToLastName", "Vandy");        // 2. BillToLastName  Optional value
            field_Existence_Indicator_Billing[2].Add("billToStreet1", "123,ParkStreet");// 3. BillToStreet1   Optional value
            field_Existence_Indicator_Billing[3].Add("billToStreet2", "Park Street");   // 4. BillToStreet2   Optional value
            field_Existence_Indicator_Billing[4].Add("billToCity", "Mumbai");           // 5. BillToCity      Optional value
            field_Existence_Indicator_Billing[5].Add("billToState", "Maharashtra");     // 6. BillToState 	 Optional value
            field_Existence_Indicator_Billing[6].Add("billtoPostalCode", "400081");     // 7. BillToPostalCode Optional value
            field_Existence_Indicator_Billing[7].Add("billToCountry", "IN");            // 8. BillToCountry   Optional value
            field_Existence_Indicator_Billing[8].Add("billToEmail", "solomanv@test.com");// 9. BillToEmailID   Optional value
            field_Existence_Indicator_Billing[9].Add("billToMobileNumber", "9820998209");// 10. BillToMobileNumber Optional value
            field_Existence_Indicator_Billing[10].Add("billToPhoneNumber1", "");        // 11. BillToPhoneNumber1 Optional value
            field_Existence_Indicator_Billing[11].Add("billToPhoneNumber2", "");        // 12. BillToPhoneNumber2 Optional value
            field_Existence_Indicator_Billing[12].Add("billToPhoneNumber3", "");        // 13. BillToPhoneNumber2 Optional value

            // Define the Field Existence Indicator for the Shipping Data Block , These are optional values
            //Data for field_Existence_Indicator_Shipping

            field_Existence_Indicator_Shipping[0].Add("shipToFirstName", "Soloman");    // 1. ShipToFirstName Optional value
            field_Existence_Indicator_Shipping[1].Add("shipToLastName", "Vandy");       // 2. ShipToLastName Optional value
            field_Existence_Indicator_Shipping[2].Add("shipToStreet1", "123ParkStreet");// 3. ShipToStreet1 Optional value
            field_Existence_Indicator_Shipping[3].Add("shipToStreet2", "parkstreet");   // 4. ShipToStreet2 Optional value
            field_Existence_Indicator_Shipping[4].Add("shipToCity", "Mumbai");          // 5. ShipToCity Optional value
            field_Existence_Indicator_Shipping[5].Add("shipToState", "Maharashtra");    // 6. ShipToState Optional value
            field_Existence_Indicator_Shipping[6].Add("shipToPostalCode", "400081");    // 7. ShipToPostalCode Optional value
            field_Existence_Indicator_Shipping[7].Add("shipToCountry", "IN");           // 8. ShipToCountry Optional value
            field_Existence_Indicator_Shipping[8].Add("shipToPhoneNumber1", "");        // 9. ShipToPhoneNumber1 Optional value
            field_Existence_Indicator_Shipping[9].Add("shipToPhoneNumber2", "");        // 10. ShipToPhoneNumber2 Optional value
            field_Existence_Indicator_Shipping[10].Add("shipToPhoneNumber3", "");       // 11. ShipToPhoneNumber3 Optional value
            field_Existence_Indicator_Shipping[11].Add("shipToMobileNumber", "9820998209");// 12. ShipToMobileNumber Optional value


            /*
			In case of a credit card transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 11111111111|4111111111111111|08|2022|123|Soloman|Visa|9820998209|123456|123456|1026|1202
			In case of a Net Banking transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 00000000010|1001 // Here we need Gateway ID 
			In case of an IMPS transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 00000011100|9820998209|123456|123456	// Here we need Customer Mobile Number, Payment ID , OTP  
			*/

            // Define the Field Existence Indicator for the Payment Data Block , These are optional values 
            //Data for field_Existence_Indicator_Payment

            field_Existence_Indicator_Payment[0].Add("cardNumber", "4111111111111111"); // 1. Card Number 
            field_Existence_Indicator_Payment[1].Add("expMonth", "08");                 // 2. Expiry Month 
            field_Existence_Indicator_Payment[2].Add("expYear", "2020");                // 3. Expiry Year
            field_Existence_Indicator_Payment[3].Add("CVV", "123");                     // 4. CVV  
            field_Existence_Indicator_Payment[4].Add("cardHolderName", "Soloman");      // 5. Card Holder Name 
            field_Existence_Indicator_Payment[5].Add("cardType", "Visa");               // 6. Card Type
            field_Existence_Indicator_Payment[6].Add("custMobileNumber", "9820998209"); // 7. Customer Mobile Number
            field_Existence_Indicator_Payment[7].Add("paymentID", "123456");            // 8. Payment ID 
            field_Existence_Indicator_Payment[8].Add("OTP", "123456");                  // 9. OTP field
            field_Existence_Indicator_Payment[9].Add("gatewayID", "1026");              // 10.Gateway ID
            field_Existence_Indicator_Payment[10].Add("cardToken", "1202");             // 11.Card Token 

            // Define the Field Existence Indicator for the Merchant Data Block , These are optional values 
            // Data for field_Existence_Indicator_Merchant
            field_Existence_Indicator_Merchant[0].Add("UDF1", "115.121.181.112"); // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[1].Add("UDF2", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[2].Add("UDF3", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[3].Add("UDF4", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[4].Add("UDF5", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[5].Add("UDF6", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[6].Add("UDF7", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[7].Add("UDF8", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[8].Add("UDF9", "abc");             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            field_Existence_Indicator_Merchant[9].Add("UDF10", "abc");            // This is a ‘user-defined field’ that can be used to send additional information about the transaction.	

            // Define the Field Existence Indicator for the Other Details Data Block , These are optional values	
            //block_Existence_Indicator 

            field_Existence_Indicator_OtherData[0].Add("custID", "9874513");    // The ID used to identify your customer when their profile was created. This field has to be passed by you only if you have opted for the ‘Tokenization/Stored Card’ feature.
                                                                                //The field is ‘alphanumeric’; special characters are not allowed.
            field_Existence_Indicator_OtherData[1].Add("transactionSource", "Web");// This is used to identify a channel, in case you are using multiple channels.
                                                                                   //Acceptable values are: Web, IVR, or Mobile.
            field_Existence_Indicator_OtherData[2].Add("productInfo", "Book");  // This field is used to send details about the product and related information.
            field_Existence_Indicator_OtherData[3].Add("isUserLoggedIn", "Y");  // Indicates whether a customer has signed in to your website, or has done a Guest checkout Values: ‘Y’ – customer has signed in
                                                                                //‘N’ – customer has done a Guest checkout
            field_Existence_Indicator_OtherData[4].Add("itemTotal", "100.00");  // This is a comma-separated list of the sale value of all the items in the order.
                                                                                //Example: If the order has two items of value 500 and 1000, send the value as ‘500.00, 1000.00’. Up to 2 decimal places are allowed in the value.
            field_Existence_Indicator_OtherData[5].Add("itemCategory", "CD, Book");// This is a comma-separated list of the categories of all the items in the order.
            field_Existence_Indicator_OtherData[6].Add("ignoreValidationResult", "FALSE");// Indicates whether you want to proceed for Authorization irrespective of the 3DSecure/Authentication result, or not. TRUE/FALSE

            //Data for field_Existence_Indicator_DCC

            field_Existence_Indicator_DCC[0].Add("DCCReferenceNumber", "09898787"); // DCC Reference Number
            field_Existence_Indicator_DCC[1].Add("foreignAmount", "240.00"); // Foreign Amount
            field_Existence_Indicator_DCC[2].Add("ForeignCurrency", "USD");  // Foreign Currency
        }

        // Block existence calculator - ex:  creates a sequence like 1110010 
        //----------------------------------------------------------------------------------------------------------------------------
        public string Calculate()
        {
            foreach (KeyValuePair<string, bool> data in block_Existence_Indicator)
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
                    case "billingDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorBillingDataBlock();
                            finalData += "|" + fieldExistenceIndicatorBillingData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;
                    case "shippingDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorShippingDataBlock();
                            finalData += "|" + fieldExistenceIndicatorShippingData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;
                    case "paymentDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorPaymentDataBlock();
                            finalData += "|" + fieldExistenceIndicatorPaymentData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;
                    case "merchantDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorMerchantDataBlock();
                            finalData += "|" + fieldExistenceIndicatorMerchantData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;
                    case "otherDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorOtherDataBlock();
                            finalData += "|" + fieldExistenceIndicatorOtherDataData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;
                    case "DCCDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorDCCDataBlock();
                            finalData += "|" + fieldExistenceIndicatorDCCData + "|" + dataBlockString;
                            dataBlockString = "";
                        }
                        break;

                }



            }
            finalData = finalData.Remove(finalData.Length - 1);
            finalData = blockExistenceIndicatorData + "||" + finalData;
            return finalData;
        }

        //----------------------------------------------------------------------------------------------------------------------------

        //Field Existence calculator


        /*Transcation Field Existence Block		 */  //creates a patternd like 11111111 depending on Fields present in transaction block
        public void CalculateFieldExistenceIndicatorTransaction()
        {
            foreach (KeyValue data in field_Existence_Indicator_Transaction)
            {
                fieldExistenceIndicatorTransactionData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }
        }


        /*Billing Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Billing block

        public void CalculateFieldExistenceIndicatorBillingDataBlock()
        {

            for (int i = 0; i < field_Existence_Indicator_Billing.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_Billing[i])
                {
                    switch (data.Key)
                    {
                        case "billToFirstName":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "billToLastName":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToStreet1":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToStreet2":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToCity":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToState":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billtoPostalCode":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToCountry":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToEmail":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToMobileNumber":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToPhoneNumber1":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToPhoneNumber2":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "billToPhoneNumber3":
                            fieldExistenceIndicatorBillingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                    }

                }
            }

        }

        /*Shipping Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Shipping block
        public void CalculateFieldExistenceIndicatorShippingDataBlock()
        {

            for (int i = 0; i < field_Existence_Indicator_Shipping.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_Shipping[i])
                {
                    switch (data.Key)
                    {
                        case "shipToFirstName":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "shipToLastName":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToStreet1":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToStreet2":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToCity":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToState":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToPostalCode":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToCountry":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToPhoneNumber1":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToPhoneNumber2":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToPhoneNumber3":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "shipToMobileNumber":
                            fieldExistenceIndicatorShippingData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                    }

                }
            }

        }

        /*Payment Field Existence Block		 */  //creates a patternd like 11111111 depending on Fields present in payment block
        public void CalculateFieldExistenceIndicatorPaymentDataBlock()
        {

            for (int i = 0; i < field_Existence_Indicator_Payment.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_Payment[i])
                {
                    switch (data.Key)
                    {
                        case "cardNumber":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "expMonth":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "expYear":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "CVV":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "cardHolderName":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "cardType":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "custMobileNumber":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "paymentID":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "OTP":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "gatewayID":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "cardToken":
                            fieldExistenceIndicatorPaymentData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;

                    }

                }
            }

        }

        /*Merchant Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Merchand block

        public void CalculateFieldExistenceIndicatorMerchantDataBlock()
        {

            for (int i = 0; i < field_Existence_Indicator_Merchant.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_Merchant[i])
                {
                    switch (data.Key)
                    {
                        case "UDF1":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "UDF2":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF3":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF4":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF5":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF6":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF7":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF8":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF9":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "UDF10":
                            fieldExistenceIndicatorMerchantData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                    }

                }
            }

        }

        /*OtherData Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in OtherData block

        public void CalculateFieldExistenceIndicatorOtherDataBlock()
        {

            for (int i = 0; i < field_Existence_Indicator_OtherData.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_OtherData[i])
                {
                    switch (data.Key)
                    {
                        case "custID":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "transactionSource":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "productInfo":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "isUserLoggedIn":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "itemTotal":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "itemCategory":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "ignoreValidationResult":
                            fieldExistenceIndicatorOtherDataData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;

                    }

                }
            }

        }

        /*DCC Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in DCC block

        public void CalculateFieldExistenceIndicatorDCCDataBlock()
        {


            for (int i = 0; i < field_Existence_Indicator_DCC.Length; i++)
            {
                foreach (KeyValuePair<string, string> data in field_Existence_Indicator_DCC[i])
                {
                    switch (data.Key)
                    {
                        case "DCCReferenceNumber":
                            fieldExistenceIndicatorDCCData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0) { CalculateDataBlock(data.Value); }
                            break;
                        case "foreignAmount":
                            fieldExistenceIndicatorDCCData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;
                        case "ForeignCurrency":
                            fieldExistenceIndicatorDCCData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                            if (data.Value.Length > 0)
                            {
                                CalculateDataBlock(data.Value);
                            }
                            break;

                    }

                }
            }

        }

        //All the Data blocks are constructed here depending on the argument passed from the Field existence block 
        // Ex: 06082017124407|100.00|http://localhost:52630/ResponseSuccess.aspx|http://localhost:52630/ResponseFailure.aspx|INTERNET|CC|01|AED||
        public void CalculateDataBlock(string data)
        {
            dataBlockString += data;
            dataBlockString += "|";

        }

    }
}