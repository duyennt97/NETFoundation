
namespace BookStorePresentation
{
    partial class BookStoreManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_publishYearTextBox = new System.Windows.Forms.TextBox();
            this.m_authorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_nameTextBox = new System.Windows.Forms.TextBox();
            this.m_newButton = new System.Windows.Forms.Button();
            this.m_saveButton = new System.Windows.Forms.Button();
            this.m_deleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_searchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_formatLabel = new System.Windows.Forms.Label();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishYearCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCatCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.m_priceTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.AuthorCol,
            this.PublishYearCol,
            this.PriceCol,
            this.PriceCatCol});
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 195);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.OnSelectedRowChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.m_publishYearTextBox, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_authorTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_priceTextBox, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 260);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 29);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // m_publishYearTextBox
            // 
            this.m_publishYearTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_publishYearTextBox.Location = new System.Drawing.Point(527, 4);
            this.m_publishYearTextBox.Name = "m_publishYearTextBox";
            this.m_publishYearTextBox.Size = new System.Drawing.Size(75, 20);
            this.m_publishYearTextBox.TabIndex = 5;
            this.m_publishYearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnPublishYearKeyPressed);
            // 
            // m_authorTextBox
            // 
            this.m_authorTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_authorTextBox.Location = new System.Drawing.Point(326, 4);
            this.m_authorTextBox.Name = "m_authorTextBox";
            this.m_authorTextBox.Size = new System.Drawing.Size(115, 20);
            this.m_authorTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Publish year";
            // 
            // m_nameTextBox
            // 
            this.m_nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_nameTextBox.Location = new System.Drawing.Point(63, 4);
            this.m_nameTextBox.Name = "m_nameTextBox";
            this.m_nameTextBox.Size = new System.Drawing.Size(197, 20);
            this.m_nameTextBox.TabIndex = 3;
            // 
            // m_newButton
            // 
            this.m_newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_newButton.Location = new System.Drawing.Point(539, 3);
            this.m_newButton.Name = "m_newButton";
            this.m_newButton.Size = new System.Drawing.Size(74, 22);
            this.m_newButton.TabIndex = 2;
            this.m_newButton.Text = "New";
            this.m_newButton.UseVisualStyleBackColor = true;
            this.m_newButton.Click += new System.EventHandler(this.OnNewButtonClicked);
            // 
            // m_saveButton
            // 
            this.m_saveButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.m_saveButton.Location = new System.Drawing.Point(619, 3);
            this.m_saveButton.Name = "m_saveButton";
            this.m_saveButton.Size = new System.Drawing.Size(74, 22);
            this.m_saveButton.TabIndex = 3;
            this.m_saveButton.Text = "Save";
            this.m_saveButton.UseVisualStyleBackColor = true;
            this.m_saveButton.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // m_deleteButton
            // 
            this.m_deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_deleteButton.Location = new System.Drawing.Point(699, 3);
            this.m_deleteButton.Name = "m_deleteButton";
            this.m_deleteButton.Size = new System.Drawing.Size(74, 22);
            this.m_deleteButton.TabIndex = 4;
            this.m_deleteButton.Text = "Delete";
            this.m_deleteButton.UseVisualStyleBackColor = true;
            this.m_deleteButton.Click += new System.EventHandler(this.OnDeleteButtonClicked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Controls.Add(this.m_searchButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_deleteButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_saveButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_newButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 295);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(776, 28);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // m_searchButton
            // 
            this.m_searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_searchButton.Location = new System.Drawing.Point(458, 3);
            this.m_searchButton.Name = "m_searchButton";
            this.m_searchButton.Size = new System.Drawing.Size(75, 22);
            this.m_searchButton.TabIndex = 5;
            this.m_searchButton.Text = "Search";
            this.m_searchButton.UseVisualStyleBackColor = true;
            this.m_searchButton.Click += new System.EventHandler(this.OnSearchButtonClicked);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 526F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(9, 363);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(776, 28);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(623, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Format:";
            // 
            // m_formatLabel
            // 
            this.m_formatLabel.AutoSize = true;
            this.m_formatLabel.Location = new System.Drawing.Point(706, 13);
            this.m_formatLabel.Name = "m_formatLabel";
            this.m_formatLabel.Size = new System.Drawing.Size(36, 13);
            this.m_formatLabel.TabIndex = 8;
            this.m_formatLabel.Text = "format";
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // AuthorCol
            // 
            this.AuthorCol.DataPropertyName = "Author";
            this.AuthorCol.HeaderText = "Author";
            this.AuthorCol.Name = "AuthorCol";
            this.AuthorCol.ReadOnly = true;
            this.AuthorCol.Width = 200;
            // 
            // PublishYearCol
            // 
            this.PublishYearCol.DataPropertyName = "Publishyear";
            this.PublishYearCol.HeaderText = "Publish year";
            this.PublishYearCol.Name = "PublishYearCol";
            this.PublishYearCol.ReadOnly = true;
            this.PublishYearCol.Width = 150;
            // 
            // PriceCol
            // 
            this.PriceCol.DataPropertyName = "Price";
            this.PriceCol.HeaderText = "Price";
            this.PriceCol.Name = "PriceCol";
            this.PriceCol.ReadOnly = true;
            // 
            // PriceCatCol
            // 
            this.PriceCatCol.DataPropertyName = "BookCategory";
            this.PriceCatCol.HeaderText = "BookCategory";
            this.PriceCatCol.Name = "PriceCatCol";
            this.PriceCatCol.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Price";
            // 
            // m_priceTextBox
            // 
            this.m_priceTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_priceTextBox.Location = new System.Drawing.Point(658, 4);
            this.m_priceTextBox.Name = "m_priceTextBox";
            this.m_priceTextBox.Size = new System.Drawing.Size(115, 20);
            this.m_priceTextBox.TabIndex = 7;
            // 
            // BookStoreManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 403);
            this.Controls.Add(this.m_formatLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BookStoreManagerForm";
            this.Text = "Bookstore Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox m_publishYearTextBox;
        private System.Windows.Forms.TextBox m_authorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_nameTextBox;
        private System.Windows.Forms.Button m_newButton;
        private System.Windows.Forms.Button m_saveButton;
        private System.Windows.Forms.Button m_deleteButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_formatLabel;
        private System.Windows.Forms.Button m_searchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishYearCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCatCol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_priceTextBox;
    }
}

