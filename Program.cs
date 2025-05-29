using System.Net.NetworkInformation;
using System.Reflection.Metadata;

int idade;
bool febre, tosse, sintomarespiratorio;
bool faltaAr, aumentoFrequencia, dorToraxica, desmaio;
bool hipertensao, diabetes, outrasCronicas;
bool doencaCoranariana, doencaCronica;

bool possuiAlarme, possuiFatorRisco, situacaoGrave;


Console.Clear();

Console.WriteLine("-- Triagem para Covid-19 --");
Console.WriteLine("\nAdaptado de https://www.slmandic.edu.br/tudo-sobre-coronavirus/"); 
Console.WriteLine("RESULTADO ESTRITAMENTE EDUCACIONAL. PROCURE AJUDA ESPECIALIZADA.\n");

Console.Write("Qual a idade do paciente? ");

while (!int.TryParse(Console.ReadLine()!, out idade) || idade <= 0 || idade >= 130)
{
    Console.WriteLine("Idade inválida. Digite uma idade válida: ");
}

Console.WriteLine("Obrigado!");

Console.WriteLine("\nDigite [S] para SIM e [N] para NÃO");

Console.Write("Paciente com febre? ");
febre = Console.ReadLine()!.ToUpper() == "S";


Console.Write("Paciente com tosse? ");
tosse = Console.ReadLine()!.ToUpper() == "S";


Console.Write("Paciente com outro sintoma respiratório? ");
sintomarespiratorio = Console.ReadLine()!.ToUpper() == "S";


if (!febre && !tosse && !sintomarespiratorio)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Nenhuma recomendação específica!");
}

else
{
    Console.WriteLine("\n-- Sinais de Alarme --");

    Console.Write("Paciente com falta de ar? ");
    faltaAr = Console.ReadLine()!.ToUpper() == "S";

    Console.Write("Paciente com sensação de desmaio? ");
    desmaio = Console.ReadLine()!.ToUpper() == "S";

    Console.Write("Paciente com aumento da frequência respiratória? ");
    aumentoFrequencia = Console.ReadLine()!.ToUpper() == "S";

    Console.Write("Paciente com dor toráxica? ");
    dorToraxica = Console.ReadLine()!.ToUpper() == "S";

    possuiAlarme = faltaAr
        || desmaio
        || aumentoFrequencia
        || dorToraxica;

    if (idade < 18)
    {
        Console.Write("\n-- Fatores de Risco para menores --");

        Console.Write("Paciente com hipertensão? ");
        hipertensao = Console.ReadLine()!.ToUpper() == "S";

        Console.Write("Paciente com diabetes? ");
        diabetes = Console.ReadLine()!.ToUpper() == "S";

        Console.Write("Paciente com outras doenças crônicas? ");
        outrasCronicas = Console.ReadLine()!.ToUpper() == "S";

        possuiFatorRisco = hipertensao || diabetes || outrasCronicas;
    }

    else
    {
        Console.WriteLine("\n-- Fatores de Risco para maiores --");

        Console.Write("Paciente com doença coranariana prévia? ");
        doencaCoranariana = Console.ReadLine()!.ToUpper() == "S";

        Console.Write("Paciente com doença crônica descompensada? ");
        doencaCronica = Console.ReadLine()!.ToUpper() == "S";

        possuiFatorRisco = (idade > 65)
            || aumentoFrequencia
            || doencaCoranariana
            || doencaCronica;

    }

    if (possuiAlarme || possuiFatorRisco)
    {
        Console.Write("Paciente com situação grave? ");
        situacaoGrave = Console.ReadLine()!.ToUpper() == "S";

        if (situacaoGrave)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n* Encaminhar ambulância para o local.");
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n* Encaminhar para o sistema de saúde.");
        }
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n* Recomendar isolamento domiciliar");
    }

    Console.ResetColor();
    Console.WriteLine("Obrigado!");

   
}





