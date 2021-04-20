# dotnet_Csharp_console_app_bank
.NET C# console dotnet C sharp .Net dot net


    Melhorias:

1ª - na versão inicial, o programa finalizava execução caso usuário pressionasse qualquer tecla diferente das esperadas (mesmo que fosse por engano). Agora ele exibe qual tecla foi pressionada além de informar quais as opções são válidas.

2ª – antes de sair o programa exibe uma contagem regressiva com uma mensagem de agradecimento.

3ª - implementei o método para excluir conta do banco atendendo aos seguintes critérios:
    
    - conta deve existir na lista.

    - conta não pode ter saldo positivo. (já pensou você excluir sua conta com saldo de 5k?)


OBS.: se estiver desenvolvendo este projeto, e quiser rodar o teste em outro terminal diferente do incluso na sua IDE, faça o seguinte: no arquivo launch.json da pasta .vsconde adicionar e substituir o seguinte trecho:

    Trecho Original:

    "console": "internalConsole",
    "stopAtEntry": false

    Trecho Modificado:

    "console": "externalTerminal",
    "stopAtEntry": false,
    "internalConsoleOptions": "openOnSessionStart"


Projeto de aprendizado no Bootcamp LocalizaLabs .NET Developer da Digital Innovation One - DIO

Criando uma aplicação de transferências bancárias com .NET

Aprenda como criar um algoritmo simples de transferência bancária para exercer o pensamento orientado a objetos, o principal paradigma de programação utilizada no mercado. Nesse projeto você vai aprender: Como pensar orientado a objetos, como modelar o seu domínio, como utilizar Enums.