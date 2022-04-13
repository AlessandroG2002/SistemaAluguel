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
        PessoaCPF pessoacpf = new PessoaCPF();
        PessoaCNPJ pessoacnpj = new PessoaCNPJ();
        Endereco endereco = new Endereco();

        public Cadastro1()
        {
            InitializeComponent();
        }

        public void ReceberCadastroCPF(PessoaCPF pessoa)
        {
            pessoacpf = pessoa;

            comboBox1.SelectedIndex = 0;

            txtCPF.Text = pessoacpf.cpf;

            txtNome.Text = pessoacpf.nome;
            txtEmail.Text = pessoacpf.email;
            txtFiliacao.Text = pessoacpf.filiacao;
            dataPessoa.Value = pessoacpf.data;
        }

        public void ReceberCadastroCNPJ(PessoaCNPJ pessoa)
        {
            pessoacnpj = pessoa;

            comboBox1.SelectedIndex = 1;

            txtCNPJ.Text = pessoacnpj.cnpj;

            txtNome.Text = pessoacnpj.nome;
            txtEmail.Text = pessoacnpj.email;
            txtFiliacao.Text = pessoacnpj.filiacao;
            dataPessoa.Value = pessoacnpj.data;
        }
        public void ReceberEndereco(Endereco endereco) => this.endereco = endereco;

        private void Logo_Click(object sender, EventArgs e)
        {
            Form1 ini = new Form1();

            ini.ReceberEndereco(endereco);

            if (comboBox1.Text == "CPF")
            {
                pessoacpf.nome = txtNome.Text;
                pessoacpf.email = txtEmail.Text;
                pessoacpf.filiacao = txtFiliacao.Text;
                pessoacpf.data = dataPessoa.Value;

                pessoacpf.cpf = txtCPF.Text;

                ini.ReceberCadastroCPF(pessoacpf);
            }
            else if (comboBox1.Text == "CNPJ")
            {
                pessoacnpj.nome = txtNome.Text;
                pessoacnpj.email = txtEmail.Text;
                pessoacnpj.filiacao = txtFiliacao.Text;
                pessoacnpj.data = dataPessoa.Value;

                pessoacnpj.cnpj = txtCNPJ.Text;

                ini.ReceberCadastroCNPJ(pessoacnpj);
            }

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

            if (comboBox1.Text == "CPF")
            {
                pessoacpf.nome = txtNome.Text;
                pessoacpf.email = txtEmail.Text;
                pessoacpf.filiacao = txtFiliacao.Text;
                pessoacpf.data = dataPessoa.Value;

                pessoacpf.cpf = txtCPF.Text;

                cad2.ReceberCadastroCPF(pessoacpf);
            }
            else if (comboBox1.Text == "CNPJ")
            {
                pessoacnpj.nome = txtNome.Text;
                pessoacnpj.email = txtEmail.Text;
                pessoacnpj.filiacao = txtFiliacao.Text;
                pessoacnpj.data = dataPessoa.Value;

                pessoacnpj.cnpj = txtCNPJ.Text;

                cad2.ReceberCadastroCNPJ(pessoacnpj);
            }

            cad2.Show();
            this.Close();
        }
    }
}
