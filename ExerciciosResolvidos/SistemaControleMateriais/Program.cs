internal class Program
{
    public class Materiais
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Categoria: {Categoria}");
            Console.WriteLine($"Quantidade: {Quantidade}");
            Console.WriteLine($"Estoque mínimo: {EstoqueMinimo}");
            if (Quantidade == 0)
            {
                Console.WriteLine("Status: ESTOQUE ZERADO");
            }
            else if (Quantidade <= EstoqueMinimo)
            {
                Console.WriteLine("Status: ESTOQUE BAIXO");
            }
            else
            {
                Console.WriteLine("Status: ESTOQUE NORMAL");
            }
            Console.WriteLine("---------------------");
        }
    }

    public class Sistemas
    {
        public List<Materiais> Materiais { get; set; } = new List<Materiais>();
        public int Opcao { get; set; }
        public bool Executando { get; set; }

        public void Iniciar()
        {
            ExibirMenu();
        }

        public void ExibirMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\nCONTROLE DE MATERIAIS TECHSCHOOL\n=====================");
                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar Material\n2 - Alterar material por código\n3 - Remover material\n4 - Listar Materiais\n5 - Exibir resumo do estoque\n6 - Exibir informações do sistema\n0 - Encerrar");
                Console.WriteLine();
                Console.WriteLine("Digite a opção desejada:");
                Opcao = Convert.ToInt32(Console.ReadLine());
                Executando = true;

                switch (Opcao)
                {
                    case 1:
                        CadastrarMaterial();
                        break;
                    case 2:
                        AlterarMaterial();
                        break;
                    case 3:
                        RemoverMaterial();
                        break;
                    case 4:
                        ListarMateriais();
                        break;
                    case 5:
                        ExibirResumo();
                        break;
                    case 6:
                        ExibirInformacoes();
                        break;
                    case 0:
                        Encerrar();
                        break;
                    default:
                        return;
                }

            } while (Executando);            
        }

        public void CadastrarMaterial()
        {
            Sistemas sistema = new Sistemas();

            do
            {
                Console.Clear();
                Materiais material = new Materiais();
                Console.WriteLine("Digite o código do material:");
                material.Codigo = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("Digite o nome do material:");
                material.Nome = Console.ReadLine();
                if (material.Nome == "")
                {
                    Console.WriteLine("Nome do material não pode ser vazio.");
                    return;
                }

                Console.WriteLine("Digite a categoria do material:");
                material.Categoria = Console.ReadLine();
                if (material.Categoria == "")
                {
                    Console.WriteLine("Categoria do material não pode ser vazio.");
                    return;
                }
                
                Console.WriteLine("Digite a quantidade do material:");
                material.Quantidade = Convert.ToInt32(Console.ReadLine());
                if (material.Quantidade < 0)
                {
                    Console.WriteLine("Quantidade do material não pode ser negativa.");
                    return;
                }

                Console.WriteLine("Digite o estoque mínimo do material:");
                material.EstoqueMinimo = Convert.ToInt32(Console.ReadLine());
                if (material.EstoqueMinimo < 0)
                {
                    Console.WriteLine("Estoque mínimo do material não pode ser negativo.");
                    return;
                }

                Materiais.Add(material);
                Console.WriteLine("Material cadastrado com sucesso!");
                Console.WriteLine("Deseja cadastrar outro material?\n1 - Sim\n2 - Não");
                sistema.Opcao = Convert.ToInt32(Console.ReadLine());
            } while (sistema.Opcao == 1);
        }

        public void AlterarMaterial()
        {
            Console.Clear();

            Console.WriteLine("=====================");
            Console.WriteLine("ALTERAR MATERIAL");
            Console.WriteLine("=====================");

            Console.WriteLine("Digite o código do material que deseja alterar:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            bool encontrado = false;

            foreach (Materiais material in Materiais)
            {
                if (material.Codigo == codigo)
                {
                    encontrado = true;

                    Console.WriteLine("\nMaterial encontrado:");
                    material.ExibirDados();

                    Console.WriteLine("Digite o novo nome:");
                    material.Nome = Console.ReadLine();

                    Console.WriteLine("Digite a nova categoria:");
                    material.Categoria = Console.ReadLine();

                    Console.WriteLine("Digite a nova quantidade:");
                    material.Quantidade = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite o novo estoque mínimo:");
                    material.EstoqueMinimo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nMaterial alterado com sucesso!");

                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("\nMaterial não encontrado.");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadKey();
        }

        public void RemoverMaterial()
        {
            Console.Clear();

            Console.WriteLine("=====================");
            Console.WriteLine("REMOVER MATERIAL");
            Console.WriteLine("=====================");

            Console.WriteLine("Digite o código do material que deseja remover:");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Materiais materialRemover = null;

            foreach (Materiais material in Materiais)
            {
                if (material.Codigo == codigo)
                {
                    materialRemover = material;
                    break;
                }
            }

            if (materialRemover != null)
            {
                Console.WriteLine("\nMaterial encontrado:");
                materialRemover.ExibirDados();

                Console.WriteLine("Deseja realmente remover este material?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");

                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Materiais.Remove(materialRemover);
                    Console.WriteLine("\nMaterial removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nRemoção cancelada.");
                }
            }
            else
            {
                Console.WriteLine("\nMaterial não encontrado.");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadKey();
        }

        public void ListarMateriais()
        {
            Console.Clear();
            Console.WriteLine("=====================\nMATERIAIS CADASTRADOS\n=====================");

            int cont = 1;         
            foreach (var material in Materiais)
            {
                Console.WriteLine($"MATERIAL {cont}");
                material.ExibirDados();
                cont++;
            }
            
            if (Materiais.Count == 0)
            {
                Console.WriteLine("Nenhum material foi cadastrado.\nUtilize a opção 1 do menu para cadastrar materiais.");
            }
            else
            {
                Console.WriteLine($"Total de materiais cadastrados: {Materiais.Count}");
            }   

            
            Console.WriteLine("\nListagem concluída. Pressione ENTER para voltar ao menu");
            Console.ReadKey();        
        }

        public void ExibirResumo()
        {
            Console.Clear();
            Console.WriteLine("=====================\nRESUMO DO ESTOQUE\n======================");
            Console.WriteLine("Resumo do estoque de materiais cadastrados:");
            Console.WriteLine($"Materiais cadastrados: {Materiais.Count}");
            Console.WriteLine($"Total de materiais disponíveis: {Materiais.Sum(m => m.Quantidade)}");
            Console.WriteLine();
            if (Materiais.Count > 0)
            {
                Console.WriteLine("Situação geral: Existem materiais cadastrados");
            }
            else
            {
                Console.WriteLine("Situação geral: Nenhum material cadastrado");
            }
            Console.WriteLine("Pressione ENTER para voltar ao menu principal...");
            Console.ReadKey();
        }

        public void ExibirInformacoes()
        {
            Console.Clear();
            Console.WriteLine("=====================\nINFORMAÇÕES DO SISTEMA\n======================");
            Console.WriteLine();
            Console.WriteLine("Sistema: Controle de Materiais TechSchool");
            Console.WriteLine("Versão: 1.0");
            Console.WriteLine("Tipo: Aplicação de Console");
            Console.WriteLine("Finalidade: Cadastro e listagem de materiais");
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu principal...");
            Console.ReadKey();
        }

        public void Encerrar()
        {
            Console.Clear();
            Console.WriteLine("=====================\nENCERRAR APLICAÇÃO\n======================");
            Console.WriteLine("Deseja realmente encerrar a aplicação?\n1 - Sim\n2 - Não\nDigite a opção desejada:");
            int opcao = Convert.ToInt32(Console.ReadLine());
            if (opcao == 1)
            {
                Console.WriteLine("Aplicação encerrada. Pressione ENTER para sair...");
                Console.ReadKey();
                Executando = false;
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Pressione ENTER para voltar ao menu.");
                Console.ReadKey();
            }
        }
    }

    private static void Main(string[] args)
    {
        Sistemas sistema = new Sistemas();
        sistema.Iniciar();
    }
}