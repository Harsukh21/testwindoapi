using com.ni.dp.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
   * 2017 Abzer Technology Solutions Class For transactions like "Void", "Full Auth Reversal","Capture","Partial capture","Reversal"
   *  
   *  NOTICE OF LICENSE
   *  File Name : TransactionManipulator.cs 
   *  For pulling transaction detail from QueryApi web service
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
    public partial class Reversal : System.Web.UI.Page
    {
        Table table = new Table();
        ServiceReferenceInvokeEcomWebServices_test.InvokeEcomWebServicesClient clientObj= new ServiceReferenceInvokeEcomWebServices_test.InvokeEcomWebServicesClient();
        //ServiceReferenceInvokeEcomWebServices_live.InvokeEcomWebServicesClient clientObj = new ServiceReferenceInvokeEcomWebServices_live.InvokeEcomWebServicesClient();


        List<String> reversalType = new List<string> { "", "Void", "Full Auth Reversal","Capture","Partial capture","Reversal" };

        string[] fullAuthKeys = { "MerchantID", "NIOnlineRefID", "Currency", "Amount", "Status", "ErrorCode", "ErrorMessage", "BankReference Number","","","","","" };
        string[] voidKeys = { "MerchantID", "NIOnlineRefID", "Currency", "Amount", "Status", "ErrorCode", "ErrorMessage", "BankReference Number", "", "", "", "", "" };
        string[] captureKeys = { "MerchantID", "NIOnlineRefID", "Currency", "Amount", "Status", "ErrorCode", "ErrorMessage", "BankReference Number", "", "", "", "", "" };
        string[] partialCaptureKeys = { "MerchantID", "NIOnlineRefID", "Currency", "Amount", "Status", "ErrorCode", "ErrorMessage", "BankReference Number", "", "", "", "", "" };
        string[] reversalKeys = { "MerchantID", "NIOnlineRefID", "Currency", "Amount", "Status", "ErrorCode", "ErrorMessage", "BankReference Number", "", "", "", "", "" };
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpDwnReversalType.DataSource = reversalType;
                drpDwnReversalType.DataBind();
                amountRow.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = drpDwnReversalType.SelectedIndex;
            switch(i)
            {
                case 0:
                    break;
              
                case 1:
                    {
                        string strMessage = txtReferenceNumber.Text;// + "|";
                        EncDec aesEncrypt = new EncDec();
                        strMessage = aesEncrypt.Encrypt(txtKey.Text, strMessage);
                        string result = EncDec.Decrypt(txtKey.Text, clientObj.InvokeVoidWS(txtMerchantID.Text, strMessage));
                        txtResult.Text = result;
                        Decode(result,voidKeys);
                        break;
                    }
                case 2:
                    {
                        string strMessage = txtReferenceNumber.Text;// + "|";
                        EncDec aesEncrypt = new EncDec();
                        strMessage = aesEncrypt.Encrypt(txtKey.Text, strMessage);
                        string decry= clientObj.InvokeFullAuthReversalWS(txtMerchantID.Text, strMessage);
                        string result = EncDec.Decrypt(txtKey.Text, decry);
                        txtResult.Text = result;
                        Decode(result,fullAuthKeys);
                        break;
                    }
                case 3:
                    {
  
                        string strMessage = txtReferenceNumber.Text;// + "|"+ txtAmount.Text + "|";
                        EncDec aesEncrypt = new EncDec();
                        strMessage = aesEncrypt.Encrypt(txtKey.Text, strMessage);                  
                        string result = EncDec.Decrypt(txtKey.Text, clientObj.InvokeCaptureWS(txtMerchantID.Text, strMessage));
                        txtResult.Text = result;
                        Decode(result,captureKeys);
                        break;
                    }
                case 4:
                    {
                        amountRow.Visible = true;
                        string strMessage = txtReferenceNumber.Text;// + "|";
                        EncDec aesEncrypt = new EncDec();
                        strMessage = aesEncrypt.Encrypt(txtKey.Text, strMessage);
                        string amount = aesEncrypt.Encrypt(txtKey.Text, txtAmount.Text);
                        string result  = EncDec.Decrypt(txtKey.Text, clientObj.InvokePartialCaptureWS(txtMerchantID.Text, strMessage,amount));
                        txtResult.Text = result;
                        Decode(result,partialCaptureKeys);
                        break;
                    }
                case 5:
                    {
                        amountRow.Visible = true;
                        string strMessage = txtReferenceNumber.Text;// + "|";
                        EncDec aesEncrypt = new EncDec();
                        strMessage = aesEncrypt.Encrypt(txtKey.Text, strMessage);
                        string amount = aesEncrypt.Encrypt(txtKey.Text, txtAmount.Text);
                        string result = EncDec.Decrypt(txtKey.Text, clientObj.InvokeReversalWS(txtMerchantID.Text, strMessage, amount));
                        txtResult.Text = result;
                        Decode(result,reversalKeys);
                        break;
                    }
            }


        }

        protected void drpDwnReversalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDwnReversalType.SelectedIndex > 3)
            {
                amountRow.Visible = true;
            }
            else
            {
                amountRow.Visible = false;
            }
        }
        protected void Decode(string data,string[] keys)
        {
            string[] decodedFields;
            
            decodedFields = data.Split(new[] { "|" }, StringSplitOptions.None);
            table.CssClass = "table";
            div1.Controls.Add(table);
            int swap = 0,i=0;
            foreach (string a in decodedFields)
            {

                
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                tr.CssClass = (++swap % 2 == 0) ? "trEven" : "trOdd";
                Label dynamic = new Label();
                table.Controls.Add(tr);
                tr.Controls.Add(td);
                dynamic.Text = keys[i];
                i++;
                td.Controls.Add(dynamic);
                dynamic = new Label();
                td = new TableCell();
                tr.Controls.Add(td);
                dynamic.Text = a;           
                td.Controls.Add(dynamic);
            }

        }
    }
}