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
    public partial class Cadastro3 : Form
    {
        Pessoa pessoa = new Pessoa();
        Endereco endereco = new Endereco();

        public Cadastro3()
        {
            InitializeComponent();
        }
        public void ReceberPessoa(Pessoa pessoa) => this.pessoa = pessoa;

        public void ReceberEndereco(Endereco endereco) => this.endereco = endereco;

        private void Logo_Click(object sender, EventArgs e)
        {
            Form1 ini = new Form1();

            ini.ReceberEndereco(endereco);
            ini.ReceberPessoa(pessoa);

            ini.Show();
            this.Close();
        }

        private void labelSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Cadastro2 cad = new Cadastro2();

            cad.ReceberEndereco(endereco);
            cad.ReceberPessoa(pessoa);

            cad.Show();
            this.Hide();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if ( checkTermos.Checked == true )
            {
                if ( txtLogin.Text != String.Empty && txtSenha.Text != String.Empty )
                {
                    if (txtSenha.Text == txtConfSenha.Text)
                    {
                        Controle controle = new Controle();
                        controle.cadastrar(txtLogin.Text, txtSenha.Text, txtConfSenha.Text, pessoa, endereco);
                        if (controle.mensagem.Equals(""))
                        {
                            if (!controle.encontrado)
                            {
                                MessageBox.Show("Cadastro realizado com Sucesso", "Retornando a Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Usuário já existe", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(controle.mensagem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senhas informadas não são iguais!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Preencha os dados!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Confirme os termos de uso!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
