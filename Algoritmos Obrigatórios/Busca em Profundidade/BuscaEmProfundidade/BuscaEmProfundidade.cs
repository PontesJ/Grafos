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
    public Stack<int> nos_visitados = new Stack<int>();
    public int[] nos_removidos = new int[10];
    public int inicio = 0;
    public int final = 8;

    public void iniciar_execucao(){
        Console.WriteLine("Executando busca em profundidade para grafo esparso:");
        comecar_busca(grafo_esparso, inicio, final);
        Console.WriteLine("Executando busca em profundidade para grafo denso:");
        // comecar_busca(grafo_denso, inicio, final);
    }

    public void comecar_busca(int[,] grafo, int inicio, int fim){
        busca_em_profundidade(grafo, inicio, fim);
    }

    public void busca_em_profundidade(int[,] grafo,int no_atual, int no_final){
        int aux;

        while(true){
            if(!nos_visitados.Contains(no_atual)){ // se o nó atual não está na pilha
                nos_visitados.Push(no_atual); // adiciona o nó à pilha
                Console.WriteLine($"O nó {no_atual} foi adicionado à pilha.");
            }

            if(no_atual == no_final){ // se o nó atual for o nó que está sfinalo procurado
                nos_visitados.Pop(); // remove o nó da pilha
                Console.WriteLine($"O nó {no_final} foi encontrado!");
                break; // termina a execução
            }
            else{
                // a variável auxiliar armazena o nó do topo da pilha que não é o nó procurado
                aux = nos_visitados.Peek();
                // o nó do topo da filha é removido, pois não é o que está sfinalo buscado
                nos_visitados.Pop();
                // o nó é marcado no vetor que armazena os nós que já foram removidos e não é o nó procurado
                nos_removidos[aux] = 1;
                Console.WriteLine($"O nó {no_atual} foi visitado.");

                for(int i=0; i<10; i++){
                    // 1) se tiver uma aresta entre o nó atual e qualquer outro nó do grafo
                    // 2) se esse nó não estiver na pilha
                    // 3) se esse nó não ser um dos nós que foram removidos
                    if(grafo[aux, i] == 1 && !nos_visitados.Contains(i) && nos_removidos[i] == 0){
                        nos_visitados.Push(i); // adiciona o nó ao topo da pilha
                        Console.WriteLine($"O nó {i} foi adicionado à pilha.");
                    }
                }
                no_atual = nos_visitados.Peek(); // o nó atual é o nó no topo da pilha
            }
        }
    }
}