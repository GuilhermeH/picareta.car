# picareta.car
Context Operacao

 - o vendedor pode cadastrar um carro para venda, este carro obrigatoriamente deve pertencer a um modelo que será
 escolhido em uma lista disponibilizada pelo administrador do portal, o vendedor informará nome e valor do carro

 - após cadastro esse carro fica pendente de avaliação do administrador do sistema que poderá aprovar ou reprovar 
o carro, caso Aprovado, o mesmo será disponibilizado no portal de vendas.

 - o vendedor poderá atualizar o valor do carro, cada vez que o valor do carro for alterado será salvo um histórico 
com data, novo valor e valor antigo


Context Vendas

 - no portal de vendas será disponibilizado a lista de modelos disponíveis, quando o usuário interessado escolher qual 
modelo ele prefere, o sistema deverá listar os carros disponíveis para aquele modelo

Context Admin

 - sistema receberá uma intenção de venda, o valor do carro deve estar entre o valor minimo e o máximo do modelo para ser aprovado automaticamente, 
caso não esteja será enviado para analise do adminstrador
 - o sistema deverá disponibilizar uma lista de carros pendentes de aprovação
 - o administrador pode aprovar ou reprovar a intencao de venda
 - após aprovação o carro deverá ficar disponpivel no contexto de vendas 
 - em caso de reprovação, o administrador insere um motivo e o vendedor deverá ser notificado 
 - poderá cadastrar modelos de carros, nesse cadastro deverá ser informado valor minimo e máximo permitido para o modelo.