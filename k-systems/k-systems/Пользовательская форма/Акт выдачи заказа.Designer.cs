﻿namespace k_systems.Пользовательская_форма
{
    partial class Заказ_для_клиента
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Заказ_для_клиента));
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Postponed = new System.Windows.Forms.CheckBox();
            this.Work = new System.Windows.Forms.CheckBox();
            this.Ready = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKindWork = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTypeWork = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrint.Location = new System.Drawing.Point(819, 357);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 30);
            this.btnPrint.TabIndex = 124;
            this.btnPrint.Text = "Печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tbPhone);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.Postponed);
            this.panel.Controls.Add(this.Work);
            this.panel.Controls.Add(this.Ready);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.tbPrice);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.tbKindWork);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.tbTypeWork);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.textBoxFIO);
            this.panel.Controls.Add(this.labelFIO);
            this.panel.Controls.Add(this.label22);
            this.panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(919, 339);
            this.panel.TabIndex = 126;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(213, 138);
            this.tbPhone.MaxLength = 11;
            this.tbPhone.Multiline = true;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.ReadOnly = true;
            this.tbPhone.Size = new System.Drawing.Size(276, 29);
            this.tbPhone.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 133;
            this.label2.Text = "Телефон";
            // 
            // Postponed
            // 
            this.Postponed.AutoSize = true;
            this.Postponed.Location = new System.Drawing.Point(632, 298);
            this.Postponed.Name = "Postponed";
            this.Postponed.Size = new System.Drawing.Size(89, 21);
            this.Postponed.TabIndex = 132;
            this.Postponed.Text = "Отложен";
            this.Postponed.UseVisualStyleBackColor = true;
            // 
            // Work
            // 
            this.Work.AutoSize = true;
            this.Work.Location = new System.Drawing.Point(632, 218);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(90, 21);
            this.Work.TabIndex = 131;
            this.Work.Text = "В работе";
            this.Work.UseVisualStyleBackColor = true;
            // 
            // Ready
            // 
            this.Ready.AutoSize = true;
            this.Ready.Location = new System.Drawing.Point(632, 260);
            this.Ready.Name = "Ready";
            this.Ready.Size = new System.Drawing.Size(68, 21);
            this.Ready.TabIndex = 130;
            this.Ready.Text = "Готов";
            this.Ready.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(491, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 129;
            this.label1.Text = "Статус заказа";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(213, 219);
            this.tbPrice.MaxLength = 6;
            this.tbPrice.Multiline = true;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(276, 29);
            this.tbPrice.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(15, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 21);
            this.label5.TabIndex = 127;
            this.label5.Text = "Цена";
            // 
            // tbKindWork
            // 
            this.tbKindWork.Location = new System.Drawing.Point(213, 173);
            this.tbKindWork.MaxLength = 4;
            this.tbKindWork.Multiline = true;
            this.tbKindWork.Name = "tbKindWork";
            this.tbKindWork.ReadOnly = true;
            this.tbKindWork.Size = new System.Drawing.Size(692, 29);
            this.tbKindWork.TabIndex = 126;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 125;
            this.label4.Text = "Тип работы";
            // 
            // tbTypeWork
            // 
            this.tbTypeWork.Location = new System.Drawing.Point(213, 103);
            this.tbTypeWork.MaxLength = 11;
            this.tbTypeWork.Multiline = true;
            this.tbTypeWork.Name = "tbTypeWork";
            this.tbTypeWork.ReadOnly = true;
            this.tbTypeWork.Size = new System.Drawing.Size(276, 29);
            this.tbTypeWork.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 119;
            this.label3.Text = "Вид работы";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(213, 57);
            this.textBoxFIO.MaxLength = 30;
            this.textBoxFIO.Multiline = true;
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.ReadOnly = true;
            this.textBoxFIO.Size = new System.Drawing.Size(276, 29);
            this.textBoxFIO.TabIndex = 103;
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFIO.Location = new System.Drawing.Point(17, 59);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(46, 21);
            this.labelFIO.TabIndex = 22;
            this.labelFIO.Text = "ФИО";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(271, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(186, 21);
            this.label22.TabIndex = 3;
            this.label22.Text = "Акт выдачии заказа";
            // 
            // Заказ_для_клиента
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 408);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Заказ_для_клиента";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Акт выдачи заказа";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Postponed;
        private System.Windows.Forms.CheckBox Work;
        private System.Windows.Forms.CheckBox Ready;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKindWork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTypeWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label label22;
    }
}