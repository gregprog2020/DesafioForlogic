using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_1._2.Code.DTO
{
    class CadastroFilmeDTO
    {
        private int id;
        private string titulo;
        private string genero;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Genero { get => genero; set => genero = value; }
    }
}
