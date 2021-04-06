using Tabuleiros;
using Tabuleiros.Enums;

namespace Xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Colunas, Tabuleiro.Linhas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna);
            }
            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna);
            }
            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha, posicao.Coluna + 1);
            }
            // esquera
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha, posicao.Coluna - 1);
            }
            // NO
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }
            // NE
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }
            // SE
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }
            // SO
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.Peca(posicao) != null && Tabuleiro.Peca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.DefinirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return movimentosPossiveis;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
