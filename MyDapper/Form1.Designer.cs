namespace MyDapper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnExeInsert = new System.Windows.Forms.Button();
            this.btnExeUpdate = new System.Windows.Forms.Button();
            this.btnExeDelete = new System.Windows.Forms.Button();
            this.btnExeProcedure = new System.Windows.Forms.Button();
            this.btnExeReader = new System.Windows.Forms.Button();
            this.btnExeScalar = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnQueryFirst = new System.Windows.Forms.Button();
            this.btnQuerySingle = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnBuffered = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnTransactionScope = new System.Windows.Forms.Button();
            this.btnTransactionDapper = new System.Windows.Forms.Button();
            this.btnQueryMultiType = new System.Windows.Forms.Button();
            this.btnQueryMultiMapping = new System.Windows.Forms.Button();
            this.btnQueryMultiResult = new System.Windows.Forms.Button();
            this.btnBulkInsert = new System.Windows.Forms.Button();
            this.btnBulkUpdate = new System.Windows.Forms.Button();
            this.btnBulkDelete = new System.Windows.Forms.Button();
            this.btnBulkMerge = new System.Windows.Forms.Button();
            this.btnContrib = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutput.Location = new System.Drawing.Point(33, 151);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(591, 125);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // btnExeInsert
            // 
            this.btnExeInsert.Location = new System.Drawing.Point(33, 25);
            this.btnExeInsert.Name = "btnExeInsert";
            this.btnExeInsert.Size = new System.Drawing.Size(75, 23);
            this.btnExeInsert.TabIndex = 2;
            this.btnExeInsert.Text = "ExeInsert";
            this.btnExeInsert.UseVisualStyleBackColor = true;
            this.btnExeInsert.Click += new System.EventHandler(this.btnExeInsert_Click);
            // 
            // btnExeUpdate
            // 
            this.btnExeUpdate.Location = new System.Drawing.Point(114, 25);
            this.btnExeUpdate.Name = "btnExeUpdate";
            this.btnExeUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnExeUpdate.TabIndex = 3;
            this.btnExeUpdate.Text = "ExeUpdate";
            this.btnExeUpdate.UseVisualStyleBackColor = true;
            this.btnExeUpdate.Click += new System.EventHandler(this.btnExeUpdate_Click);
            // 
            // btnExeDelete
            // 
            this.btnExeDelete.Location = new System.Drawing.Point(195, 25);
            this.btnExeDelete.Name = "btnExeDelete";
            this.btnExeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnExeDelete.TabIndex = 4;
            this.btnExeDelete.Text = "ExeDelete";
            this.btnExeDelete.UseVisualStyleBackColor = true;
            this.btnExeDelete.Click += new System.EventHandler(this.btnExeDelete_Click);
            // 
            // btnExeProcedure
            // 
            this.btnExeProcedure.Location = new System.Drawing.Point(276, 25);
            this.btnExeProcedure.Name = "btnExeProcedure";
            this.btnExeProcedure.Size = new System.Drawing.Size(96, 23);
            this.btnExeProcedure.TabIndex = 5;
            this.btnExeProcedure.Text = "ExeProcedure";
            this.btnExeProcedure.UseVisualStyleBackColor = true;
            this.btnExeProcedure.Click += new System.EventHandler(this.btnExeProcedure_Click);
            // 
            // btnExeReader
            // 
            this.btnExeReader.Location = new System.Drawing.Point(378, 25);
            this.btnExeReader.Name = "btnExeReader";
            this.btnExeReader.Size = new System.Drawing.Size(75, 23);
            this.btnExeReader.TabIndex = 6;
            this.btnExeReader.Text = "ExeReader";
            this.btnExeReader.UseVisualStyleBackColor = true;
            this.btnExeReader.Click += new System.EventHandler(this.btnExeReader_Click);
            // 
            // btnExeScalar
            // 
            this.btnExeScalar.Location = new System.Drawing.Point(459, 25);
            this.btnExeScalar.Name = "btnExeScalar";
            this.btnExeScalar.Size = new System.Drawing.Size(75, 23);
            this.btnExeScalar.TabIndex = 7;
            this.btnExeScalar.Text = "ExeScalar";
            this.btnExeScalar.UseVisualStyleBackColor = true;
            this.btnExeScalar.Click += new System.EventHandler(this.btnExeScalar_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(33, 54);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnQueryFirst
            // 
            this.btnQueryFirst.Location = new System.Drawing.Point(114, 54);
            this.btnQueryFirst.Name = "btnQueryFirst";
            this.btnQueryFirst.Size = new System.Drawing.Size(75, 23);
            this.btnQueryFirst.TabIndex = 9;
            this.btnQueryFirst.Text = "QueryFirst";
            this.btnQueryFirst.UseVisualStyleBackColor = true;
            this.btnQueryFirst.Click += new System.EventHandler(this.btnQueryFirst_Click);
            // 
            // btnQuerySingle
            // 
            this.btnQuerySingle.Location = new System.Drawing.Point(195, 54);
            this.btnQuerySingle.Name = "btnQuerySingle";
            this.btnQuerySingle.Size = new System.Drawing.Size(83, 23);
            this.btnQuerySingle.TabIndex = 10;
            this.btnQuerySingle.Text = "QuerySingle";
            this.btnQuerySingle.UseVisualStyleBackColor = true;
            this.btnQuerySingle.Click += new System.EventHandler(this.btnQuerySingle_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(33, 83);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(75, 23);
            this.btnAsync.TabIndex = 12;
            this.btnAsync.Text = "Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnBuffered
            // 
            this.btnBuffered.Location = new System.Drawing.Point(114, 83);
            this.btnBuffered.Name = "btnBuffered";
            this.btnBuffered.Size = new System.Drawing.Size(75, 23);
            this.btnBuffered.TabIndex = 13;
            this.btnBuffered.Text = "Buffered";
            this.btnBuffered.UseVisualStyleBackColor = true;
            this.btnBuffered.Click += new System.EventHandler(this.btnBuffered_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(195, 83);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(83, 23);
            this.btnTransaction.TabIndex = 14;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnTransactionScope
            // 
            this.btnTransactionScope.Location = new System.Drawing.Point(284, 83);
            this.btnTransactionScope.Name = "btnTransactionScope";
            this.btnTransactionScope.Size = new System.Drawing.Size(115, 23);
            this.btnTransactionScope.TabIndex = 15;
            this.btnTransactionScope.Text = "TransactionScope";
            this.btnTransactionScope.UseVisualStyleBackColor = true;
            this.btnTransactionScope.Click += new System.EventHandler(this.btnTransactionScope_Click);
            // 
            // btnTransactionDapper
            // 
            this.btnTransactionDapper.Location = new System.Drawing.Point(405, 83);
            this.btnTransactionDapper.Name = "btnTransactionDapper";
            this.btnTransactionDapper.Size = new System.Drawing.Size(115, 23);
            this.btnTransactionDapper.TabIndex = 16;
            this.btnTransactionDapper.Text = "TransactionDapper";
            this.btnTransactionDapper.UseVisualStyleBackColor = true;
            this.btnTransactionDapper.Click += new System.EventHandler(this.btnTransactionDapper_Click);
            // 
            // btnQueryMultiType
            // 
            this.btnQueryMultiType.Location = new System.Drawing.Point(284, 54);
            this.btnQueryMultiType.Name = "btnQueryMultiType";
            this.btnQueryMultiType.Size = new System.Drawing.Size(98, 23);
            this.btnQueryMultiType.TabIndex = 17;
            this.btnQueryMultiType.Text = "QueryMultiType";
            this.btnQueryMultiType.UseVisualStyleBackColor = true;
            this.btnQueryMultiType.Click += new System.EventHandler(this.btnQueryMultiType_Click);
            // 
            // btnQueryMultiMapping
            // 
            this.btnQueryMultiMapping.Location = new System.Drawing.Point(387, 54);
            this.btnQueryMultiMapping.Name = "btnQueryMultiMapping";
            this.btnQueryMultiMapping.Size = new System.Drawing.Size(117, 23);
            this.btnQueryMultiMapping.TabIndex = 18;
            this.btnQueryMultiMapping.Text = "QueryMultiMapping";
            this.btnQueryMultiMapping.UseVisualStyleBackColor = true;
            this.btnQueryMultiMapping.Click += new System.EventHandler(this.btnQueryMultiMapping_Click);
            // 
            // btnQueryMultiResult
            // 
            this.btnQueryMultiResult.Location = new System.Drawing.Point(510, 54);
            this.btnQueryMultiResult.Name = "btnQueryMultiResult";
            this.btnQueryMultiResult.Size = new System.Drawing.Size(114, 23);
            this.btnQueryMultiResult.TabIndex = 19;
            this.btnQueryMultiResult.Text = "QueryMultiResult";
            this.btnQueryMultiResult.UseVisualStyleBackColor = true;
            this.btnQueryMultiResult.Click += new System.EventHandler(this.btnQueryMultResult_Click);
            // 
            // btnBulkInsert
            // 
            this.btnBulkInsert.Location = new System.Drawing.Point(33, 112);
            this.btnBulkInsert.Name = "btnBulkInsert";
            this.btnBulkInsert.Size = new System.Drawing.Size(75, 23);
            this.btnBulkInsert.TabIndex = 20;
            this.btnBulkInsert.Text = "BulkInsert";
            this.btnBulkInsert.UseVisualStyleBackColor = true;
            this.btnBulkInsert.Click += new System.EventHandler(this.btnBulkInsert_Click);
            // 
            // btnBulkUpdate
            // 
            this.btnBulkUpdate.Location = new System.Drawing.Point(114, 112);
            this.btnBulkUpdate.Name = "btnBulkUpdate";
            this.btnBulkUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnBulkUpdate.TabIndex = 21;
            this.btnBulkUpdate.Text = "BulkUpdate";
            this.btnBulkUpdate.UseVisualStyleBackColor = true;
            this.btnBulkUpdate.Click += new System.EventHandler(this.btnBulkUpdate_Click);
            // 
            // btnBulkDelete
            // 
            this.btnBulkDelete.Location = new System.Drawing.Point(195, 112);
            this.btnBulkDelete.Name = "btnBulkDelete";
            this.btnBulkDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBulkDelete.TabIndex = 22;
            this.btnBulkDelete.Text = "BulkDelete";
            this.btnBulkDelete.UseVisualStyleBackColor = true;
            this.btnBulkDelete.Click += new System.EventHandler(this.btnBulkDelete_Click);
            // 
            // btnBulkMerge
            // 
            this.btnBulkMerge.Location = new System.Drawing.Point(276, 112);
            this.btnBulkMerge.Name = "btnBulkMerge";
            this.btnBulkMerge.Size = new System.Drawing.Size(75, 23);
            this.btnBulkMerge.TabIndex = 23;
            this.btnBulkMerge.Text = "BulkMerge";
            this.btnBulkMerge.UseVisualStyleBackColor = true;
            this.btnBulkMerge.Click += new System.EventHandler(this.btnBulkMerge_Click);
            // 
            // btnContrib
            // 
            this.btnContrib.Location = new System.Drawing.Point(357, 112);
            this.btnContrib.Name = "btnContrib";
            this.btnContrib.Size = new System.Drawing.Size(163, 23);
            this.btnContrib.TabIndex = 24;
            this.btnContrib.Text = "Contrib";
            this.btnContrib.UseVisualStyleBackColor = true;
            this.btnContrib.Click += new System.EventHandler(this.btnContrib_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 299);
            this.Controls.Add(this.btnContrib);
            this.Controls.Add(this.btnBulkMerge);
            this.Controls.Add(this.btnBulkDelete);
            this.Controls.Add(this.btnBulkUpdate);
            this.Controls.Add(this.btnBulkInsert);
            this.Controls.Add(this.btnQueryMultiResult);
            this.Controls.Add(this.btnQueryMultiMapping);
            this.Controls.Add(this.btnQueryMultiType);
            this.Controls.Add(this.btnTransactionDapper);
            this.Controls.Add(this.btnTransactionScope);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnBuffered);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnQuerySingle);
            this.Controls.Add(this.btnQueryFirst);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnExeScalar);
            this.Controls.Add(this.btnExeReader);
            this.Controls.Add(this.btnExeProcedure);
            this.Controls.Add(this.btnExeDelete);
            this.Controls.Add(this.btnExeUpdate);
            this.Controls.Add(this.btnExeInsert);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnExeInsert;
        private System.Windows.Forms.Button btnExeUpdate;
        private System.Windows.Forms.Button btnExeDelete;
        private System.Windows.Forms.Button btnExeProcedure;
        private System.Windows.Forms.Button btnExeReader;
        private System.Windows.Forms.Button btnExeScalar;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnQueryFirst;
        private System.Windows.Forms.Button btnQuerySingle;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnBuffered;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnTransactionScope;
        private System.Windows.Forms.Button btnTransactionDapper;
        private System.Windows.Forms.Button btnQueryMultiType;
        private System.Windows.Forms.Button btnQueryMultiMapping;
        private System.Windows.Forms.Button btnQueryMultiResult;
        private System.Windows.Forms.Button btnBulkInsert;
        private System.Windows.Forms.Button btnBulkUpdate;
        private System.Windows.Forms.Button btnBulkDelete;
        private System.Windows.Forms.Button btnBulkMerge;
        private System.Windows.Forms.Button btnContrib;
    }
}

