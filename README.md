# Boas vindas ao Teste-Accenture!

# O que é o Teste-Accenture?

É uma aplicação FullStack dockerizada que consiste em uma API Restful, com um simples CRUD de Empresas e Fornecedores no Backend, consumindo um Banco de Dados SQLServer e um Frontend desenvolvido em Vue js que apresenta a lista completa das Empresas e Fornecedores, a partir do consumo da API.

## Técnologias usadas

Back-end:
> Desenvolvido usando: C#, API Restful, DotNet, .NET Framework, Entity Framework, SQLServer.

Front-end:
> Desenvolvido usando: Vue.js, HTML, CSS e Javascript.

<details>
<summary><strong> Estrutura do projeto</strong></summary><br />
  
 O projeto é composto de 4 entidades importantes para sua estrutura:
  
  1️⃣ **Banco de dados:**
  - Contém um container docker SQLServer já configurado no docker-compose através de um serviço definido como `db`.
  - Tem o papel de fornecer dados para o serviço de _backend_.
  
  2️⃣ **Back-end:**
 - Deve rodar na porta `7189`, pois o front-end faz requisições para ele nessa porta por padrão;
 - A aplicação é inicializada a partir do arquivo `app/backend/Program.cs`;
 - Para iniciar o Back-end veja os comandos do docker abaixo antes de usar os comando a seguir;
 - Com o DotNet configurado na sua maquina rode primeiramente o comando `dotnet ef databaseupdate` na pasta back-end;
 - Com isso o banco de dados vai ser preenchido e adicionado as seeds para visualização;
 - para subir o back-end use o comando `dotnet run watch`;
  
  3️⃣ **Front-end:**
  - Deve rodar na porta `8080`;
  - O front se comunica com serviço de back-end pela url `http://localhost:7189` através dos endpoints contruídos.
  
  4️⃣ **Docker:**
  - O `docker-compose` tem a responsabilidade de unir os serviços frontend e db e subir parte do projeto com o comando `docker-compose up --build`;
  - O serviço Front-end tem sua `Dockerfile` corretamente configurada em sua raíze, tornando possível a inicialização da aplicação;
  
</details>
  
  ## Para executar o projeto corretamente, atente-se a cada passo descrito a seguir
<details>
<summary><strong> ⚠️ Configurações mínimas para execução do projeto</strong></summary><br />

Na sua máquina você deve ter:

 - Sistema Operacional Distribuição Unix
 - Node versão 16
 - DotNet
 - SQLServer
 - Docker (**opcional, mas recomendado**)
 - Docker-compose versão >=1.29.2 (**opcional, mas recomendado**)

➡️ O `node` deve ter versão igual ou superior à `16.15.0 LTS`:
  - Para instalar o nvm, [acesse esse link](https://github.com/nvm-sh/nvm#installing-and-updating);
  - Rode os comandos abaixo para instalar a versão correta de `node` e usá-la:
    - `nvm install 16 --lts`
    - `nvm use 16`
    - `nvm alias default 16`

➡️ O `docker-compose` deve ter versão igual ou superior à`ˆ1.29.2`:
  * Use esse [link de referência para realizar a instalação corretamente no ubuntu](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-compose-on-ubuntu-20-04-pt) ou a [documentação oficial](https://docs.docker.com/compose/install/);
  * Acesse o [link da documentação oficial com passos para desinstalar](https://docs.docker.com/compose/install/uninstall/) caso necessário.

</details>

<details>
<summary><strong> 👨‍💻 Informações Importantes </strong></summary><br />

  1. Clone o repositório
- Utilize o comando: `git clone git@github.com:heliorr/Desafio-Accenture.git`<br />
2. Acesse a pasta do projeto
- Acesse a pasta Desafio-Accenture com `cd Desafio-Accenture`;<br />
3. Suba a aplicação 
 <summary><strong> 🐳 Com Container Docker-Compose </strong></summary><br />

    - Execute o comando `docker-compose up --build` na pasta raíz do projeto;
    - Aguarde que todos os containers estejam saudáveis;
    - Entre na pasta Back-end e execute os ccomandos `dotnet ef databaseupdate` e `dotnet run watch`;
    - Acesse em seu browser o endereço: `http://localhost:8080`;

  </details>
  
  Projeto Desenvolvido por [Hélio Souza](https://github.com/heliorr)
