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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadPedidos();
        }

        private void LoadPedidos()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("SELECT Nome, SUM(Quantidade) Quantidade ");
            sbQuery.Append("FROM dbo.Pedidos q ");
            sbQuery.Append("INNER JOIN dbo.Itens n ON n.ItemId = q.ItemId ");
            sbQuery.Append("GROUP BY Nome");

            string query = sbQuery.ToString();
            DataSet dataset = DatabaseOperations.DatabaseSelect(query, "Pedidos");

            var data = Fill(dataset);

            dtgSumario.ReadOnly = true;
            dtgSumario.DataSource = data;
            dtgSumario.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgSumario.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Close();
        }

        public List<Sumario> Fill(DataSet dataset)
        {
            try
            {
                var list = new List<Sumario>();

                foreach (DataRow item in dataset.Tables[0].Rows)
                {
                    var Sumario = new Sumario();
                    Sumario.Nome = Desafio.Validations.Validations.ValidateValue("", item, "Nome");
                    Sumario.Quantidade = Desafio.Validations.Validations.ValidateValue(0, item, "Quantidade");
                    list.Add(Sumario);
                }
                return list;
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}
