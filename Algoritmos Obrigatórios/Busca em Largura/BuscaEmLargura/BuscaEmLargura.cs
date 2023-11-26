public class BuscaEmLargura{
    // matriz de adjacência de um grafo esparso
    public int[,] grafo_esparso = new int[4,4]{
        /*
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
        */
        {0,1,1,0},
        {1,0,0,1},
        {1,0,0,1},
        {0,1,1,0}
    };
    // fila que armazena os nós a serem visitados
    public Queue<int> fila_execucao = new Queue<int>();
    public int [] nos_visitados = new int[4];
    public int inicio = 0;
    public int final = 3;

    public void iniciar_execucao(){
        Console.WriteLine("Executando busca em largura para grafo esparso:");
        comecar_busca(grafo_esparso, inicio, final);
        Console.WriteLine("\nExecutando busca em largura para grafo denso:");
        // comecar_busca(grafo_denso, inicio, final);
    }

    public void comecar_busca(int[,] grafo, int inicio, int fim){
        busca_em_largura(grafo, inicio, fim);
    }

    public void busca_em_largura(int[,] grafo,int no_atual, int no_final){
        int aux;

        while(true){
            if(!fila_execucao.Contains(no_atual)){ // se o nó atual não está na fila
                fila_execucao.Enqueue(no_atual); // adiciona o nó à fila
                Console.WriteLine($"O nó {no_atual} foi adicionado à fila."); 
            }

            if(no_atual == no_final){ // se o nó atual for o nó que está sendo buscado
                fila_execucao.Dequeue(); // remove o nó da fila
                Console.WriteLine($"O nó {no_final} foi encontrado!");
                break;
            }
            else{
                // a variável auxiliar armazena o nó do começo da fila que não é o nó procurado
                aux = fila_execucao.Peek();
                // o nó do começo da fila é removido, pois não é o que está sendo buscado
                fila_execucao.Dequeue();
                // o nó é marcado no vetor que armazena os nós que já foram marcados
                nos_visitados[aux] = 1;
                Console.WriteLine($"O nó {no_atual} foi visitado.");

                for(int i=0; i<4; i++){
                    // 1) se tiver uma aresta entre o nó atual e qualquer outro nó do grafo
                    // 2) se esse nó não estiver na fila
                    // 3) se esse nó não ser um dos nós que foram visitados
                    if(grafo[aux, i] == 1 && !fila_execucao.Contains(i) && nos_visitados[i] == 0){
                        fila_execucao.Enqueue(i); // adiciona o nó no começo da fila
                        Console.WriteLine($"O nó {i} foi adicionado à fila.");
                    }
                }
                no_atual = fila_execucao.Peek(); // o nó atual é o nó no topo da fila
            }
        }
    }
}