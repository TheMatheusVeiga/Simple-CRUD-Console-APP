namespace Desafio
{
    partial class Form2
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
            this.cbAddItem = new System.Windows.Forms.ComboBox();
            this.txtAddQuantidade = new System.Windows.Forms.TextBox();
            this.btnAddPedido = new System.Windows.Forms.Button();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantidade:";
            // 
            // cbAddItem
            // 
            this.cbAddItem.FormattingEnabled = true;
            this.cbAddItem.Location = new System.Drawing.Point(126, 11);
            this.cbAddItem.Name = "cbAddItem";
            this.cbAddItem.Size = new System.Drawing.Size(252, 21);
            this.cbAddItem.TabIndex = 2;
            // 
            // txtAddQuantidade
            // 
            this.txtAddQuantidade.Location = new System.Drawing.Point(126, 38);
            this.txtAddQuantidade.Name = "txtAddQuantidade";
            this.txtAddQuantidade.Size = new System.Drawing.Size(252, 20);
            this.txtAddQuantidade.TabIndex = 4;
            this.txtAddQuantidade.Text = "Quantidade";
            this.txtAddQuantidade.TextChanged += new System.EventHandler(this.txtAddQuantidade_TextChanged);
            this.txtAddQuantidade.Enter += new System.EventHandler(this.txtAddQuantidade_Enter);
            this.txtAddQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddQuantidade_KeyPress);
            // 
            // btnAddPedido
            // 
            this.btnAddPedido.Location = new System.Drawing.Point(16, 98);
            this.btnAddPedido.Name = "btnAddPedido";
            this.btnAddPedido.Size = new System.Drawing.Size(72, 23);
            this.btnAddPedido.TabIndex = 5;
            this.btnAddPedido.Text = "Salvar";
            this.btnAddPedido.UseVisualStyleBackColor = true;
            this.btnAddPedido.Click += new System.EventHandler(this.btnAddPedido_Click);
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.Location = new System.Drawing.Point(94, 98);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(74, 23);
            this.btnCancelarPedido.TabIndex = 6;
            this.btnCancelarPedido.Text = "Cancelar";
            this.btnCancelarPedido.UseVisualStyleBackColor = true;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 133);
            this.Controls.Add(this.btnCancelarPedido);
            this.Controls.Add(this.btnAddPedido);
            this.Controls.Add(this.txtAddQuantidade);
            this.Controls.Add(this.cbAddItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir/Editar Pedidos";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAddItem;
        private System.Windows.Forms.TextBox txtAddQuantidade;
        private System.Windows.Forms.Button btnAddPedido;
        private System.Windows.Forms.Button btnCancelarPedido;
    }
}