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
    public partial class Cadastro2 : Form
    {
        PessoaCPF pessoacpf = new PessoaCPF();
        PessoaCNPJ pessoacnpj = new PessoaCNPJ();
        Endereco endereco = new Endereco();

        public Cadastro2()
        {
            InitializeComponent();
        }

        public void ReceberCadastroCPF(PessoaCPF pessoa) => this.pessoacpf = pessoa;

        public void ReceberCadastroCNPJ(PessoaCNPJ pessoa) => this.pessoacnpj = pessoa;

        public void ReceberEndereco(Endereco endereco)
        {
            this.endereco = endereco;

            txtNumero.Text = endereco.numero;
            txtBairro.Text = endereco.bairro;
            txtCEP.Text = endereco.cep;
            txtEndereco.Text = endereco.endereco;
            txtUF.Text = endereco.estado;
            txtCidade.Text = endereco.cidade;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Form1 ini = new Form1();

            endereco.numero = txtNumero.Text;
            endereco.bairro = txtBairro.Text;
            endereco.cep = txtCEP.Text;
            endereco.endereco = txtEndereco.Text;
            endereco.estado = txtUF.Text;
            endereco.cidade = txtCidade.Text;

            ini.ReceberEndereco(endereco);

            if (pessoacpf.cpf != null)
            {
                ini.ReceberCadastroCPF(pessoacpf);
            }
            else if (pessoacnpj.cnpj != null)
            {
                ini.ReceberCadastroCNPJ(pessoacnpj);
            }

            ini.Show();
            this.Close();
        }

        private void labelSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Cadastro1 cad = new Cadastro1();

            endereco.numero = txtNumero.Text;
            endereco.bairro = txtBairro.Text;
            endereco.cep = txtCEP.Text;
            endereco.endereco = txtEndereco.Text;
            endereco.estado = txtUF.Text;
            endereco.cidade = txtCidade.Text;

            cad.ReceberEndereco(endereco);

            if (pessoacpf.cpf != null)
            {
                cad.ReceberCadastroCPF(pessoacpf);
            }
            else if (pessoacnpj.cnpj != null)
            {
                cad.ReceberCadastroCNPJ(pessoacnpj);
            }

            cad.Show();
            this.Hide();
        }

        private void btnPesquisarCEP_Click(object sender, EventArgs e)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                var resultado = ws.consultaCEP(txtCEP.Text);
                txtBairro.Text = resultado.bairro;
                txtEndereco.Text = resultado.end;
                txtCidade.Text = resultado.cidade;
                txtUF.Text = resultado.uf;
            }
        }
    }
}
