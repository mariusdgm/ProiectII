namespace FormsProiect
{
    partial class LoginForm
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
            this.log_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.user_text = new System.Windows.Forms.TextBox();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.SignIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // log_button
            // 
            this.log_button.Location = new System.Drawing.Point(117, 144);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(75, 23);
            this.log_button.TabIndex = 0;
            this.log_button.Text = "Log In";
            this.log_button.UseVisualStyleBackColor = true;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(223, 144);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // user_text
            // 
            this.user_text.Location = new System.Drawing.Point(117, 59);
            this.user_text.Name = "user_text";
            this.user_text.Size = new System.Drawing.Size(181, 20);
            this.user_text.TabIndex = 2;
            // 
            // pass_text
            // 
            this.pass_text.Location = new System.Drawing.Point(117, 96);
            this.pass_text.Name = "pass_text";
            this.pass_text.PasswordChar = '●';
            this.pass_text.Size = new System.Drawing.Size(181, 20);
            this.pass_text.TabIndex = 3;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(38, 62);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(55, 13);
            this.user.TabIndex = 4;
            this.user.Text = "Username";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(38, 99);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(53, 13);
            this.pass.TabIndex = 5;
            this.pass.Text = "Password";
            // 
            // SignIn
            // 
            this.SignIn.AutoSize = true;
            this.SignIn.Location = new System.Drawing.Point(114, 28);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(66, 13);
            this.SignIn.TabIndex = 6;
            this.SignIn.Text = "Sign In Here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 212);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.user);
            this.Controls.Add(this.pass_text);
            this.Controls.Add(this.user_text);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.log_button);
            this.Name = "Form1";
            this.Text = "Sign In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button log_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TextBox user_text;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.Label SignIn;
    }
}

