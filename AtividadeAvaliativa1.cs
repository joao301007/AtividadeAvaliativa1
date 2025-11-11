
// João Lucas Antunes Carvalho
// Turma: 2ª Etapa - 2025

using System;
using System.Linq;
using System.Windows.Forms;

namespace AtividadeAvaliativa1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Mostra uma mensagem de boas-vindas com o nome informado
        void ExibirMensagem(string nome)
        {
            MessageBox.Show("Bem-vindo(a), " + nome + "!");
        }

        private void btnQuestao1_Click(object sender, EventArgs e)
        {
            string nome = txtNomeQ1.Text;
            ExibirMensagem(nome);
        }

        // Calcula a raiz quadrada de um número digitado
        double CalcularRaizQuadrada(double numero)
        {
            return Math.Sqrt(numero);
        }

        private void btnQuestao2_Click(object sender, EventArgs e)
        {
            double numero;
            if (double.TryParse(txtNumeroQ2.Text, out numero))
            {
                double resultado = CalcularRaizQuadrada(numero);
                lblResultadoQ2.Text = "Raiz quadrada: " + resultado.ToString("F2");
            }
            else
            {
                lblResultadoQ2.Text = "Digite um número válido.";
            }
        }

        // Exemplo de passagem por valor
        int IncrementarPorValor(int valor)
        {
            valor += 10;
            return valor;
        }

        // Exemplo de passagem por referência
        int IncrementarPorReferencia(ref int valor)
        {
            valor += 10;
            return valor;
        }

        private void btnQuestao3_Click(object sender, EventArgs e)
        {
            int numero;
            if (int.TryParse(txtNumeroQ3.Text, out numero))
            {
                int copiaValor = numero;
                int resultadoValor = IncrementarPorValor(copiaValor);
                int resultadoRef = IncrementarPorReferencia(ref numero);

                MessageBox.Show(
                    "Passagem por valor: " + resultadoValor +
                    "\nPassagem por referência: " + resultadoRef,
                    "Resultado"
                );
            }
            else
            {
                MessageBox.Show("Digite um número válido!");
            }
        }

        // Usa parâmetro de saída (out) para divisão
        bool Dividir(int dividendo, int divisor, out int resultado)
        {
            resultado = 0;
            if (divisor == 0)
                return false;

            resultado = dividendo / divisor;
            return true;
        }

        private void btnQuestao4_Click(object sender, EventArgs e)
        {
            int dividendo, divisor;
            if (int.TryParse(txtDividendoQ4.Text, out dividendo) &&
                int.TryParse(txtDivisorQ4.Text, out divisor))
            {
                int resultado;
                bool sucesso = Dividir(dividendo, divisor, out resultado);

                if (sucesso)
                    lblResultadoQ4.Text = "Resultado: " + resultado;
                else
                    lblResultadoQ4.Text = "Não é possível dividir por zero!";
            }
            else
            {
                lblResultadoQ4.Text = "Digite valores válidos!";
            }
        }

        // Calcula a média de números usando params
        double CalcularMedia(params double[] numeros)
        {
            if (numeros.Length == 0)
                return 0;
            return numeros.Average();
        }

        private void btnQuestao5_Click(object sender, EventArgs e)
        {
            try
            {
                string[] partes = txtNumerosQ5.Text.Split(',');
                double[] valores = partes.Select(x => double.Parse(x.Trim())).ToArray();

                double media = CalcularMedia(valores);
                MessageBox.Show("A média é: " + media.ToString("F2"));
            }
            catch
            {
                MessageBox.Show("Erro! Digite números separados por vírgula.");
            }
        }

        // Calculadora com várias operações usando params
        double CalculadoraAvancada(string operador, params double[] numeros)
        {
            if (numeros.Length == 0)
                return 0;

            double resultado = numeros[0];

            switch (operador)
            {
                case "+":
                    resultado = numeros.Sum();
                    break;

                case "-":
                    for (int i = 1; i < numeros.Length; i++)
                        resultado -= numeros[i];
                    break;

                case "*":
                    resultado = 1;
                    foreach (double n in numeros)
                        resultado *= n;
                    break;

                case "/":
                    for (int i = 1; i < numeros.Length; i++)
                    {
                        if (numeros[i] == 0)
                            throw new DivideByZeroException("Divisão por zero detectada!");
                        resultado /= numeros[i];
                    }
                    break;

                default:
                    throw new ArgumentException("Operador inválido!");
            }

            return resultado;
        }

        private void btnQuestao6_Click(object sender, EventArgs e)
        {
            try
            {
                string operador = txtOperadorQ6.Text.Trim();
                string[] partes = txtNumerosQ6.Text.Split(',');
                double[] valores = partes.Select(x => double.Parse(x.Trim())).ToArray();

                double resultado = CalculadoraAvancada(operador, valores);
                lblResultadoQ6.Text = "Resultado: " + resultado.ToString("F2");
            }
            catch (Exception ex)
            {
                lblResultadoQ6.Text = "Erro: " + ex.Message;
            }
        }
    }
}
