public class BuscaEmProfundidade{
    // matriz de adjacência de um grafo esparso
    public int[,] grafo_esparso = new int[10,10]{
        {0,1,1,1,1,0,0,0,0,0},
        {1,0,0,0,1,1,0,0,0,0},
        {1,0,0,1,0,1,0,0,0,0},
        {1,0,1,0,0,1,0,0,1,0},
        {1,1,0,0,0,1,1,1,0,0},
        {0,1,1,1,1,0,1,0,1,0},
        {0,0,0,0,1,1,0,1,1,1},
        {0,0,0,0,1,0,1,0,0,1},
        {0,0,0,1,0,1,1,0,0,1},
        {0,0,0,0,0,0,1,1,1,0}
    };
    // matriz de adjacência de um grafo denso
    public int[,] grafo_denso = new int[10,10]{
        {0,1,1,1,0,1,1,1,1,1},
        {1,0,1,1,1,1,0,1,1,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,1,1,0,1,1,1,1,0,1},
        {0,1,1,1,0,1,1,1,1,1},
        {1,1,1,1,1,0,1,1,1,0},
        {1,0,1,1,1,1,0,1,1,1},
        {1,1,0,1,1,1,1,0,1,1},
        {1,1,1,0,1,1,1,1,0,1},
        {1,1,1,1,1,0,1,1,1,0}
    };
    // pilha que armazena os nós a serem visitados
    public Stack<int> pilha_execucao = new Stack<int>();
    public int[] nos_visitados = new int[10];
    public int inicio = 0;
    public int final = 8;

    public void iniciar_execucao(){
        Console.ForegroundColor = ConsoleColor.Green; // imprime uma mensagem colorida
        Console.WriteLine("Executando busca em profundidade para grafo esparso:");
        Console.ResetColor(); // restaura a cor padrão
        comecar_busca(grafo_esparso, inicio, final);

        Console.ForegroundColor = ConsoleColor.Magenta; // imprime uma mensagem colorida
        Console.WriteLine("\nExecutando busca em profundidade para grafo denso:");
        Console.ResetColor(); // restaura a cor padrão
        comecar_busca(grafo_denso, inicio, final);
    }

    public void comecar_busca(int[,] grafo, int inicio, int fim){
        busca_em_profundidade(grafo, inicio, fim);
    }

    public void busca_em_profundidade(int[,] grafo,int no_atual, int no_final){
        int aux;

        while(true){
            if(!pilha_execucao.Contains(no_atual)){ // se o nó atual não está na pilha
                pilha_execucao.Push(no_atual); // adiciona o nó à pilha
                Console.WriteLine($"O nó {no_atual + 1} foi adicionado à pilha.");
            }

            if(no_atual == no_final){ // se o nó atual for o nó que está sendo buscado
                pilha_execucao.Pop(); // remove o nó da pilha
                Console.WriteLine($"O nó {no_final + 1} foi encontrado!");
                break; // termina a execução
            }
            else{
                // a variável auxiliar armazena o nó do topo da pilha que não é o nó procurado
                aux = pilha_execucao.Peek();
                // o nó do topo da pilha é removido, pois não é o que está sendo buscado
                pilha_execucao.Pop();
                // o nó é marcado no vetor que armazena os nós que já foram visitados
                nos_visitados[aux] = 1;
                Console.WriteLine($"O nó {no_atual + 1} foi visitado.");

                for(int i=0; i<10; i++){
                    // 1) se tiver uma aresta entre o nó atual e qualquer outro nó do grafo
                    // 2) se esse nó não estiver na pilha
                    // 3) se esse nó não ser um dos nós que foram visitados
                    if(grafo[aux, i] == 1 && !pilha_execucao.Contains(i) && nos_visitados[i] == 0){
                        pilha_execucao.Push(i); // adiciona o nó ao topo da pilha
                        Console.WriteLine($"O nó {i+1} foi adicionado à pilha.");
    
                    }
                }
                no_atual = pilha_execucao.Peek(); // o nó atual é o nó no topo da pilha
            }
        }
    }
}