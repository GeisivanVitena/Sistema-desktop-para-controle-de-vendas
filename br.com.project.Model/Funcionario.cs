using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeVendasApp.br.com.project.Model
{
    public class Funcionario : Cliente
    {
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivel_acesso { get; set; }
    }
}
