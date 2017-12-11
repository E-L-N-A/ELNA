namespace Prototype
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Image_Panel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Notification_Label = new MaterialSkin.Controls.MaterialLabel();
            this.LanguageConfirmatio = new MaterialSkin.Controls.MaterialFlatButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Step1_Panel = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Step2_Panel = new MaterialSkin.Controls.MaterialLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Done = new MaterialSkin.Controls.MaterialFlatButton();
            this.MAINPAGE = new MaterialSkin.Controls.MaterialFlatButton();
            this.Step1_Panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Image_Panel
            // 
            this.Image_Panel.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.Image_Panel, "Image_Panel");
            this.Image_Panel.Name = "Image_Panel";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Notification_Label
            // 
            resources.ApplyResources(this.Notification_Label, "Notification_Label");
            this.Notification_Label.BackColor = System.Drawing.Color.White;
            this.Notification_Label.Depth = 0;
            this.Notification_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Notification_Label.MouseState = MaterialSkin.MouseState.HOVER;
            this.Notification_Label.Name = "Notification_Label";
            // 
            // LanguageConfirmatio
            // 
            resources.ApplyResources(this.LanguageConfirmatio, "LanguageConfirmatio");
            this.LanguageConfirmatio.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LanguageConfirmatio.Depth = 0;
            this.LanguageConfirmatio.MouseState = MaterialSkin.MouseState.HOVER;
            this.LanguageConfirmatio.Name = "LanguageConfirmatio";
            this.LanguageConfirmatio.Primary = false;
            this.LanguageConfirmatio.UseVisualStyleBackColor = false;
            this.LanguageConfirmatio.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Step1_Panel
            // 
            this.Step1_Panel.BackColor = System.Drawing.Color.White;
            this.Step1_Panel.Controls.Add(this.materialLabel2);
            this.Step1_Panel.Controls.Add(this.LanguageConfirmatio);
            this.Step1_Panel.Controls.Add(this.comboBox1);
            resources.ApplyResources(this.Step1_Panel, "Step1_Panel");
            this.Step1_Panel.Name = "Step1_Panel";
            // 
            // materialLabel2
            // 
            resources.ApplyResources(this.materialLabel2, "materialLabel2");
            this.materialLabel2.BackColor = System.Drawing.Color.White;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.Step2_Panel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // Step2_Panel
            // 
            resources.ApplyResources(this.Step2_Panel, "Step2_Panel");
            this.Step2_Panel.BackColor = System.Drawing.Color.White;
            this.Step2_Panel.Depth = 0;
            this.Step2_Panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Step2_Panel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Step2_Panel.Name = "Step2_Panel";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Done
            // 
            resources.ApplyResources(this.Done, "Done");
            this.Done.Depth = 0;
            this.Done.MouseState = MaterialSkin.MouseState.HOVER;
            this.Done.Name = "Done";
            this.Done.Primary = false;
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // MAINPAGE
            // 
            resources.ApplyResources(this.MAINPAGE, "MAINPAGE");
            this.MAINPAGE.Depth = 0;
            this.MAINPAGE.MouseState = MaterialSkin.MouseState.HOVER;
            this.MAINPAGE.Name = "MAINPAGE";
            this.MAINPAGE.Primary = false;
            this.MAINPAGE.UseVisualStyleBackColor = true;
            this.MAINPAGE.Click += new System.EventHandler(this.MAINPAGE_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MAINPAGE);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Step1_Panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Notification_Label);
            this.Controls.Add(this.Image_Panel);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Step1_Panel.ResumeLayout(false);
            this.Step1_Panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Image_Panel;
        private System.Windows.Forms.ComboBox comboBox1;
        private MaterialSkin.Controls.MaterialLabel Notification_Label;
        private MaterialSkin.Controls.MaterialFlatButton LanguageConfirmatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Step1_Panel;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private MaterialSkin.Controls.MaterialLabel Step2_Panel;
        private MaterialSkin.Controls.MaterialFlatButton Done;
        private MaterialSkin.Controls.MaterialFlatButton MAINPAGE;
    }
}

