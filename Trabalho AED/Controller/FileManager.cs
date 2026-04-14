using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public static class FileManager
    {
		public static void LerArquivos()
        {
            Dados.IniciarDados();
            string alunos
            if (File.Exists("Alunos.dat"))
            {
                foreach (string linha in File.ReadLines("Alunos.dat"))
                {
                    File.WriteAllLines("Alunos.dat",);
                }
            }
            if (File.Exists("Disciplinas.dat"))
            {
                foreach (string linha in File.ReadLines("Disciplinas.dat"))
                {

                }
            }
            if (File.Exists("Matriculas.dat"))
            {
                foreach (string linha in File.ReadLines("Matriculas.dat"))
                {

                }
            }
            //alunos[0] = new Alunos { Matricula = 0, Nome = "exemplo", Idade = 0 };
        }
        public static void SalvarDados()
        {

        }
        public static void ConvertDataToString() 
        { 

        }
    }
}
