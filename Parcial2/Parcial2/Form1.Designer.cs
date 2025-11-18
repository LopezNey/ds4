namespace Parcial2
{
    partial class Conversor
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
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            this.btn_Historial = new System.Windows.Forms.Button();
            this.list_Historial = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Tamano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Resultado = new System.Windows.Forms.TextBox();
            this.btn_Conversor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de archivos";
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Location = new System.Drawing.Point(268, 48);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(100, 26);
            this.txt_Cantidad.TabIndex = 1;
            // 
            // btn_Historial
            // 
            this.btn_Historial.Location = new System.Drawing.Point(377, 225);
            this.btn_Historial.Name = "btn_Historial";
            this.btn_Historial.Size = new System.Drawing.Size(87, 36);
            this.btn_Historial.TabIndex = 3;
            this.btn_Historial.Text = "Historial";
            this.btn_Historial.UseVisualStyleBackColor = true;
            this.btn_Historial.Click += new System.EventHandler(this.btn_Historial_Click);
            // 
            // list_Historial
            // 
            this.list_Historial.FormattingEnabled = true;
            this.list_Historial.ItemHeight = 20;
            this.list_Historial.Location = new System.Drawing.Point(236, 279);
            this.list_Historial.Name = "list_Historial";
            this.list_Historial.Size = new System.Drawing.Size(362, 144);
            this.list_Historial.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tamaño en MB";
            // 
            // txt_Tamano
            // 
            this.txt_Tamano.Location = new System.Drawing.Point(268, 112);
            this.txt_Tamano.Name = "txt_Tamano";
            this.txt_Tamano.Size = new System.Drawing.Size(100, 26);
            this.txt_Tamano.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Resultado";
            // 
            // txt_Resultado
            // 
            this.txt_Resultado.Location = new System.Drawing.Point(666, 89);
            this.txt_Resultado.Name = "txt_Resultado";
            this.txt_Resultado.Size = new System.Drawing.Size(100, 26);
            this.txt_Resultado.TabIndex = 8;
            // 
            // btn_Conversor
            // 
            this.btn_Conversor.Location = new System.Drawing.Point(428, 83);
            this.btn_Conversor.Name = "btn_Conversor";
            this.btn_Conversor.Size = new System.Drawing.Size(99, 39);
            this.btn_Conversor.TabIndex = 9;
            this.btn_Conversor.Text = "Convertir";
            this.btn_Conversor.UseVisualStyleBackColor = true;
            this.btn_Conversor.Click += new System.EventHandler(this.btn_Conversor_Click);
            // 
            // Conversor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Conversor);
            this.Controls.Add(this.txt_Resultado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Tamano);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_Historial);
            this.Controls.Add(this.btn_Historial);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.label1);
            this.Name = "Conversor";
            this.Text = "Conversor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cantidad;
        private System.Windows.Forms.Button btn_Historial;
        private System.Windows.Forms.ListBox list_Historial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Tamano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Resultado;
        private System.Windows.Forms.Button btn_Conversor;
    }
}

