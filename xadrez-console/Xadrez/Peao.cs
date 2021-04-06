using Tabuleiros;
using Tabuleiros.Enums;

namespace Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez _partidaDeXadrez;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, cor)
        {
            _partidaDeXadrez = partidaDeXadrez;
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.Peca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[Tabuleiro.Colunas, Tabuleiro.Linhas];

            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QtdMovimentos == 0)
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && ExisteInimigo(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        movimentosPossiveis[posicaoEsquerda.Linha - 1, posicaoEsquerda.Coluna] = true;
                    }
                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && ExisteInimigo(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        movimentosPossiveis[posicaoDireita.Linha - 1, posicaoDireita.Coluna] = true;
                    }
                }
            }
            else
            {
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QtdMovimentos == 0)
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    movimentosPossiveis[posicao.Linha, posicao.Coluna] = true;
                }

                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    Posicao posicaoEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(posicaoEsquerda) && ExisteInimigo(posicaoEsquerda) && Tabuleiro.Peca(posicaoEsquerda) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        movimentosPossiveis[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;
                    }
                    Posicao posicaoDireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(posicaoDireita) && ExisteInimigo(posicaoDireita) && Tabuleiro.Peca(posicaoDireita) == _partidaDeXadrez.VulneravelEnPassant)
                    {
                        movimentosPossiveis[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                    }
                }
            }

            return movimentosPossiveis;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
