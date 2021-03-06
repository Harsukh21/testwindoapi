﻿using PGSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
	* 2017 Abzer Technology Solutions  Sample Class for Bitmap request string creation
	*  
	*  NOTICE OF LICENSE
	*  File Name : BitMapModel.cs 
	*  For creating Bitmap request string
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
    public class BitMapModel
    {
        /*Block declaration*/

        public Dictionary<string, bool> blockExistenceIndicator = new Dictionary<string, bool>();
        public List<KeyValue> fieldExistenceIndicatorTransaction = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorBilling = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorShipping = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorPayment = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorMerchant = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorOtherData = new List<KeyValue>();
        public List<KeyValue> fieldExistenceIndicatorDCC = new List<KeyValue>();

        string dataBlockString = "";
        string blockExistenceIndicatorData = "";
        string fieldExistenceIndicatorData = "";
        string finalData = "";

        // Properties for future Extensions  

        public string encryptMethod = "MCRYPT_RIJNDAEL_128";
        public string encryptMode = "MCRYPT_MODE_CBC";
        public string merchantId = "";
        public string merchantKey = "";
        public string iv = "";
        public string collaboratorId = "NI";
        public string url = "";
        //public string[] payModeTypeCard = new string[] { "CC", "DC", "DD" };
        //public string[] payModeTypeNetBank = new string[] { "NB" };


        //Block Initialization using constructor

        public BitMapModel()
        {
            // Sample Data  for all the blocks

            //blockExistenceIndicator 
            blockExistenceIndicator.Add("transactionDataBlock", true); // Transaction Data Block  ==> This is mandatory block  , 1
            blockExistenceIndicator.Add("billingDataBlock", true);     // Billing Data Block      ==> This is an optional block ,0 
            blockExistenceIndicator.Add("shippingDataBlock", false);    // Shipping Data Block     ==> This is an optional block ,0 
            blockExistenceIndicator.Add("paymentDataBlock", false);    // Payment Data Block      ==> This is mandatory block , 1 if you are using Merchant hosted Payment , else 0 
            blockExistenceIndicator.Add("merchantDataBlock", false);  // Merchant Data Block     ==> This is an optional block ,0
            blockExistenceIndicator.Add("otherDataBlock", false);       // Other Details Data Block==> This is an optional block ,0 
            blockExistenceIndicator.Add("DCCDataBlock", false);        // DCC Data Block          ==> This is an optional block ,0

            // Total Seven blocks so the Block Existence Indicator Bitmap will be : 1001000 
            // If you are selecting the Billing Data Block the Bitmap indicator will be : 1101000
            // If you are selecting the Shipping Data Block the Bitmap indicator will be :1111000

            /// Define the Field Existence Indicator for the Transaction Data Block, All the fields are mandatory *


            //fieldExistenceIndicatorTransaction

            fieldExistenceIndicatorTransaction.Add(new KeyValue("merchantOrderNumber", DateTime.Now.ToString("MMddyyyyHHmmss")));   // Merchant Order Number :  Unique identifier of the merchant , Like order id , cart id , pay id etc.. As of now we are passing unique timestamp
            fieldExistenceIndicatorTransaction.Add(new KeyValue("amount", "100.00"));                                               // Amount 
            fieldExistenceIndicatorTransaction.Add(new KeyValue("successUrl", "http://localhost:52630/ResponseSuccess.aspx"));      // Add your sucess URL 
            fieldExistenceIndicatorTransaction.Add(new KeyValue("failureUrl", "http://localhost:52630/ResponseFailure.aspx"));      // Add your failure URL 
            fieldExistenceIndicatorTransaction.Add(new KeyValue("transactionMode", "INTERNET"));                                    // Transaction Mode  ( Internet, Moto, or Recurring) Default Value Internet
            fieldExistenceIndicatorTransaction.Add(new KeyValue("payModeType", "CC"));                                              // (CC)-Credit Card, (DC)-Debit Card, (DD)-Direct Debit, (PAYPAL)-PayPal, (NB)-Net Banking . Note: This field is required for ‘Merchant Hosted’ type of integration.
            fieldExistenceIndicatorTransaction.Add(new KeyValue("transactionType", "01"));                                          // 01 for SALE 02 for AUTHORIZATION
            fieldExistenceIndicatorTransaction.Add(new KeyValue("currency", "AED"));                                                // AED  Used to specify the currency for the transaction. Currently, only AED is accepted for all transactions (as per ISO Currency Code).

            // Define the Field Existence Indicator for the Billing Data Block , These are optional values 
            //Data for fieldExistenceIndicatorBilling

            fieldExistenceIndicatorBilling.Add(new KeyValue("billToFirstName", "Soloman"));     // 1. BillToFirstName Optional value  
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToLastName", "Vandy"));        // 2. BillToLastName  Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToStreet1", "123,ParkStreet"));// 3. BillToStreet1   Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToStreet2", "Park Street"));   // 4. BillToStreet2   Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToCity", "Mumbai"));           // 5. BillToCity      Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToState", "Maharashtra"));     // 6. BillToState 	 Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billtoPostalCode", "400081"));     // 7. BillToPostalCode Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToCountry", "IN"));            // 8. BillToCountry   Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToEmail", "solomanv@test.com"));// 9. BillToEmailID   Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToMobileNumber", "9820998209"));// 10. BillToMobileNumber Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToPhoneNumber1", ""));        // 11. BillToPhoneNumber1 Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToPhoneNumber2", ""));        // 12. BillToPhoneNumber2 Optional value
            fieldExistenceIndicatorBilling.Add(new KeyValue("billToPhoneNumber3", ""));        // 13. BillToPhoneNumber2 Optional value

            // Define the Field Existence Indicator for the Shipping Data Block , These are optional values
            //Data for fieldExistenceIndicatorShipping

            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToFirstName", "Soloman"));    // 1. ShipToFirstName Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToLastName", "Vandy"));       // 2. ShipToLastName Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToStreet1", "123ParkStreet"));// 3. ShipToStreet1 Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToStreet2", "parkstreet"));   // 4. ShipToStreet2 Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToCity", "Mumbai"));          // 5. ShipToCity Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToState", "Maharashtra"));    // 6. ShipToState Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToPostalCode", "400081"));    // 7. ShipToPostalCode Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToCountry", "IN"));           // 8. ShipToCountry Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToPhoneNumber1", ""));        // 9. ShipToPhoneNumber1 Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToPhoneNumber2", ""));        // 10. ShipToPhoneNumber2 Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToPhoneNumber3", ""));       // 11. ShipToPhoneNumber3 Optional value
            fieldExistenceIndicatorShipping.Add(new KeyValue("shipToMobileNumber", "9820998209"));// 12. ShipToMobileNumber Optional value


            /*
			In case of a credit card transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 11111111111|4111111111111111|08|2022|123|Soloman|Visa|9820998209|123456|123456|1026|1202
			In case of a Net Banking transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 00000000010|1001 // Here we need Gateway ID 
			In case of an IMPS transaction, the Payment Data Block formation will be as follows:
			paymentDataBlock = 00000011100|9820998209|123456|123456	// Here we need Customer Mobile Number, Payment ID , OTP  
			*/

            // Define the Field Existence Indicator for the Payment Data Block , These are optional values 
            //Data for fieldExistenceIndicatorPayment

            fieldExistenceIndicatorPayment.Add(new KeyValue("cardNumber", "4111111111111111")); // 1. Card Number 
            fieldExistenceIndicatorPayment.Add(new KeyValue("expMonth", "08"));                 // 2. Expiry Month 
            fieldExistenceIndicatorPayment.Add(new KeyValue("expYear", "2020"));                // 3. Expiry Year
            fieldExistenceIndicatorPayment.Add(new KeyValue("CVV", "123"));                     // 4. CVV  
            fieldExistenceIndicatorPayment.Add(new KeyValue("cardHolderName", "Soloman"));      // 5. Card Holder Name 
            fieldExistenceIndicatorPayment.Add(new KeyValue("cardType", "Visa"));               // 6. Card Type
            fieldExistenceIndicatorPayment.Add(new KeyValue("custMobileNumber", "9820998209")); // 7. Customer Mobile Number
            fieldExistenceIndicatorPayment.Add(new KeyValue("paymentID", "123456"));            // 8. Payment ID 
            fieldExistenceIndicatorPayment.Add(new KeyValue("OTP", "123456"));                  // 9. OTP field
            fieldExistenceIndicatorPayment.Add(new KeyValue("gatewayID", "1026"));              // 10.Gateway ID
            fieldExistenceIndicatorPayment.Add(new KeyValue("cardToken", "1202"));             // 11.Card Token 

            // Define the Field Existence Indicator for the Merchant Data Block , These are optional values 
            // Data for fieldExistenceIndicatorMerchant
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF1", "115.121.181.112")); // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF2", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF3", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF4", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF5", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF6", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF7", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF8", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF9", "abc"));             // This is a ‘user-defined field’ that can be used to send additional information about the transaction.
            fieldExistenceIndicatorMerchant.Add(new KeyValue("UDF10", "abc"));            // This is a ‘user-defined field’ that can be used to send additional information about the transaction.	

            // Define the Field Existence Indicator for the Other Details Data Block , These are optional values	
            //blockExistenceIndicator 

            fieldExistenceIndicatorOtherData.Add(new KeyValue("custID", "9874513"));    // The ID used to identify your customer when their profile was created. This field has to be passed by you only if you have opted for the ‘Tokenization/Stored Card’ feature.
                                                                                //The field is ‘alphanumeric’; special characters are not allowed.
            fieldExistenceIndicatorOtherData.Add(new KeyValue("transactionSource", "Web"));// This is used to identify a channel, in case you are using multiple channels.
                                                                                   //Acceptable values are: Web, IVR, or Mobile.
            fieldExistenceIndicatorOtherData.Add(new KeyValue("productInfo", "Book"));  // This field is used to send details about the product and related information.
            fieldExistenceIndicatorOtherData.Add(new KeyValue("isUserLoggedIn", "Y"));  // Indicates whether a customer has signed in to your website, or has done a Guest checkout Values: ‘Y’ – customer has signed in
                                                                                //‘N’ – customer has done a Guest checkout
            fieldExistenceIndicatorOtherData.Add(new KeyValue("itemTotal", "100.00"));  // This is a comma-separated list of the sale value of all the items in the order.
                                                                                //Example: If the order has two items of value 500 and 1000, send the value as ‘500.00, 1000.00’. Up to 2 decimal places are allowed in the value.
            fieldExistenceIndicatorOtherData.Add(new KeyValue("itemCategory", "CD, Book"));// This is a comma-separated list of the categories of all the items in the order.
            fieldExistenceIndicatorOtherData.Add(new KeyValue("ignoreValidationResult", "FALSE"));// Indicates whether you want to proceed for Authorization irrespective of the 3DSecure/Authentication result, or not. TRUE/FALSE

            //Data for fieldExistenceIndicatorDCC

            fieldExistenceIndicatorDCC.Add(new KeyValue("DCCReferenceNumber", "09898787")); // DCC Reference Number
            fieldExistenceIndicatorDCC.Add(new KeyValue("foreignAmount", "240.00")); // Foreign Amount
            fieldExistenceIndicatorDCC.Add(new KeyValue("ForeignCurrency", "USD"));  // Foreign Currency
        }

        // Block existence calculator - ex:  creates a sequence like 1110010 
        //----------------------------------------------------------------------------------------------------------------------------
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
                            finalData += fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }

                        break;
                    case "billingDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorBillingDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }
                        break;
                    case "shippingDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorShippingDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }
                        break;
                    case "paymentDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorPaymentDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }
                        break;
                    case "merchantDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorMerchantDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }
                        break;
                    case "otherDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorOtherDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
                        }
                        break;
                    case "DCCDataBlock":
                        blockExistenceIndicatorData += data.Value ? 1 : 0;
                        if (data.Value)
                        {
                            CalculateFieldExistenceIndicatorDCCDataBlock();
                            finalData += "|" + fieldExistenceIndicatorData + "|" + dataBlockString;
                            dataBlockString = ""; fieldExistenceIndicatorData = "";
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
            foreach (KeyValue data in fieldExistenceIndicatorTransaction)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }
        }


        /*Billing Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Billing block

        public void CalculateFieldExistenceIndicatorBillingDataBlock()
        {
            foreach (KeyValue data in fieldExistenceIndicatorBilling)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }

        }

        /*Shipping Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Shipping block
        public void CalculateFieldExistenceIndicatorShippingDataBlock()
        {
            foreach (KeyValue data in fieldExistenceIndicatorShipping)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }      

        }

        /*Payment Field Existence Block		 */  //creates a patternd like 11111111 depending on Fields present in payment block
        public void CalculateFieldExistenceIndicatorPaymentDataBlock()
        {

            foreach (KeyValue data in fieldExistenceIndicatorPayment)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }         

        }

        /*Merchant Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in Merchand block

        public void CalculateFieldExistenceIndicatorMerchantDataBlock()
        {
            foreach (KeyValue data in fieldExistenceIndicatorMerchant)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }

        }

        /*OtherData Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in OtherData block

        public void CalculateFieldExistenceIndicatorOtherDataBlock()
        {
            foreach (KeyValue data in fieldExistenceIndicatorOtherData)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
                }
            }

        }

        /*DCC Field Existence Block		 */ //creates a patternd like 11111111 depending on Fields present in DCC block

        public void CalculateFieldExistenceIndicatorDCCDataBlock()
        {

            foreach (KeyValue data in fieldExistenceIndicatorDCC)
            {
                fieldExistenceIndicatorData += (String.IsNullOrEmpty(data.Value)) ? 0 : 1;
                if (data.Value.Length > 0)
                {
                    CalculateDataBlock(data.Value);
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