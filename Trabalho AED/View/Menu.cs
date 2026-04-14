using System.Security.Cryptography.X509Certificates;

namespace Menu
{

    class Menus
    {
        private bool VerificarEscolha(string entrada, int primeiroNumero, int segundoNumero)
        {
            bool verificado = false;
            bool isInteger = int.TryParse(entrada, out int escolha);
            if (isInteger == true && (escolha >= primeiroNumero && escolha <= segundoNumero))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Menu()
        {
            bool stopExecution = false;
            while (!stopExecution)
            {
                Console.WriteLine("MENU\n" +
                    "1- Consulta\n" +
                    "2- Cadastro\n" +
                    "3- Salvar\n" +
                    "0- Sair");
                string entrada = Console.ReadLine();
                int escolha;
                bool ok = VerificarEscolha(entrada, 0, 3);
                while (!ok)
                {
                    Console.WriteLine("MENU\n" +
                        "1- Consulta\n" +
                        "2- Cadastro\n" +
                        "3- Salvar\n" +
                        "0- Sair\n" +
                        "INSIRA UM NUMERO VALIDO!");
                    entrada = Console.ReadLine();
                    ok = VerificarEscolha(entrada, 0, 3);
                }
                escolha = int.Parse(entrada);
                while (ok)
                {
                    switch (escolha)
                    {
                        case 0:
                            stopExecution = true;
                            break;
                        case 1:
                            Consulta();
                            break;
                        case 2:
                            Cadastro();
                            break;
                        case 3:
                            Salvar();
                            break;
                    }
                }
            }
        }
        private void Consulta()
        {
            Console.WriteLine("MENU - CONSULTA\n" +
                "1-Listar Alunos\n" +
                "2- Listar Disciplinas\n" +
                "3- Listar Alunos de Uma Disciplina\n" +
                "4- Listar Disciplinas de um Aluno" +
                "0- Voltar ao Menu");
            string entrada = Console.ReadLine();
            int escolha;
            bool ok = VerificarEscolha(entrada, 0, 3);
            while (!ok)
            {
                Console.WriteLine("MENU - CONSULTA\n" +
                "1-Listar Alunos\n" +
                "2- Listar Disciplinas\n" +
                "3- Listar Alunos de Uma Disciplina\n" +
                "4- Listar Disciplinas de um Aluno" +
                "0- Voltar ao Menu\n" +
                "INSIRA UM VALOR VALIDO!");
                entrada = Console.ReadLine();
                ok = VerificarEscolha(entrada, 0, 3);
            }
            escolha = int.Parse(entrada);
            while (ok)
            {
                switch (escolha)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
                break;
            }
        }
        private void Cadastro()
        {

        }
        private void Salvar()
        {

        }
        private void Sair()
        {

        }
    }
}
/*consulta-> alunos,disciplinas,alunos da disciplina, disciplinas do aluno*/
/*cadastro-> disciplinas,alunos,matriculas,nota dos alunos*/
/*salvar-> salva os dados cadastrados nos arquivos*/
/*sair-> verificar se salvou, se nao, perguntar se deseja salvar, e sair*/
/*validação matricula: Soma e divide, tem que sobrar um numero, ou retornar algum numero*/