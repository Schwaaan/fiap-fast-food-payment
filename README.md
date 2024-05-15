
<p align="center">
   <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/939444af-f72e-4d5e-a73c-efdf19e66aef"/>
</p>
<p align="center">
   <img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=RED&style=for-the-badge" #vitrinedev/>
</p>

# Descrição do Projeto
A FourSix Solutions é um conjunto de APIs desenvolvido para resolver os desafios enfrentados pelo Restaurante FourSix FastFood. Com o objetivo de ampliar seu alcance e melhorar o atendimento ao cliente, foi concebida uma solução de autoatendimento, onde os clientes podem fazer seus pedidos por meio de totens. Esses pedidos são então encaminhados automaticamente para o preparo, proporcionando uma gestão eficiente do fluxo de atendimento de ponta a ponta. Além disso, a solução abrange a administração de clientes e pagamentos, garantindo uma experiência completa e integrada desde a solicitação do pedido até sua conclusão.

# Arquitetura do Projeto
<p align="center">
   <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/432f823e-7a3b-47ed-879f-b4507232f235"/>
</p>

# Video de Apresentação do Projeto
[![Apresentacao](https://img.youtube.com/vi/VAvbk4zQk-k/0.jpg)](https://www.youtube.com/watch?v=VAvbk4zQk-k)

## Ferramentas utilizadas
| <a href="https://learn.microsoft.com/pt-br/dotnet/" target="_blank"> <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/2d89d325-9f3d-4920-b496-dfdc9ff5ded7" alt=".netCore" height="50" /></a> | <a href="https://learn.microsoft.com/pt-br/sql/?view=sql-server-ver16" target="_blank"><img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/4585295d-5064-421e-9652-a5dd1f38622b" alt=".netCore"  height="50"/></a> | <a href="https://docs.docker.com/manuals/" target="_blank"> <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/238b190a-67b1-4002-9d1d-23fe34e2bc7f" alt=".netCore" height="50"/></a> | <a href="https://kubernetes.io/pt-br/docs/home/" target="_blank"> <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/30c37852-b6ff-414a-9b59-0b4f5b5d499a" alt=".netCore" height="50"/></a>
| :---: | :---: | :---: | :---:
## Acesso ao projeto

Você pode [acessar o código fonte do projeto](https://github.com/Schwaaan/fiap-fast-food) ou [baixá-lo](https://github.com/Schwaaan/fiap-fast-food/archive/refs/heads/main.zip).

## Abrir e rodar o projeto

Após baixar o projeto
1. Acesse dentro do repositorio o seguinte diretorio
...\four-six-api\kubernetes

2. Abra o terminal e execute o seguinte comando
kubectl apply -f pv-claim.yaml,sqlserver-deployment.yaml,sqlserver-service.yaml

3. Abra o projeto no Visual Studio e execute a Aplicação FourSix.WebApi

## Como subir o Kubernetes

Após baixar o projeto
1. Acesse dentro do repositorio o seguinte diretorio
...\four-six-api\kubernetes

2. Abra o terminal e execute o seguinte comando
kubectl apply -f pv-claim.yaml,sqlserver-deployment.yaml,sqlserver-service.yaml,api-deployment.yaml,api-service.yaml,api-hpa.yaml,metrics.yaml

3. A URL da API é http://localhost:30001/swagger/index.html

## Desenvolvedores

| <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/09d0e2ab-4d4d-4874-af77-404e5cd1cd6c" width=115><br><sub>Diego Franco</sub> |  <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/b1ce0748-d58e-464a-ad44-1a8a6b6f82a6" width=115><br><sub>Jair Schwan</sub> | <img src="https://github.com/Schwaaan/fiap-fast-food/assets/11160318/80c49cda-1d54-4c76-b7d4-020fac25027f" width=115><br><sub>Ivan Gomes</sub> |
| :---: | :---: | :---:
