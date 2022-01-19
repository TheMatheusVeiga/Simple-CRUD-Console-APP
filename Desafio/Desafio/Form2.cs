using Desafio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desafio.Connection;

namespace Desafio
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Global.Update)
            {
                EditPedido(Global._id);
            } else
            {
                GetItem();
            }
        }

        public void GetItem(int id = -1)
        {

            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT * FROM[dbo].[Itens]");
            string query = sbQuery.ToString();

            DataSet dataset = DatabaseOperations.DatabaseSelect(query, "Itens");
            var data = FillItem(dataset);

            for (int i = 0; i < data.Count; i++)
            {
                cbAddItem.Items.Add(data[i].Nome);
            }

            if (id != -1)
            {
                StringBuilder sbQuery2 = new StringBuilder();
                sbQuery2.Append("SELECT PedidoId, Nome, Quantidade FROM dbo.Pedidos p INNER JOIN dbo.Itens i ON i.ItemId = p.ItemId WHERE PedidoId = " + id);
                string query2 = sbQuery2.ToString();

                DataSet dataset2 = DatabaseOperations.DatabaseSelect(query2, "Pedidos");
                var data2 = FillSinglePedido(dataset2);

                cbAddItem.Text = data2[0].Item;
                txtAddQuantidade.Text = data2[0].Quantidade.ToString();
                btnAddPedido.Text = "Editar";
            }
            else
            {
                cbAddItem.Text = "Selecione o item";
            }
            cbAddItem.ValueMember = "Items";
            cbAddItem.DisplayMember = "Items";
        }

        public void EditPedido(int id)
        {
            try
            {
                if (id < 0)
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Erro ao selecionar item a ser editado.", "Erro!");
                }
                GetItem(Global._id);                
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private List<Pedidos> FillSinglePedido(DataSet dataset)
        {
            try
            {
                var list = new List<Pedidos>();

                foreach (DataRow item in dataset.Tables[0].Rows)
                {
                    var Pedidos = new Pedidos();
                    Pedidos.Id = Desafio.Validations.Validations.ValidateValue(0, item, "PedidoId");
                    Pedidos.Item = Desafio.Validations.Validations.ValidateValue("", item, "Nome");
                    Pedidos.Quantidade = Desafio.Validations.Validations.ValidateValue(0, item, "Quantidade");
                    list.Add(Pedidos);
                }
                return list;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        private void txtAddQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAddQuantidade_Enter(object sender, EventArgs e)
        {
            txtAddQuantidade.Text = null;
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            this.Close();
        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            int operation = 0;
            string message = "";

            try
            {
                if (cbAddItem.SelectedItem == null || txtAddQuantidade.Text == null || txtAddQuantidade.Text == "" || Convert.ToInt32(txtAddQuantidade.Text) < 1 )
                {

                    DialogResult result = Desafio.Interations.Interations.DispatchError("Dados preenchidos incorretamente.", "Dados incorretos!");
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                }

                if (Global._update)
                {
                    operation = UpdatePedido();
                    message = "Pedido atualizado com sucesso.";
                } else
                {
                    operation = AddPedido();
                    message = "Pedido realizado com sucesso.";
                }                

                if (operation <= 0)
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Erro ao realizar operação.", "Erro!");
                }
                else
                {
                    Global.Update = false;
                    Global.Id = 0;

                    DialogResult result = Desafio.Interations.Interations.DispatchError(message, "Sucesso!");
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public List<Items> FillItem(DataSet dataset)
        {
            try
            {
                var list = new List<Items>();

                foreach (DataRow item in dataset.Tables[0].Rows)
                {
                    var Items = new Items();
                    Items.Nome = Desafio.Validations.Validations.ValidateValue("", item, "Nome");
                    list.Add(Items);
                }
                return list;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        public int AddPedido()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("INSERT INTO [dbo].[Pedidos] ([ItemId],[Quantidade]) VALUES (");
            sbQuery.Append("(SELECT ItemId FROM [dbo].[Itens] WHERE Nome = '" + cbAddItem.SelectedItem.ToString() + "'), ");
            sbQuery.Append(Convert.ToInt32(txtAddQuantidade.Text));
            sbQuery.Append(")");

            string query = sbQuery.ToString();
            return  DatabaseOperations.DatabaseInserUpdateDelete(query);
        }

        public int UpdatePedido()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("UPDATE dbo.Pedidos ");
            sbQuery.Append("SET ItemId = (SELECT ItemId FROM dbo.Itens WHERE Nome = '" + cbAddItem.SelectedItem.ToString() + "'), ");
            sbQuery.Append("Quantidade = " + Convert.ToInt32(txtAddQuantidade.Text));
            sbQuery.Append(" WHERE PedidoId = " + Global._id);

            string query = sbQuery.ToString();
            return DatabaseOperations.DatabaseInserUpdateDelete(query);
        }

        private void txtAddQuantidade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
