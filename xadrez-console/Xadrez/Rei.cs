using Tabuleiros;
using Tabuleiros.Enums;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, cor)
        {
            _partidaDeXadrez = partidaDeXadrez;
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Colunas, Tabuleiro.Linhas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // ne
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // se
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // so
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }
            // no
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
            }

            // #jogadaespecial roque
            if (QtdMovimentos == 0 && !_partidaDeXadrez.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posicaoTorreDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posicaoTorreDireita))
                {
                    Posicao posicaoLivre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicaoLivre2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.Peca(posicaoLivre1) == null && Tabuleiro.Peca(posicaoLivre2) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posicaoTorreEsqueda = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorreEsqueda))
                {
                    Posicao posicaoLivre1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicaoLivre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicaoLivre3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(posicaoLivre1) == null && Tabuleiro.Peca(posicaoLivre2) == null && Tabuleiro.Peca(posicaoLivre3) == null)
                    {
                        movimentosPossiveis[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return movimentosPossiveis;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
