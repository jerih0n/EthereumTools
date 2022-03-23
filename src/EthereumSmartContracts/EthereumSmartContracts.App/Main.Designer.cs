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
            this.mnemonic = new System.Windows.Forms.Panel();
            this.ethBalance = new System.Windows.Forms.Label();
            this.addressesComboBox = new System.Windows.Forms.ComboBox();
            this.ethereumAddress = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.mnemonicPhrase = new System.Windows.Forms.Label();
            this.mnemonicLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.mnemonic);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 509);
            this.panel1.TabIndex = 0;
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
            this.ethBalance.Size = new System.Drawing.Size(38, 15);
            this.ethBalance.TabIndex = 8;
            this.ethBalance.Text = "label1";
            // 
            // addressesComboBox
            // 
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
    }
}