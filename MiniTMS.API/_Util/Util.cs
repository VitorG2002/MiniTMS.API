using System.Text.RegularExpressions;

namespace MiniTMS.API._Util
{
    public class Util
    {
        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos do CPF
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF possui 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int primeiroDigito = (soma * 10) % 11;
            if (primeiroDigito == 10)
                primeiroDigito = 0;

            // Verifica se o primeiro dígito verificador está correto
            if (primeiroDigito != int.Parse(cpf[9].ToString()))
                return false;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            int segundoDigito = (soma * 10) % 11;
            if (segundoDigito == 10)
                segundoDigito = 0;

            // Verifica se o segundo dígito verificador está correto
            if (segundoDigito != int.Parse(cpf[10].ToString()))
                return false;

            // CPF válido
            return true;
        }

        public static bool ValidarCNPJ(string cnpj)
        {
            // Remover caracteres não numéricos
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            // Verificar se o CNPJ possui 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verificar se todos os dígitos são iguais
            if (new string(cnpj[0], 14) == cnpj)
                return false;

            // Calcular o primeiro dígito verificador
            int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaPrimeiroDigito = 0;

            for (int i = 0; i < 12; i++)
            {
                somaPrimeiroDigito += int.Parse(cnpj[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }

            int restoPrimeiroDigito = somaPrimeiroDigito % 11;
            int primeiroDigitoVerificador = restoPrimeiroDigito < 2 ? 0 : 11 - restoPrimeiroDigito;

            // Calcular o segundo dígito verificador
            int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaSegundoDigito = 0;

            for (int i = 0; i < 13; i++)
            {
                somaSegundoDigito += int.Parse(cnpj[i].ToString()) * multiplicadoresSegundoDigito[i];
            }

            int restoSegundoDigito = somaSegundoDigito % 11;
            int segundoDigitoVerificador = restoSegundoDigito < 2 ? 0 : 11 - restoSegundoDigito;

            // Verificar se os dígitos verificadores estão corretos
            return int.Parse(cnpj[12].ToString()) == primeiroDigitoVerificador && int.Parse(cnpj[13].ToString()) == segundoDigitoVerificador;
        }
    }
}
