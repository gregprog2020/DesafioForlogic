using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Locadora_1._2.Code.BLL;
using Locadora_1._2.Code.DTO;

namespace Locadora_1._2
{
    public partial class frmCadastroFilmes : Form
    {
        CadastroFilmeBLL bll = new CadastroFilmeBLL();
        CadastroFilmeDTO dto = new CadastroFilmeDTO();
        public frmCadastroFilmes()
        {
            InitializeComponent();
        }

        private void frmCadastroFilmes_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            grid1.DataSource = bll.SelecionaTodosFilmes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbID.Text = grid1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txbTitulo.Text = grid1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txbGenero.Text = grid1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            dto.Titulo = txbTitulo.Text;
            dto.Genero = txbGenero.Text;

            if (txbID.Text == "")
            {
                bll.Inserir(dto);
                MessageBox.Show(" Cadastrado com Sucesso!", "Inserido com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dto.Id = int.Parse(txbID.Text);
                bll.Atualizar(dto);
                MessageBox.Show(" Atualizado com Sucesso!", "Atualização com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LimparTela();
            CarregarGrid();
        }
        private void LimparTela()
        {
            txbID.Clear();
            txbTitulo.Clear();
            txbGenero.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txbID.Text != "")
            {

                var result = MessageBox.Show("Deseja realmente excluir?", "Exclusão Filme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bll.Excluir(txbID.Text);
                    MessageBox.Show(" Excluido com Sucesso!", "Exclusão com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparTela();
                    CarregarGrid();
                }
            }

        }
    }

    
}
