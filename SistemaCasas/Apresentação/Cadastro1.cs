using SistemaCasas.Apresentação;
using SistemaCasas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCasas.Apresentação
{
    public partial class Cadastro1 : Form
    {
        Pessoa pessoa = new Pessoa();
        Endereco endereco = new Endereco();

        public Cadastro1()
        {
            InitializeComponent();
        }

        public void ReceberPessoa(Pessoa pessoa)
        {
            this.pessoa = pessoa;

            if (pessoa.isCNPJ == false)
            {
                comboBox1.SelectedIndex = 0;
                txtCPF.Text = pessoa.cpf;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
                txtCNPJ.Text = pessoa.cnpj;
            }

            txtNome.Text = pessoa.nome;
            txtEmail.Text = pessoa.email;
            txtFiliacao.Text = pessoa.filiacao;
            dataPessoa.Value = pessoa.data;
        }

        public void ReceberEndereco(Endereco endereco) => this.endereco = endereco;

        private void Logo_Click(object sender, EventArgs e)
        {
            Form1 ini = new Form1();

            ini.ReceberEndereco(endereco);

            pessoa.nome = txtNome.Text;
            pessoa.email = txtEmail.Text;
            pessoa.filiacao = txtFiliacao.Text;
            pessoa.data = dataPessoa.Value;

            if (comboBox1.Text == "CPF")
            {
                pessoa.cpf = txtCPF.Text;
                pessoa.isCNPJ = false;
            }
            else if (comboBox1.Text == "CNPJ")
            {
                pessoa.cnpj = txtCNPJ.Text;
                pessoa.isCNPJ = true;
            }

            ini.ReceberPessoa(pessoa);

            ini.Show();
            this.Close();
        }

        private void labelSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "CPF")
            {
                labelCNPJ.Hide();
                txtCNPJ.Clear();
                txtCNPJ.Hide();

                labelData.Text = "Data de nascimento";

                labelCPF.Show();
                txtCPF.Show();
            }
            else if (comboBox1.Text == "CNPJ")
            {
                labelCPF.Hide();
                txtCPF.Clear();
                txtCPF.Hide();

                labelData.Text = "Data de abertura";

                labelCNPJ.Show();
                txtCNPJ.Show();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            Cadastro2 cad2 = new Cadastro2();

            cad2.ReceberEndereco(endereco);

            pessoa.nome = txtNome.Text;
            pessoa.email = txtEmail.Text;
            pessoa.filiacao = txtFiliacao.Text;
            pessoa.data = dataPessoa.Value;

            if (comboBox1.Text == "CPF")
            {
                pessoa.cpf = txtCPF.Text;
                pessoa.isCNPJ = false;
            }
            else if (comboBox1.Text == "CNPJ")
            {
                pessoa.cnpj = txtCNPJ.Text;
                pessoa.isCNPJ = true;
            }

            cad2.ReceberPessoa(pessoa);

            cad2.Show();
            this.Close();
        }
    }
}
