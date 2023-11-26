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
    // pilha que armazena os nós a serem visitados
    public Stack<int> pilha_execucao = new Stack<int>();
    public int[] nos_visitados = new int[10];
    public int inicio = 0;
    public int final = 8;

    public void iniciar_execucao(){
        Console.WriteLine("Executando busca em profundidade para grafo esparso:");
        comecar_busca(grafo_esparso, inicio, final);
        Console.WriteLine("\nExecutando busca em profundidade para grafo denso:");
        // comecar_busca(grafo_denso, inicio, final);
    }

    public void comecar_busca(int[,] grafo, int inicio, int fim){
        busca_em_profundidade(grafo, inicio, fim);
    }

    public void busca_em_profundidade(int[,] grafo,int no_atual, int no_final){
        int aux;

        while(true){
            if(!pilha_execucao.Contains(no_atual)){ // se o nó atual não está na pilha
                pilha_execucao.Push(no_atual); // adiciona o nó à pilha
                Console.WriteLine($"O nó {no_atual} foi adicionado à pilha.");
            }

            if(no_atual == no_final){ // se o nó atual for o nó que está sendo buscado
                pilha_execucao.Pop(); // remove o nó da pilha
                Console.WriteLine($"O nó {no_final} foi encontrado!");
                break; // termina a execução
            }
            else{
                // a variável auxiliar armazena o nó do topo da pilha que não é o nó procurado
                aux = pilha_execucao.Peek();
                // o nó do topo da pilha é removido, pois não é o que está sendo buscado
                pilha_execucao.Pop();
                // o nó é marcado no vetor que armazena os nós que já foram visitados
                nos_visitados[aux] = 1;
                Console.WriteLine($"O nó {no_atual} foi visitado.");

                for(int i=0; i<10; i++){
                    // 1) se tiver uma aresta entre o nó atual e qualquer outro nó do grafo
                    // 2) se esse nó não estiver na pilha
                    // 3) se esse nó não ser um dos nós que foram visitados
                    if(grafo[aux, i] == 1 && !pilha_execucao.Contains(i) && nos_visitados[i] == 0){
                        pilha_execucao.Push(i); // adiciona o nó ao topo da pilha
                        Console.WriteLine($"O nó {i} foi adicionado à pilha.");
                    }
                }
                no_atual = pilha_execucao.Peek(); // o nó atual é o nó no topo da pilha
            }
        }
    }
}