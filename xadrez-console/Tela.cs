using System;
using System.Collections.Generic;
using Tabuleiros;
using Tabuleiros.Enums;
using Xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        internal static void ImprimirPartida(PartidaDeXadrez partidaDeXadrez)
        {
            ImprimirTabuleiro(partidaDeXadrez.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partidaDeXadrez);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partidaDeXadrez.Turno}");
            Console.WriteLine($"Aguardando jogada: {partidaDeXadrez.JogadorAtual}");
            if (partidaDeXadrez.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partidaDeXadrez)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor colorOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = colorOriginal;
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach (Peca peca in pecas)
            {
                Console.Write($"{peca} ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    ImprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse($"{s[1]}");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor colorOriginal = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = colorOriginal;
                }
                Console.Write(" ");
            }
        }
    }
}
