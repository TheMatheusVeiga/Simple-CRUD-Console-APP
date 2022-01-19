using Desafio.Connection;
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

namespace Desafio
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Global.Update = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPedidos();
        }

        public void GetPedidos()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT PedidoId, Nome, Quantidade FROM dbo.Pedidos p INNER JOIN dbo.Itens i ON i.ItemId = p.ItemId");
            string query = sbQuery.ToString();

            DataSet dataset = DatabaseOperations.DatabaseSelect(query, "Pedidos");

            var data = Fill(dataset);

            //verificação TO-DO

            dtgPedidos.ReadOnly = true;
            dtgPedidos.DataSource = data;
            dtgPedidos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgPedidos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public void DeletePedido(int id)
        {
            try
            {
                if(id < 0)
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Erro ao selecionar item a ser excluido.", "Erro!");
                }

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append("DELETE FROM dbo.Pedidos WHERE PedidoId = " + id);
                string query = sbQuery.ToString();

                int delete = DatabaseOperations.DatabaseInserUpdateDelete(query);
                if (delete <= 0)
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Erro ao Excluir o pedido.", "Erro!");
                }
                else
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Pedido Excluido com sucesso.", "Sucesso!");
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        GetPedidos();
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private List<Pedidos> Fill(DataSet dataset)
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

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            Form2 FInserir = new Form2();
            FInserir.ShowDialog();
        }

        private void btn_sumario_Click(object sender, EventArgs e)
        {
            Form3 FSumario = new Form3();
            FSumario.ShowDialog();
        }

        private void dtgPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgPedidos.Columns[e.ColumnIndex].Name == "Excluir")
            {
                if(Desafio.Interations.Interations.DispatchChoise("Deseja realmente excluir o pedido ?", "Confirmar Exclusão") == DialogResult.Yes)
                {
                    DeletePedido(Convert.ToInt32(dtgPedidos.Rows[e.RowIndex].Cells[0].Value));
                }
            }

            if(dtgPedidos.Columns[e.ColumnIndex].Name == "Editar")
            {
                Global.Update = true;
                Global.Id = Convert.ToInt32(dtgPedidos.Rows[e.RowIndex].Cells[0].Value);

                if (Global.Id < 0)
                {
                    DialogResult result = Desafio.Interations.Interations.DispatchError("Erro ao selecionar item a ser editado.", "Erro!");
                }
                else
                {
                    Form2 fr2 = new Form2();
                    fr2.ShowDialog();
                }
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            GetPedidos();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            GetPedidos();
        }
    }
}
