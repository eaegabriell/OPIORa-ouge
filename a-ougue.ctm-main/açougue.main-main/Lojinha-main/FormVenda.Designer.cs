namespace SisTDS06
{
    partial class FormVenda
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
            this.lblPedido = new System.Windows.Forms.Label();
            this.txtIdVenda = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.btnLocalizarVenda = new System.Windows.Forms.Button();
            this.dgvVenda = new System.Windows.Forms.DataGridView();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.lblIdProduto = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnNovaVenda = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.btnVendaFinal = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovoItem = new System.Windows.Forms.Button();
            this.btnEditarItem = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnAtualizarPedido = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Location = new System.Drawing.Point(9, 9);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(63, 13);
            this.lblPedido.TabIndex = 0;
            this.lblPedido.Text = "ID Pedido";
            this.lblPedido.Click += new System.EventHandler(this.lblPedido_Click);
            // 
            // txtIdVenda
            // 
            this.txtIdVenda.Location = new System.Drawing.Point(12, 26);
            this.txtIdVenda.Name = "txtIdVenda";
            this.txtIdVenda.Size = new System.Drawing.Size(67, 20);
            this.txtIdVenda.TabIndex = 1;
            this.txtIdVenda.TextChanged += new System.EventHandler(this.txtIdVenda_TextChanged);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(9, 59);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // cbxCliente
            // 
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(12, 76);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(139, 21);
            this.cbxCliente.TabIndex = 3;
            // 
            // btnLocalizarVenda
            // 
            this.btnLocalizarVenda.BackColor = System.Drawing.Color.Red;
            this.btnLocalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalizarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizarVenda.Location = new System.Drawing.Point(196, 23);
            this.btnLocalizarVenda.Name = "btnLocalizarVenda";
            this.btnLocalizarVenda.Size = new System.Drawing.Size(69, 23);
            this.btnLocalizarVenda.TabIndex = 4;
            this.btnLocalizarVenda.Text = "Localizar";
            this.btnLocalizarVenda.UseVisualStyleBackColor = false;
            this.btnLocalizarVenda.Click += new System.EventHandler(this.btnLocalizarVenda_Click);
            // 
            // dgvVenda
            // 
            this.dgvVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenda.Location = new System.Drawing.Point(7, 305);
            this.dgvVenda.Name = "dgvVenda";
            this.dgvVenda.Size = new System.Drawing.Size(610, 130);
            this.dgvVenda.TabIndex = 5;
            this.dgvVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenda_CellClick);
            // 
            // cbxProduto
            // 
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Location = new System.Drawing.Point(12, 126);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(139, 21);
            this.cbxProduto.TabIndex = 7;
            this.cbxProduto.SelectedIndexChanged += new System.EventHandler(this.cbxProduto_SelectedIndexChanged);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(9, 109);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(51, 13);
            this.lblProduto.TabIndex = 6;
            this.lblProduto.Text = "Produto";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(12, 174);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(139, 20);
            this.txtQuantidade.TabIndex = 9;
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(9, 157);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(72, 13);
            this.lblQuantidade.TabIndex = 8;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(12, 222);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(139, 20);
            this.txtPreco.TabIndex = 11;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreco.Location = new System.Drawing.Point(9, 205);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(40, 13);
            this.lblPreco.TabIndex = 10;
            this.lblPreco.Text = "Preço";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Location = new System.Drawing.Point(101, 26);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(72, 20);
            this.txtIdProduto.TabIndex = 13;
            // 
            // lblIdProduto
            // 
            this.lblIdProduto.AutoSize = true;
            this.lblIdProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProduto.Location = new System.Drawing.Point(98, 9);
            this.lblIdProduto.Name = "lblIdProduto";
            this.lblIdProduto.Size = new System.Drawing.Size(68, 13);
            this.lblIdProduto.TabIndex = 12;
            this.lblIdProduto.Text = "ID Produto";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(147, 273);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 275);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(129, 16);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "TOTAL DO PEDIDO";
            // 
            // btnNovaVenda
            // 
            this.btnNovaVenda.BackColor = System.Drawing.Color.Red;
            this.btnNovaVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNovaVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaVenda.Location = new System.Drawing.Point(295, 264);
            this.btnNovaVenda.Name = "btnNovaVenda";
            this.btnNovaVenda.Size = new System.Drawing.Size(85, 23);
            this.btnNovaVenda.TabIndex = 16;
            this.btnNovaVenda.Text = "Novo Pedido";
            this.btnNovaVenda.UseVisualStyleBackColor = false;
            this.btnNovaVenda.Click += new System.EventHandler(this.btnNovaVenda_Click);
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.BackColor = System.Drawing.Color.Red;
            this.btnFinalizarVenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizarVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.Location = new System.Drawing.Point(399, 264);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(85, 23);
            this.btnFinalizarVenda.TabIndex = 17;
            this.btnFinalizarVenda.Text = "Finalizar Pedido";
            this.btnFinalizarVenda.UseVisualStyleBackColor = false;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // btnVendaFinal
            // 
            this.btnVendaFinal.BackColor = System.Drawing.Color.Red;
            this.btnVendaFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVendaFinal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVendaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendaFinal.Location = new System.Drawing.Point(446, 463);
            this.btnVendaFinal.Name = "btnVendaFinal";
            this.btnVendaFinal.Size = new System.Drawing.Size(85, 23);
            this.btnVendaFinal.TabIndex = 18;
            this.btnVendaFinal.Text = "Venda";
            this.btnVendaFinal.UseVisualStyleBackColor = false;
            this.btnVendaFinal.Click += new System.EventHandler(this.btnVendaFinal_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Red;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(553, 463);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 19;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovoItem
            // 
            this.btnNovoItem.BackColor = System.Drawing.Color.Red;
            this.btnNovoItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovoItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNovoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoItem.Location = new System.Drawing.Point(196, 74);
            this.btnNovoItem.Name = "btnNovoItem";
            this.btnNovoItem.Size = new System.Drawing.Size(69, 23);
            this.btnNovoItem.TabIndex = 20;
            this.btnNovoItem.Text = "Adicionar Produto";
            this.btnNovoItem.UseVisualStyleBackColor = false;
            this.btnNovoItem.Click += new System.EventHandler(this.btnNovoItem_Click);
            // 
            // btnEditarItem
            // 
            this.btnEditarItem.BackColor = System.Drawing.Color.Red;
            this.btnEditarItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditarItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarItem.Location = new System.Drawing.Point(196, 109);
            this.btnEditarItem.Name = "btnEditarItem";
            this.btnEditarItem.Size = new System.Drawing.Size(69, 23);
            this.btnEditarItem.TabIndex = 21;
            this.btnEditarItem.Text = "Editar Produto";
            this.btnEditarItem.UseVisualStyleBackColor = false;
            this.btnEditarItem.Click += new System.EventHandler(this.btnEditarItem_Click);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.BackColor = System.Drawing.Color.Red;
            this.btnExcluirItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcluirItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluirItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirItem.Location = new System.Drawing.Point(196, 147);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(69, 23);
            this.btnExcluirItem.TabIndex = 22;
            this.btnExcluirItem.Text = "Excluir Produto";
            this.btnExcluirItem.UseVisualStyleBackColor = false;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            // 
            // btnAtualizarPedido
            // 
            this.btnAtualizarPedido.BackColor = System.Drawing.Color.Red;
            this.btnAtualizarPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAtualizarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarPedido.Location = new System.Drawing.Point(501, 264);
            this.btnAtualizarPedido.Name = "btnAtualizarPedido";
            this.btnAtualizarPedido.Size = new System.Drawing.Size(85, 23);
            this.btnAtualizarPedido.TabIndex = 23;
            this.btnAtualizarPedido.Text = "Atualizar Pedido";
            this.btnAtualizarPedido.UseVisualStyleBackColor = false;
            this.btnAtualizarPedido.Click += new System.EventHandler(this.btnAtualizarPedido_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Magneto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 35);
            this.label1.TabIndex = 24;
            this.label1.Text = "Açougue SENAI";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisTDS06.Properties.Resources.vaga_aux_acougueiro;
            this.pictureBox1.Location = new System.Drawing.Point(325, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // FormVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 498);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtualizarPedido);
            this.Controls.Add(this.btnExcluirItem);
            this.Controls.Add(this.btnEditarItem);
            this.Controls.Add(this.btnNovoItem);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnVendaFinal);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.btnNovaVenda);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.lblIdProduto);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.cbxProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.dgvVenda);
            this.Controls.Add(this.btnLocalizarVenda);
            this.Controls.Add(this.cbxCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtIdVenda);
            this.Controls.Add(this.lblPedido);
            this.Name = "FormVenda";
            this.Text = "VENDA";
            this.Load += new System.EventHandler(this.FormVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.TextBox txtIdVenda;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.Button btnLocalizarVenda;
        private System.Windows.Forms.DataGridView dgvVenda;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.Label lblIdProduto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnNovaVenda;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Button btnVendaFinal;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovoItem;
        private System.Windows.Forms.Button btnEditarItem;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnAtualizarPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}