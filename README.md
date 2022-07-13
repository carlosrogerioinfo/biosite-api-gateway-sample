# Estrutura de uma aplicação API com Gateway e CQRS (Parcialmente implementada)

<p>
O projeto Biosite é um exemplo de estrutura de aplicação distribuída com utilização de **API**, **Gateways** para isolamento das APIs, possui uma implementação básica e muito funcional do uso do **CRQS** (Command Query Responsibility Segregation), uso de **VO** (Value Objects) e uso de **Notification Pattern** e muito mais, este projeto tem a intenção de servir de modelo para desenvolvedores iniciantes que estão aprendendo desenvolvimento de backends com comunicação entre APIs via gateway na plataforma Asp.Net Core usando linguagem C#.

A parte de comunicação entre a api gateway de exemplo com os endpoints das outras APIs, não está totalmente concluída, no projeto atual, a gateway se comunica com a API de autenticação para realizar o login e obter o token, e também está realizando comunicação com as APIs de biomarcadores e órgãos, trazendo todos os registros apenas. Os demais endpoints tanto da API de autenticação, quanto das APIs de biomarcadores e orgãos necessitam ser implementados. Aos poucos, a medida que sobrar um tempinho, eu vou adicionando.

Mas, sinta-se a vontade para usar o código e implementar as outras chamadas do gateway para os demais endpoints de suas respectivas APIs. Obviamente simplificamos o projeto de modo que foi criado apenas uma única api gateway para chamar os endpoints das outras APIs, mas, sinta-se a vontade para incluir as outras APIs gateway como forma de aprendicado para você.
</p>

## Estrutura
![image](https://user-images.githubusercontent.com/72615280/177876226-bddea19f-90cd-4bd8-b782-8b7e8af1032b.png)

![image](https://user-images.githubusercontent.com/72615280/177876368-36be4d1f-0f7d-4abf-b5e2-afa685e48651.png)

## As APIs podem ser testadas através dos seguintes endereços logo abaixo:

**API Gateway** : <a href="http://gateway.sampleapicore.uni5.net/" target="_blank">http://gateway.sampleapicore.uni5.net/</a>
  
**API de autenticação**: <a href="http://authentication.sampleapicore.uni5.net/" target="_blank">http://authentication.sampleapicore.uni5.net/</a>

**API de biomarcadores**: <a href="http://biomarker.sampleapicore.uni5.net/" target="_blank">http://biomarker.sampleapicore.uni5.net/</a>

**API de órgãos**: <a href="http://organ.sampleapicore.uni5.net/" target="_blank">http://organ.sampleapicore.uni5.net/</a>

## Informações de login para autenticação

**e-mail** : carlos@biosite.com <br/>
**senha**: teste123

**e-mail** : ester@biosite.com <br/>
**senha**: teste123

## Banco de dados

<p>Para este projeto foi usado o banco de dados SQL Server, mas não se preocupe, eu vou te passar um serviço de hospedagem onde tanto o banco de dados SQL server quanto serviço de hospedagem de aplicações asp.net e asp.net core são gratuítos. Basta você cadastrar sua conta criar seu database e executar os scripts que estão no projeto.</p>

### Script I - Criação das tabelas <br/>
https://github.com/carlosrogerioinfo/biosite-api-gateway-sample/blob/main/script-database/script-criacao-tabelas.sql

### Script II - Inclusão de registros nas tabelas <br/>
https://github.com/carlosrogerioinfo/biosite-api-gateway-sample/blob/main/script-database/script-inclusao-dados.sql


## Hospedagem gratuita (Asp.Net Core / SQL Server)

<p>
Hospedagem gratuita para aplicações asp.net e asp.net core e com banco de dados sql server incluídos gratuitamente.
<a href="https://somee.com/" target="_blank">https://somee.com/</a>
</p>

## Links úteis
<a href="https://www.markdownguide.org/basic-syntax/#overview" target="_blank">Sintaxe Básica Markdown</a>

## Contato
E-mail: carlosrogerio.info@gmail.com <br/>
