<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="PGSample.OrderStatus" %>

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
				<tr>
					<td>
						<asp:Label ID="Label1" runat="server" Text="ReferenceNUmber"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtReferenceNUmber" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label2" runat="server" Text="OrderNumber"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtOrderNUmber" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="validatorOrderNo" runat="server" ErrorMessage="*Order number is mandatory" ControlToValidate="txtOrderNUmber" ForeColor="Red"></asp:RequiredFieldValidator></td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label3" runat="server" Text="TransactionType"></asp:Label></td>
					<td>
						<asp:TextBox ID="txtTransactionType" runat="server"></asp:TextBox></td>
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
