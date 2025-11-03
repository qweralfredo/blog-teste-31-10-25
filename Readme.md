# 1 - Linha de Raciocinio, Documentação e Instalação

### Por: Alfredo Rosa

TODOS:
    -Criar mairmad funcional
    -Criar TODO dos próximos passos

## Planejamento

### Seguindo a linha de raciocinio de uma vaga para programador sr., será criado um projeto de publicação e gestão de posts e comentários seguindo padrões de desenvolvimento de mercado.


### Camadas
	1-Domain
	2-Infra.Data
	3-Repository
	4-Service
	5-Application
	6-Presentation/API
	7-Tests

### O mesmo poderia ser feito considerando 3 camadas ou multi-projetos (mas simplificaremos como o tempo e problema exigem)



# Implementado o projeto, desde já agradeço a oportunidade.

Considerando as 4 horas, foi implementado o básico para o funcionamento da API (banco de dados em memória)

Foi priorizado o desenvolvimento com o mínimo de componentes de terceiros, só para visar a qualidade do código e uso de padrões essenciais que permitem que o patern prospere à medida do tempo.

Pra facilitar e garantir a reprodução do teste, não incluí nenhum recurso externo de mensageria/banco de dados/cache, etc.


# Quais seriam os próximos passos?

-Implementação da camada de testes (Estou me esforçando para praticar mais TDD, logo, preferi priorizar o código pronto nas 4 horas)

## Validações / Exceptions / Observabilidade

	Criaria a camada de PostValidation e CommentValidation para usar na service
	Criaria um Exceptions Padronizadas para o retorno da Requisição na controller.
	Criaria um Exceptions Padronizadas para o erros internos organizando o tratamento de erro no sistema.
	Instalaria o Opentelemetry para externalizar os logs para outras aplicações e integração com ILogger
	Criação de UnitofWork para garantir ACID em todas as ações de Banco de dados
	
	
## Resiliência
	
	Implementaria Helthcheck para integração com apis resilientes
	Implementaria Retentativa só se houvessem APIs externas

## Contarnização
	
	Criação do Dockerfile e docker-compose-yaml de toda stack
	
## Documentação
	Documentação do fluxo em mairmad
	
# Perdi Tempo com:

	Configuração das entidades do Entity Framework (Havia uns bons anos que não criava na mão, fiz questão de implementar manualmente)
	
	Configuração do Migration (Havia uns bons anos que não criava na mão, fiz questão de implementar manualmente)
	
	Swagger (configurar para a api ir direto para a tela padrão de consulta de api, porém, deixei apenas o json no padrão openai pra ganhar tempo)
