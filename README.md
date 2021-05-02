# WiPro

### Projeto para ler arquivos de cotação de moedas e salvar resultado

Necessidades
- Criar um serviço REST (Web API) AddItemFila - adicionar um objeto json com o formato abaixo em uma
fila de processamento.
- Criar um serviço REST (Web API) GetItemFila - retornar o último objeto json adicionado na fila pelo
método AddItemFila.
- Criar uma rotina que rode a cada 2 minutos.



Funcionalidade esperada
- Acesse o método GetItemFila da api desenvolvida no Item anterior. Caso o método retorne um
objeto, obter todas as moedas e períodos correspondentes
- Para cada moeda/período retornada da api, acessar o arquivo DadosMoeda.csv (mesmo
diretório de execução) e trazer todas as moedas/datas que estejam dentro do período
(Inclusive) da moeda que está sendo tratada.
- . Com a lista de moedas/datas, buscar todos os valores de cotação (vlr_cotacao) no arquivo
DadosCotacao.csv utilizando o de-para descrito no item 4 (Tabela de de-para) para obter as
cotações.
-  Gerar um arquivo de resultado (apenas com as moedas/datas consultadas) com o nome
Resultado_aaaammdd_HHmmss.csv no mesmo formato do arquivo DadosMoeda.csv.
Porém com uma coluna a mais (VL_COTACAO) contendo o valor de cotação correspondente
(obtido do arquivo DadosCotacao.csv) para cada moeda/data consultada
- Encerrar o processamento e aguardar o próximo ciclo de verificação (2 minutos).
- Caso o método GetItemFila da api desenvolvida no item anterior não retorne valor. Encerrar o
processamento e aguardar o próximo ciclo de verificação (2 minutos).

## Informações Técnicas
Projeto foi estruturado em 5 camadas separadas

- **Domains**
Camada responsavel pelos objetos da classe.

- **Service**
Camada responsavel pelas Interface.

- **BusinessRule**
Camada responsavel pelas regras de negócio.

- **WebApi**
Camada do serviço Rest API.

- **ConsoleThread**
Console executando a Thread.

## tecnologias utilizadas
- .Net Core 3.1.114

Tecnologias necessárias instaladas no computador
- dotnet = https://dotnet.microsoft.com/download

Como rodar projeto:
1) Em webapi executar comando : **dotnet run**
2) ConsoleThread executar comando :  **dotnet run**
