namespace FormsProiect
{
    partial class BrowseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prod_list = new System.Windows.Forms.ListBox();
            this.cat_list = new System.Windows.Forms.ListBox();
            this.del_button = new System.Windows.Forms.Button();
            this.insert_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(612, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Products";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Click on one of the products to get more information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Click on one of the categories to see the products";
            // 
            // prod_list
            // 
            this.prod_list.FormattingEnabled = true;
            this.prod_list.Location = new System.Drawing.Point(368, 103);
            this.prod_list.Name = "prod_list";
            this.prod_list.Size = new System.Drawing.Size(293, 186);
            this.prod_list.TabIndex = 11;
            // 
            // cat_list
            // 
            this.cat_list.FormattingEnabled = true;
            this.cat_list.Location = new System.Drawing.Point(31, 103);
            this.cat_list.Name = "cat_list";
            this.cat_list.Size = new System.Drawing.Size(293, 186);
            this.cat_list.TabIndex = 12;
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(586, 37);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(75, 23);
            this.del_button.TabIndex = 13;
            this.del_button.Text = "Delete";
            this.del_button.UseVisualStyleBackColor = true;
            // 
            // insert_button
            // 
            this.insert_button.Location = new System.Drawing.Point(505, 37);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(75, 23);
            this.insert_button.TabIndex = 14;
            this.insert_button.Text = "Insert";
            this.insert_button.UseVisualStyleBackColor = true;
            // 
            // BrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 349);
            this.Controls.Add(this.insert_button);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.cat_list);
            this.Controls.Add(this.prod_list);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BrowseForm";
            this.Text = "Browse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox prod_list;
        private System.Windows.Forms.ListBox cat_list;
        private System.Windows.Forms.Button del_button;
        private System.Windows.Forms.Button insert_button;
    }
}