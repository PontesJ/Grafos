BuscaEmProfundidade busca = new BuscaEmProfundidade();
busca.iniciar_execucao();

public class BuscaEmProfundidade{
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
        {0,0,0,0,0,0,1,1,1,0},
        */
        {0,1,1,0},
        {1,0,0,1},
        {1,0,0,1},
        {0,1,1,0}
    };
    // pilha que armazena os nós a serem visitados
    Stack<int> nos_visitados = new Stack<int>();
    public int init = 0;
    public int end = 3;

    public void iniciar_execucao(){
        comecar_busca(init, end);
    }

    public void comecar_busca(int inicio, int fim){
        busca_em_profundidade(inicio, fim);
    }

    public void busca_em_profundidade(int no_atual, int no_final){
        nos_visitados.Push(no_atual); // adiciona o nó visitado à pilha
        Console.WriteLine($"O nó {no_atual} acabou de ser visitado.");

        if(no_atual == no_final){ // se o nó atual for o nó que está sendo procurado
            Console.WriteLine($"O nó {no_final} foi encontrado!");
        }
        else{
            // o nó do topo da filha é removido, pois não é o que está sendo buscado
            nos_visitados.Pop();
            Console.WriteLine($"O nó {no_atual} foi removido do topo da pilha.");
            for(int i=0; i<=3; i++){
                // se tiver uma aresta entre o nó atual e qualquer outro nó do grafo e esse não estiver na pilha
                if(grafo_esparso[no_atual, i] > 0 && !nos_visitados.Contains(i)){
                    busca_em_profundidade(i, no_final);

                }
            }
        }
    }
}