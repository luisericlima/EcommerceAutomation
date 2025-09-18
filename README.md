# AutomationEcommerce

AutomationEcommerce é uma aplicação de automação de testes para um sistema de e-commerce, desenvolvida utilizando SpecFlow para BDD, Selenium WebDriver para interação com o navegador e xUnit para execução dos testes. O objetivo é garantir que o fluxo completo de compra e navegação funcione corretamente para os usuários.

🚀 **Features**

- Automação de fluxo de cadastro, login e compra de produto.

- Utiliza SpecFlow para escrita de cenários BDD.

- Selenium WebDriver para automação de navegação e interação com páginas.

- Geração de relatórios LivingDoc para documentar a execução dos testes de forma interativa.

- xUnit e SpecFlow para execução dos testes.

🛠 **Tecnologias Utilizadas**

- SpecFlow: Framework de automação de testes baseado em BDD (Behavior Driven Development).

- Selenium WebDriver: Ferramenta para automação de browsers, permitindo a interação com páginas web.

- xUnit: Framework de testes unitários para .NET.

- LivingDoc CLI: Ferramenta para gerar relatórios interativos a partir dos resultados dos testes executados com o SpecFlow.


🔹**Variáveis de Ambiente Necessárias**

Antes de rodar os testes, é obrigatório definir as variáveis de ambiente usadas no projeto.
Exemplo no PowerShell:
```
$env:BASE_URL="https://automationexercise.com"; `
$env:LOGIN_EMAIL="teste@test.com"; `
$env:VALID_EMAIL="migixe6555@bitfami.com"; `
$env:VALID_PASSWORD="123456789"; `
$env:CARD_NAME="Teste Usuario"; `
$env:CARD_NUMBER="5552324588490628"; `
$env:CARD_CVC="630"; `
$env:CARD_MONTH="11"; `
$env:CARD_YEAR="2026"; `
dotnet test
```


⚡ **Como Rodar a Aplicação**

Clonar o Repositório:
```
git clone https://github.com/SeuUsuario/AutomationEcommerce.git
cd AutomationEcommerce
```


Instalar Dependências:

No terminal, no diretório do projeto, execute:
```
dotnet restore
```


Rodar os Testes:

Para rodar os testes, utilize o seguinte comando:
```
dotnet test
```

Gerar o Relatório LivingDoc:

Após executar os testes, gere o relatório interativo LivingDoc com:
```
dotnet test --logger "trx;LogFileName=TestResults.trx"
livingdoc test-assembly bin/Debug/net8.0/AutomationEcommerce.dll -t bin/Debug/net8.0/TestExecution.json
```

O relatório gerado será encontrado em um arquivo LivingDoc.html, que pode ser aberto em qualquer navegador.

📝 **Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:

```
/AutomationEcommerce
|-- /Features             # Arquivos .feature para os cenários BDD
|-- /Pages                # Páginas do sistema com o Selenium WebDriver
|-- /Steps                # Definições dos steps de cada cenário SpecFlow
|-- /Support              # Suporte com funções utilitárias
|-- /bin                  # Diretório de build do .NET
|-- /obj                  # Diretório de arquivos intermediários do .NET
|-- TestResults           # Resultado dos testes (gerados pelo `dotnet test`)
|-- LivingDoc.html        # Relatório interativo gerado pelo LivingDoc
```
🗂 **Diretórios Principais:**

- Features: Contém os arquivos .feature do SpecFlow, onde os cenários BDD são descritos.

- Pages: Contém as classes responsáveis por interagir com os elementos da página no navegador, utilizando o Selenium WebDriver.

- Steps: Contém as implementações dos steps do SpecFlow, que vinculam os passos das features com o código.
