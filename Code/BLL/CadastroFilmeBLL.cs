using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora_1._2.Code.DTO;
using Locadora_1._2.Code.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Locadora_1._2.Code.BLL
{
    class CadastroFilmeBLL
    {
        AcessoBancoDados bd = new AcessoBancoDados();
        public void Inserir(CadastroFilmeDTO dto)
        {

            try 
            {
                bd.Conectar();
                string comando = "INSERT INTO Filmes (titulo, genero) VALUES ('" + dto.Titulo + "' , '" + dto.Genero + "')";
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar Filme" + ex.Message);
            }
            finally
            {

            }
                 
            
        }

        public DataTable SelecionaTodosFilmes()
        {
            DataTable dt = new DataTable();
            try
            {
                
                bd = new AcessoBancoDados();
                bd.Conectar();

                dt = bd.RetDataTable("SELECT id_filme, titulo, genero from Filmes");

                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar Filmes" + ex.Message);
            }
            finally
            {
            }

            return dt;
            

            
        }

        public void Atualizar(CadastroFilmeDTO dto)
        {

            try
            {
                bd.Conectar();
                string comando = "UPDATE Filmes set titulo = '" + dto.Titulo + "',genero = '" + dto.Genero + "' where id_filme =" + dto.Id;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar Filme" + ex.Message);
            }
            finally
            {

            }


        }

        public void Excluir(string Id_Filme)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "DELETE FROM Filmes where id_filme =" + Id_Filme;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Filme" + ex.Message);
            }
            finally
            {

            }
        }
    }
    
}
