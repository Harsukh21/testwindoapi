<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionManipulator.aspx.cs" Inherits="PGSample.Reversal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style> 
 .table {
            border:solid;
            border-color:black;
            /*background-color: linen;*/
        }
 .trEven{

     border:2px dotted;
     background-color:linen;
 }
 .trOdd{


     background-color:burlywood;
 }
 .td{
     /*border:thin;*/
 }

</style>
</head>
<body>
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
			</tr>
			<tr>
			<td>
				<asp:Label ID="Label5" runat="server" Text="Key"></asp:Label>

			</td>
				<td>
					<asp:TextBox ID="txtKey" runat="server" ></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidatorKey" runat="server" ErrorMessage="* Merchant Key is required" ControlToValidate="txtKey" ForeColor="Red"></asp:RequiredFieldValidator>
			</td>
				</tr>
				   </table>
		</div>


  <div>
			<table>
				<tr>
					<td>
						<asp:Label ID="Label1" runat="server" Text="NI ReferenceNumber"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtReferenceNumber" runat="server"></asp:TextBox></td>
                     <td>
                        <asp:RequiredFieldValidator ID="validatorOrderNo" runat="server" ErrorMessage="* NI Reference number is mandatory" ControlToValidate="txtReferenceNumber" ForeColor="Red"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="Reversal type"></asp:Label></td>
					<td>
                        <asp:DropDownList ID="drpDwnReversalType" runat="server" OnSelectedIndexChanged="drpDwnReversalType_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList></td>
                   
				</tr>
                 
				<tr id="amountRow" runat="server">
					<td>
                     <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
                     </td>
					<td>
						<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
				</tr>
                     
				<tr>
					<td>
						<asp:Button ID="Button1" runat="server" Text="GetOrderStatus" OnClick="Button1_Click" /></td>
					
				</tr>

			</table>
            <div> <h2>Transaction Details</h2></div>
			<div>
				<asp:TextBox ID="txtResult" runat="server" Height="46px" Width="530px"></asp:TextBox>
				</div>
            <div id="div1" runat="server">

            </div>
        </div>


    </form>
</body>
</html>
