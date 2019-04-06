<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayNowBitMap.aspx.cs" Inherits="PGSample.PayNowNew" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
		function generateAction() {
			var params = document.getElementById("requestparams").value;
			document.frmPost.requestParameter.value = params;
			//document.frmPost.action = "https://test.timesofmoney.com/direcpay/secure/PaymentTransactionServlet";
			//document.frmPost.action = "https://uat-NeO.network.ae/direcpay/secure/PaymentTransactionServlet";
			document.frmPost.action = "https://uat-NeO.network.ae/direcpay/secure/PaymentTxnServlet";
			document.frmPost.submit();
		}

		function createOrderNo() {
			//document.getElementById("txtOrdNo").value = new Date().getTime();
        }
 

		</script>
</head>
<body onload="createOrderNo();">
    <form id="form1" runat="server">
		<div>
			   <table>
				   <tr><td colspan="2"><font size="3" color="black"> <u><b>ACCOUNT DETAILS</b></u></font></td></tr>
		<tr>
			<td>
				<asp:Label ID="Label4" runat="server" Text="MerchantID"></asp:Label>

			</td>
				<td>
					<asp:TextBox ID="txtMerchantID" runat="server" ></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorMID" runat="server" ErrorMessage="* MerchantID is required" ControlToValidate="txtMerchantID" ForeColor="Red"></asp:RequiredFieldValidator>
			</td>
           <td colspan="7" align="center"><b><u>Required Blocks</u></b></td>
			</tr>
			<tr>
			<td>
				<asp:Label ID="Label5" runat="server" Text="Key"></asp:Label>

			</td>
				<td>
					<asp:TextBox ID="txtKey" runat="server" ></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorKey" runat="server" ErrorMessage="* Merchant Key is required" ControlToValidate="txtKey" ForeColor="Red"></asp:RequiredFieldValidator>
			</td>
                <td>
                <table style="border:1px solid">
                    <tr>
                 <td><asp:CheckBox ID="chkBoxTransaction" runat="server"/> Transaction Block</td><td><asp:CheckBox ID="chkBoxBilling" runat="server" /> Billing Block</td>
            <td><asp:CheckBox ID="chkBoxShipping" runat="server" OnCheckedChanged="ChkBoxShipping_CheckedChanged" AutoPostBack="true"/> Shipping Block</td><td><asp:CheckBox ID="chkBoxPayment" runat="server" OnCheckedChanged="ChkBoxPayment_CheckedChanged"  AutoPostBack="true"/>Payment Block</td>
            <td><asp:CheckBox ID="chkBoxMerchant" runat="server" OnCheckedChanged="ChkBoxMerchant_CheckedChanged" AutoPostBack="true"/> Merchant Block</td><td><asp:CheckBox ID="chkBoxOtherData" runat="server" OnCheckedChanged="ChkBoxOtherData_CheckedChanged" AutoPostBack="true"/>OtherData Block</td>
            <td><asp:CheckBox ID="chkBoxDccData" runat="server" OnCheckedChanged="ChkBoxDccData_CheckedChanged" AutoPostBack="true"/> DCCData Block</td>
                        </tr>
                </table>
                    </td>
				</tr>
				   </table>
		</div>
    <div>
       
    <table border="1">

    <tr>
        <td>
            <table style="margin-top:-1px">
            <tr>
              
					<td colspan="2"><font size="3" color="black"> <u><b>TRANSACTION DETAILS</b></u></font></td>
        <%--         <asp:Label ID="Label3" runat="server" Text="Order number"></asp:Label>
        <asp:TextBox id="txtOrdNo" runat="server"></asp:TextBox>--%>
                
            </tr>

            <tr>
      <td> <asp:Label ID="Label1" runat="server" Text="MerchantOrderNumber"></asp:Label></td>
      <td>  <asp:TextBox ID="txtMerchantOrderNumber" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label2" runat="server" Text="Currency"></asp:Label></td>
      <td> <asp:TextBox ID="txtCurrency" runat="server" >AED</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Amount" runat="server" Text="Amount" ></asp:Label></td>
      <td> <asp:TextBox ID="txtAmount" runat="server" >10</asp:TextBox>
         </td>
        <td> <asp:RegularExpressionValidator runat="server" ErrorMessage="* Decimal Only" ControlToValidate="txtAmount" ForeColor="Red"
      ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator></td>
     </tr>
     <tr>
      <td> <asp:Label ID="SuccessURL" runat="server" Text="SuccessURL"></asp:Label></td>
      <td>  <asp:TextBox ID="txtSuccessURL" runat="server">http://localhost:80/ResponseSuccess.aspx</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="FailureURL" runat="server" Text="FailureURL"></asp:Label></td>
      <td>  <asp:TextBox ID="txtFailureURL" runat="server">http://localhost:80/ResponseFailure.aspx</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="TransactionType" runat="server" Text="TransactionType"></asp:Label></td>
      <td>  <asp:DropDownList ID="drpDwnTransactionType" runat="server"></asp:DropDownList>
		  <%--<asp:TextBox ID="txtTransactionType" runat="server">01</asp:TextBox>--%>
         </td>
           <td>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Required" ControlToValidate="drpDwnTransactionType" ForeColor="Red"></asp:RequiredFieldValidator></td>

     </tr>
     <tr>
      <td> 
		  <asp:Label ID="TransactionMode" runat="server" Text="TransactionMode"></asp:Label>

      </td>
      <td>  <asp:DropDownList ID="drpDwnTrnMode" runat="server"></asp:DropDownList>
		  <%--<asp:TextBox ID="txtTransactionMode" runat="server">INTERNET</asp:TextBox>--%>
         
	  </td>
         <td>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Required" ControlToValidate="drpDwnTrnMode" ForeColor="Red"></asp:RequiredFieldValidator></td>
     </tr>
     <tr>
      <td> <asp:Label ID="PayModeType" runat="server" Text="PayModeType"></asp:Label></td>
      <td> <asp:DropDownList ID="drpDwnPayModeType" runat="server"></asp:DropDownList>
		  <%--<asp:TextBox ID="txtPayModeType" runat="server"></asp:TextBox>--%>
                   </td>
           <td>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Required" ControlToValidate="drpDwnPayModeType" ForeColor="Red"></asp:RequiredFieldValidator></td>

     </tr>
				<tr><td></td></tr>
				<tr><td colspan="2" ><font size="3" color="black"> <u><b>PAYMENT DETAILS</b></u></font></td></tr>

     <tr>
      <td> <asp:Label ID="CreditCardNumber" runat="server" Text="CreditCardNumber"></asp:Label></td>
      <td>  <asp:TextBox ID="txtCreditCardNumber" runat="server" ></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label10" runat="server" Text="CVV"></asp:Label></td>
      <td>  <asp:TextBox ID="txtCVV" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label11" runat="server" Text="ExpiryMonth"></asp:Label></td>
      <td>  <asp:TextBox ID="txtExpiryMonth" runat="server"></asp:TextBox>
         </td>
     </tr>      
     <tr>
      <td> <asp:Label ID="Label13" runat="server" Text="ExpiryYear"></asp:Label></td>
      <td>    <asp:TextBox ID="txtExpiryYear" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label14" runat="server" Text="CardType"></asp:Label></td>
      <td>  <asp:TextBox ID="txtCardType" runat="server"></asp:TextBox>
         </td>

     </tr>
				<tr> <td> <asp:Label ID="Label28" runat="server" Text="GatewayID"></asp:Label></td>
      <td> <asp:TextBox ID="txtGatewayID" runat="server"></asp:TextBox>
         </td></tr>
				<tr>
					<td>
						<asp:Label ID="Label8" runat="server" Text="CardHolderName"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtCardHolderName" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label9" runat="server" Text="CustomerMobileNo."></asp:Label></td>
					<td>
						<asp:TextBox ID="txtCustMobileNumber" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label12" runat="server" Text="CardToken"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtCardToken" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label53" runat="server" Text="OTP"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtOTP" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label54" runat="server" Text="paymentID"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtPaymentID" runat="server"></asp:TextBox></td>

				</tr>
            </table>
        </td>
        <td>
			 
                <table style="margin-top:-170px">
             <tr><td colspan="2"><font size="3" color="black"> <u><b>BILLING DETAILS</b></u></font></td></tr>  
         <tr>
      <td> <asp:Label ID="Label15" runat="server" Text="BillToFirstName"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToFirstName" runat="server">Fname</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label16" runat="server" Text="BillToLastName"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToLastName" runat="server">Lname</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label17" runat="server" Text="BillToStreet1"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToStreet1" runat="server">street1</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label18" runat="server" Text="BillToStreet2"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToStreet2" runat="server">street2</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label19" runat="server" Text="BillToCity"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToCity" runat="server">Dubai</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label20" runat="server" Text="BillToState"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToState" runat="server">Dubai</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label21" runat="server" Text="BillToPostalCode"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToPostalCode" runat="server">4487</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label22" runat="server" Text="BillToCountry"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToCountry" runat="server">AE</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label23" runat="server" Text="BillToEmail"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToEmail" runat="server">testuser@network.ae</asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label24" runat="server" Text="BillToPhoneNumber1"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToPhoneNumber1" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label25" runat="server" Text="BillToPhoneNumber2"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToPhoneNumber2" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label26" runat="server" Text="BillToPhoneNumber3"></asp:Label></td>
      <td>  <asp:TextBox ID="txtBillToPhoneNumber3" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label27" runat="server" Text="BillToMobileNumber"></asp:Label></td>
      <td> <asp:TextBox ID="txtBillToMobileNumber" runat="server"></asp:TextBox>
         </td>
     </tr>
                </table>
        </td>
        <td>
        
        <table style="margin-top:-95px">
        <tr><td colspan="2"><font size="3" color="black"> <u><b>SHIPPING DETAILS</b></u></font></td></tr>  

   
     <tr>
      <td> <asp:Label ID="Label30" runat="server" Text="ShipToFirstName"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToFirstName" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label31" runat="server" Text="ShipToLastName"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToLastName" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label32" runat="server" Text="ShipToStreet1"></asp:Label></td>
      <td> <asp:TextBox ID="txtShipToStreet1" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label33" runat="server" Text="ShipToStreet2"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToStreet2" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label34" runat="server" Text="ShipToCity"></asp:Label></td>
      <td>    <asp:TextBox ID="txtShipToCity" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label35" runat="server" Text="ShipToState"></asp:Label></td>
      <td> <asp:TextBox ID="txtShipToState" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label36" runat="server" Text="ShipToPostalCode"></asp:Label></td>
      <td>   <asp:TextBox ID="txtShipToPostalCode" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label37" runat="server" Text="ShipToCountry"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToCountry" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label38" runat="server" Text="ShipToPhoneNumber1"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToPhoneNumber1" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label39" runat="server" Text="ShipToPhoneNumber2"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToPhoneNumber2" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label40" runat="server" Text="ShipToPhoneNumber3"></asp:Label></td>
      <td> <asp:TextBox ID="txtShipToPhoneNumber3" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label41" runat="server" Text="ShipToMobileNumber"></asp:Label></td>
      <td>  <asp:TextBox ID="txtShipToMobileNumber" runat="server"></asp:TextBox>
         </td>
     </tr>

			<tr>
				<td></td>
				
			</tr>
			<tr><td colspan="2"><font size="3" color="black"> <u><b>DCC DETAILS</b></u></font></td></tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Text="DCCReferenceNumber"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtDccNum" runat="server"></asp:TextBox></td>
			</tr>
			<tr><td>
				<asp:Label ID="Label6" runat="server" Text="Foreign Amount"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtFrnAmnt" runat="server"></asp:TextBox></td>
			</tr>
			<tr><td>
				<asp:Label ID="Label7" runat="server" Text="Foreign Currency"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtFrnCurr" runat="server"></asp:TextBox></td>
			</tr>
        </table>
        
        </td>

        <td>
         <table style="margin-top:-45px">
			 <tr><td colspan="2"><font size="3" color="black"> <u><b>OTHER DETAILS</b></u></font></td></tr>
           <tr>
      <td> <asp:Label ID="Label29" runat="server" Text="CustomerID"></asp:Label></td>
      <td> <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label42" runat="server" Text="TransactionSource"></asp:Label></td>
      <td> <asp:TextBox ID="txtTransactionSource" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label43" runat="server" Text="ProductInfo"></asp:Label></td>
      <td>   <asp:TextBox ID="txtProductInfo" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label44" runat="server" Text="IsUserLoggedIn"></asp:Label></td>
      <td> <asp:TextBox ID="txtIsUserLoggedIn" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label45" runat="server" Text="ItemTotal"></asp:Label></td>
      <td>  <asp:TextBox ID="txtItemTotal" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label46" runat="server" Text="ItemCategory"></asp:Label></td>
      <td>  <asp:TextBox ID="txtItemCategory" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label47" runat="server" Text="IgnoreValidationResult"></asp:Label></td>
      <td>   <asp:TextBox ID="txtIgnoreValidationResult" runat="server"></asp:TextBox>
         </td>
     </tr>
			 	<tr><td></td></tr>
				<tr><td colspan="2" ><font size="3" color="black"> <u><b>MERCHANT DETAILS</b></u></font></td></tr>
     <tr>
      <td> <asp:Label ID="Label48" runat="server" Text="udf1"></asp:Label></td>
      <td>  <asp:TextBox ID="txtudf1" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="Label49" runat="server" Text="udf2"></asp:Label></td>
      <td>  <asp:TextBox ID="txtudf2" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label50" runat="server" Text="udf3"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf3" runat="server"></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="Label51" runat="server" Text="udf4"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf4" runat="server"></asp:TextBox>
         </td>
     </tr>

     <tr>
      <td> <asp:Label ID="Label52" runat="server" Text="udf5"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf5" runat="server" ></asp:TextBox>
         </td>
     </tr>
	 <tr>
      <td> <asp:Label ID="LabelUf6" runat="server" Text="udf6"></asp:Label></td>
      <td>  <asp:TextBox ID="txtudf6" runat="server"></asp:TextBox>
         </td>
     </tr>

      <tr>
      <td> <asp:Label ID="LabelUf7" runat="server" Text="udf7"></asp:Label></td>
      <td>  <asp:TextBox ID="txtudf7" runat="server" ></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="LabelUf8" runat="server" Text="udf8"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf8" runat="server" ></asp:TextBox>
         </td>
     </tr>
     <tr>
      <td> <asp:Label ID="LabelUf9" runat="server" Text="udf9"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf9" runat="server" ></asp:TextBox>
         </td>
     </tr>

     <tr>
      <td> <asp:Label ID="LabelUf10" runat="server" Text="udf10"></asp:Label></td>
      <td> <asp:TextBox ID="txtudf10" runat="server" ></asp:TextBox>
         </td>
     </tr>
         </table>
        </td>
    </tr>

     
     


    </table>

    </div>
    
    <table border="1" width="100%">
        <tr align="center">
            <td>
                <asp:TextBox ID="txtVerify" runat="server" Height="68px" TextMode="MultiLine" 
        Width="605px"></asp:TextBox>
            </td>
        </tr>
        <tr  align="center">
            <td>
                 <asp:Button ID="btnEncrypt" runat="server"  Text="Verify" 
        onclick="btnEncrypt_Click" />
         
            </td>
        </tr>
    </table>
    
   <asp:HiddenField id="requestparams" runat="server"></asp:HiddenField>
    </form>
    <form id="frmPost" name="frmPost" method="post" >
   <input type="hidden" name="requestParameter" id="requestParameter" value=""/>
    <input type="submit" value="PayNow" id="btnPayNow" onclick="generateAction();"/>
    </form>
</body>
</html>
