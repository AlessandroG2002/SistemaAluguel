﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCasas.Modelo
{
    public class Pessoa
    {
        public string nome;
        public string email;
        public string filiacao;
        public DateTime data = DateTime.Now;
        public bool isAdmin;
        public bool isCNPJ;

        public string cpf;
        public string cnpj;
    }
}
