Console.Write("Insiria o tamanho do tabuleiro que você deseja jogar: ");
int x = int.Parse(Console.ReadLine());

Console.Write("Insira o número de bombas que você deseja jogar: ");
int b = int.Parse(Console.ReadLine());

Console.Clear();

int[,] jogo = new int[x, x]; 
int[,] tabuleiro = new int[x, x];

//Criando o tabuleiro e as posições neutras do jogo
for (int i = 0; i < x; i++)
{
    for (int j = 0; j < x; j++)
    {
        tabuleiro[i, j] = 0;
        jogo[i, j] = 0; 
    }
}

Random gerador = new Random();

//Colocando a bandeira de forma aleatória
int linhaBandeira = gerador.Next(x-1);
int colunaBandeira = gerador.Next(x-1);
jogo[linhaBandeira, colunaBandeira] = 2;

//Colocando as bombas de forma aleatória
int qtdBomba = 0;
do
{
    int l = gerador.Next(x - 1);
    int c = gerador.Next(x - 1);
    if (jogo[l,c] == 0)
    {
        jogo[l, c] = 1;
        qtdBomba++;
    }
} while (qtdBomba < b);

//Jogo
bool fimJogo = false;
do
{
    Console.WriteLine("X-X-X CAMPO MINADO X-X-X");
    Console.WriteLine();
    for(int i = 0; i < x; i++)
    {
        for (int j = 0; j < x; j++)
        {
            Console.Write(" " + tabuleiro[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
    Console.Write("Escolha o número da linha: ");
    int linha = int.Parse(Console.ReadLine()) - 1;
    Console.Write("Escolha o número da coluna: ");
    int coluna = int.Parse(Console.ReadLine()) - 1;

    switch(jogo[linha, coluna])
    {
        case 0:
            Console.WriteLine("Continue tentando! ");
            tabuleiro[linha, coluna] = 1;
            break;
        case 1:
            Console.WriteLine("BOOOM! Você perdeu!");
            fimJogo = true;
            break;
        case 2:
            Console.WriteLine("Você VENCEU!");
            fimJogo = true;
            break;
    }
   
    Console.WriteLine("Tecle enter para continuar...");
    Console.ReadKey();
    Console.Clear();
} while(!fimJogo);
