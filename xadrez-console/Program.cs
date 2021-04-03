using System;
using Tabuleiros;
using Tabuleiros.Enums;
using Tabuleiros.Exceptions;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            //    tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            //    tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            //    tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));

            //    Tela.ImprimirTabuleiro(tabuleiro);
            //}
            //catch (TabuleiroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            PosicaoXadrez posicaoXadrez = new PosicaoXadrez('c', 7);

            Console.WriteLine(posicaoXadrez);
            Console.WriteLine(posicaoXadrez.ToPosicao());
        }
    }
}
