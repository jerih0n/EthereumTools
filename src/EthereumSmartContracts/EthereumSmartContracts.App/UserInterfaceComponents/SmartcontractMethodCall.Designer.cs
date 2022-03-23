namespace EthereumSmartContracts.App.UserInterfaceComponents
{
    partial class SmartcontractMethodCall
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.callFunctionBtn = new System.Windows.Forms.Button();
            this.parameterInputsTxtBox = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // callFunctionBtn
            // 
            this.callFunctionBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.callFunctionBtn.Location = new System.Drawing.Point(0, 0);
            this.callFunctionBtn.Name = "callFunctionBtn";
            this.callFunctionBtn.Size = new System.Drawing.Size(216, 29);
            this.callFunctionBtn.TabIndex = 0;
            this.callFunctionBtn.Text = "button1";
            this.callFunctionBtn.UseVisualStyleBackColor = true;
            this.callFunctionBtn.Click += new System.EventHandler(this.callFunctionBtn_Click);
            // 
            // parameterInputsTxtBox
            // 
            this.parameterInputsTxtBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.parameterInputsTxtBox.Location = new System.Drawing.Point(222, 0);
            this.parameterInputsTxtBox.Name = "parameterInputsTxtBox";
            this.parameterInputsTxtBox.Size = new System.Drawing.Size(848, 29);
            this.parameterInputsTxtBox.TabIndex = 1;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.result.Location = new System.Drawing.Point(143, 32);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(38, 15);
            this.result.TabIndex = 2;
            this.result.Text = "label1";
            // 
            // SmartcontractMethodCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.result);
            this.Controls.Add(this.parameterInputsTxtBox);
            this.Controls.Add(this.callFunctionBtn);
            this.Name = "SmartcontractMethodCall";
            this.Size = new System.Drawing.Size(1089, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button callFunctionBtn;
        private TextBox parameterInputsTxtBox;
        private Label result;
    }
}
