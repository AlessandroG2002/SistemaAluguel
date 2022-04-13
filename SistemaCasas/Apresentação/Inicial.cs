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

namespace SistemaCasas
{
    public partial class Form1 : Form
    {
        PessoaCPF pessoacpf = new PessoaCPF();
        PessoaCNPJ pessoacnpj = new PessoaCNPJ();
        Endereco endereco = new Endereco();

        public Form1()
        {
            InitializeComponent();
        }

        public void ReceberCadastroCPF(PessoaCPF pessoa) => this.pessoacpf = pessoa;

        public void ReceberCadastroCNPJ(PessoaCNPJ pessoa) => this.pessoacnpj = pessoa;

        public void ReceberEndereco(Endereco endereco) => this.endereco = endereco;

        private void labelSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro1 cad = new Cadastro1();

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
    }
}
