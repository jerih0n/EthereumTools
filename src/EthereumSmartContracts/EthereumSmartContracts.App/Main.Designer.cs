namespace EthereumSmartContracts.App
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.transactionResultTextbox = new System.Windows.Forms.TextBox();
            this.smartcontracMethodsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteConractsBtn = new System.Windows.Forms.Button();
            this.addNewContractBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contractAddress = new System.Windows.Forms.TextBox();
            this.uploadABIBtn = new System.Windows.Forms.Button();
            this.smartContractsGrid = new System.Windows.Forms.DataGridView();
            this.ContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnemonic = new System.Windows.Forms.Panel();
            this.ethBalance = new System.Windows.Forms.Label();
            this.addressesComboBox = new System.Windows.Forms.ComboBox();
            this.ethereumAddress = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.mnemonicPhrase = new System.Windows.Forms.Label();
            this.mnemonicLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartContractsGrid)).BeginInit();
            this.mnemonic.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.transactionResultTextbox);
            this.panel1.Controls.Add(this.smartcontracMethodsPanel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.mnemonic);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 509);
            this.panel1.TabIndex = 0;
            // 
            // transactionResultTextbox
            // 
            this.transactionResultTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transactionResultTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transactionResultTextbox.Location = new System.Drawing.Point(655, 282);
            this.transactionResultTextbox.Multiline = true;
            this.transactionResultTextbox.Name = "transactionResultTextbox";
            this.transactionResultTextbox.ReadOnly = true;
            this.transactionResultTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.transactionResultTextbox.Size = new System.Drawing.Size(520, 212);
            this.transactionResultTextbox.TabIndex = 1;
            // 
            // smartcontracMethodsPanel
            // 
            this.smartcontracMethodsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartcontracMethodsPanel.AutoScroll = true;
            this.smartcontracMethodsPanel.ColumnCount = 1;
            this.smartcontracMethodsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.smartcontracMethodsPanel.Location = new System.Drawing.Point(6, 282);
            this.smartcontracMethodsPanel.Name = "smartcontracMethodsPanel";
            this.smartcontracMethodsPanel.RowCount = 1;
            this.smartcontracMethodsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.smartcontracMethodsPanel.Size = new System.Drawing.Size(588, 212);
            this.smartcontracMethodsPanel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.smartContractsGrid);
            this.groupBox1.Location = new System.Drawing.Point(6, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Smart Contracts";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.deleteConractsBtn);
            this.panel2.Controls.Add(this.addNewContractBtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.contractAddress);
            this.panel2.Controls.Add(this.uploadABIBtn);
            this.panel2.Location = new System.Drawing.Point(6, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1166, 29);
            this.panel2.TabIndex = 1;
            // 
            // deleteConractsBtn
            // 
            this.deleteConractsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteConractsBtn.BackColor = System.Drawing.Color.Firebrick;
            this.deleteConractsBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteConractsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteConractsBtn.Location = new System.Drawing.Point(1068, 3);
            this.deleteConractsBtn.Name = "deleteConractsBtn";
            this.deleteConractsBtn.Size = new System.Drawing.Size(95, 23);
            this.deleteConractsBtn.TabIndex = 4;
            this.deleteConractsBtn.Text = "Delete All";
            this.deleteConractsBtn.UseVisualStyleBackColor = false;
            this.deleteConractsBtn.Click += new System.EventHandler(this.deleteConractsBtn_Click);
            // 
            // addNewContractBtn
            // 
            this.addNewContractBtn.Location = new System.Drawing.Point(599, 2);
            this.addNewContractBtn.Name = "addNewContractBtn";
            this.addNewContractBtn.Size = new System.Drawing.Size(118, 23);
            this.addNewContractBtn.TabIndex = 3;
            this.addNewContractBtn.Text = "Save Contract";
            this.addNewContractBtn.UseVisualStyleBackColor = true;
            this.addNewContractBtn.Click += new System.EventHandler(this.addNewContractBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contract Address";
            // 
            // contractAddress
            // 
            this.contractAddress.Location = new System.Drawing.Point(107, 3);
            this.contractAddress.Name = "contractAddress";
            this.contractAddress.Size = new System.Drawing.Size(331, 23);
            this.contractAddress.TabIndex = 1;
            // 
            // uploadABIBtn
            // 
            this.uploadABIBtn.Location = new System.Drawing.Point(459, 3);
            this.uploadABIBtn.Name = "uploadABIBtn";
            this.uploadABIBtn.Size = new System.Drawing.Size(134, 23);
            this.uploadABIBtn.TabIndex = 0;
            this.uploadABIBtn.Text = "Upload Build";
            this.uploadABIBtn.UseVisualStyleBackColor = true;
            this.uploadABIBtn.Click += new System.EventHandler(this.uploadABIBtn_Click);
            // 
            // smartContractsGrid
            // 
            this.smartContractsGrid.AllowUserToAddRows = false;
            this.smartContractsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.smartContractsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.smartContractsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.smartContractsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.smartContractsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractName,
            this.Address});
            this.smartContractsGrid.Location = new System.Drawing.Point(-3, 57);
            this.smartContractsGrid.Name = "smartContractsGrid";
            this.smartContractsGrid.RowTemplate.Height = 25;
            this.smartContractsGrid.Size = new System.Drawing.Size(1172, 137);
            this.smartContractsGrid.TabIndex = 0;
            this.smartContractsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.smartContractsGrid_CellContentClick);
            // 
            // ContractName
            // 
            this.ContractName.HeaderText = "Contract Name";
            this.ContractName.Name = "ContractName";
            // 
            // Address
            // 
            this.Address.HeaderText = "Contract Address";
            this.Address.Name = "Address";
            // 
            // mnemonic
            // 
            this.mnemonic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mnemonic.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnemonic.Controls.Add(this.ethBalance);
            this.mnemonic.Controls.Add(this.addressesComboBox);
            this.mnemonic.Controls.Add(this.ethereumAddress);
            this.mnemonic.Controls.Add(this.addressLabel);
            this.mnemonic.Controls.Add(this.mnemonicPhrase);
            this.mnemonic.Controls.Add(this.mnemonicLabel);
            this.mnemonic.Location = new System.Drawing.Point(3, 3);
            this.mnemonic.Name = "mnemonic";
            this.mnemonic.Size = new System.Drawing.Size(1181, 34);
            this.mnemonic.TabIndex = 0;
            // 
            // ethBalance
            // 
            this.ethBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ethBalance.AutoSize = true;
            this.ethBalance.Location = new System.Drawing.Point(1022, 9);
            this.ethBalance.Name = "ethBalance";
            this.ethBalance.Size = new System.Drawing.Size(0, 15);
            this.ethBalance.TabIndex = 8;
            // 
            // addressesComboBox
            // 
            this.addressesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.addressesComboBox.FormattingEnabled = true;
            this.addressesComboBox.Location = new System.Drawing.Point(679, 6);
            this.addressesComboBox.Name = "addressesComboBox";
            this.addressesComboBox.Size = new System.Drawing.Size(315, 23);
            this.addressesComboBox.TabIndex = 7;
            this.addressesComboBox.SelectedIndexChanged += new System.EventHandler(this.addressesComboBox_SelectedIndexChanged);
            // 
            // ethereumAddress
            // 
            this.ethereumAddress.AutoSize = true;
            this.ethereumAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ethereumAddress.Location = new System.Drawing.Point(673, 9);
            this.ethereumAddress.Name = "ethereumAddress";
            this.ethereumAddress.Size = new System.Drawing.Size(0, 15);
            this.ethereumAddress.TabIndex = 6;
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.Black;
            this.addressLabel.Location = new System.Drawing.Point(608, 7);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(59, 17);
            this.addressLabel.TabIndex = 4;
            this.addressLabel.Text = "Address:";
            // 
            // mnemonicPhrase
            // 
            this.mnemonicPhrase.AutoSize = true;
            this.mnemonicPhrase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mnemonicPhrase.Location = new System.Drawing.Point(81, 11);
            this.mnemonicPhrase.Name = "mnemonicPhrase";
            this.mnemonicPhrase.Size = new System.Drawing.Size(100, 15);
            this.mnemonicPhrase.TabIndex = 1;
            this.mnemonicPhrase.Text = "mnemonicPhrase";
            // 
            // mnemonicLabel
            // 
            this.mnemonicLabel.AutoSize = true;
            this.mnemonicLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnemonicLabel.ForeColor = System.Drawing.Color.Black;
            this.mnemonicLabel.Location = new System.Drawing.Point(3, 9);
            this.mnemonicLabel.Name = "mnemonicLabel";
            this.mnemonicLabel.Size = new System.Drawing.Size(72, 17);
            this.mnemonicLabel.TabIndex = 0;
            this.mnemonicLabel.Text = "Mnemonic:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 533);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Ethereum Smart Contracts";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.smartContractsGrid)).EndInit();
            this.mnemonic.ResumeLayout(false);
            this.mnemonic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel mnemonic;
        private Label mnemonicLabel;
        private Label mnemonicPhrase;
        private Label addressLabel;
        private Label ethereumAddress;
        private ComboBox addressesComboBox;
        private Label ethBalance;
        private GroupBox groupBox1;
        private Panel panel2;
        private Button addNewContractBtn;
        private Label label1;
        private TextBox contractAddress;
        private Button uploadABIBtn;
        private DataGridView smartContractsGrid;
        private TableLayoutPanel smartcontracMethodsPanel;
        private TextBox transactionResultTextbox;
        private DataGridViewTextBoxColumn ContractName;
        private DataGridViewTextBoxColumn Address;
        private Button deleteConractsBtn;
    }
}