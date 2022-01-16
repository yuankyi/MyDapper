using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using MyDapper.Methods;

namespace MyDapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            My.Write = this.WriteLine;
        }

        private void WriteLine(object msg)
        {
            if (txtOutput.InvokeRequired)
                this.Invoke(new Action<object>(WriteLineDelegate), msg);
            else
                WriteLineDelegate(msg);
        }

        private void WriteLineDelegate(object msg)
        {
            txtOutput.Text += DateTime.Now.ToString("HH:mm:ss.fff") + ": " + msg + "\r\n";
            txtOutput.Select(txtOutput.TextLength, 0);
            txtOutput.ScrollToCaret();
        }

        private void btnExeInsert_Click(object sender, EventArgs e)
        {
            Execute.ExecuteINSERT();
        }

        private void btnExeUpdate_Click(object sender, EventArgs e)
        {
            Execute.ExecuteUPDATE();
        }

        private void btnExeDelete_Click(object sender, EventArgs e)
        {
            Execute.ExecuteDELETE();
        }

        private void btnExeProcedure_Click(object sender, EventArgs e)
        {
            Execute.ExecuteStoredProcedure();
        }

        private void btnExeReader_Click(object sender, EventArgs e)
        {
            Execute.ExecuteReader();
        }

        private void btnExeScalar_Click(object sender, EventArgs e)
        {
            Execute.ExecuteScalar();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query.QueryCommon();
        }

        private void btnQueryFirst_Click(object sender, EventArgs e)
        {
            Query.QueryFirst();
        }

        private void btnQuerySingle_Click(object sender, EventArgs e)
        {
            Query.QuerySingle();
        }

        private void btnQueryMultiType_Click(object sender, EventArgs e)
        {
            Query.QueryMultiType();
        }

        private void btnQueryMultiMapping_Click(object sender, EventArgs e)
        {
            Query.QueryMultiMapping();
        }

        private void btnQueryMultResult_Click(object sender, EventArgs e)
        {
            Query.QueryMultipleResult();
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            Utility.Async();
        }

        private void btnBuffered_Click(object sender, EventArgs e)
        {
            Utility.Buffered();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            Utility.Transaction();
        }

        private void btnTransactionScope_Click(object sender, EventArgs e)
        {
            Utility.TransactionScope();
        }

        private void btnTransactionDapper_Click(object sender, EventArgs e)
        {
            Utility.TransactionDapper();
        }

        private void btnBulkInsert_Click(object sender, EventArgs e)
        {
            Bulk.BulkInsert();
        }

        private void btnBulkUpdate_Click(object sender, EventArgs e)
        {
            Bulk.BulkUpdate();
        }

        private void btnBulkDelete_Click(object sender, EventArgs e)
        {
            Bulk.BulkDelete();
        }

        private void btnBulkMerge_Click(object sender, EventArgs e)
        {
            Bulk.BulkMerge();
        }

        private void btnContrib_Click(object sender, EventArgs e)
        {
            Contrib.Method();
        }
    }
}
