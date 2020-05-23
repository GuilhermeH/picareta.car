# picareta.car
Context Operacao

 
 - o vendedor vai inserir uma intenção de venda, vai escolher o modelo do carro em uma lista predefinida, e informar o valor, caso o valor esteja
 dentro da regra permitida será aprovado automaticamente e enviado para venda, caso não será enviado para analise manual do
 administrador.

 - o vendedor poderá atualizar o valor do carro, cada vez que o valor do carro for alterado será salvo um histórico 
com data, novo valor e valor antigo


Context Vendas

 - no portal de vendas será disponibilizado a lista de carros disponíveis para venda, quando o usuário interessado escolher qual 
modelo ele prefere, o sistema deverá listar os carros disponíveis para aquele modelo

Context Admin
 - o sistema fornecera uma lista das intenções de venda que necessitam aprovação, 
 - o sistema deverá disponibilizar uma lista de carros pendentes de aprovação
 - o administrador pode aprovar ou reprovar a intencao de venda
 - após aprovação o carro deverá ficar disponpivel no contexto de vendas 
 - em caso de reprovação, o administrador insere um motivo e o vendedor deverá ser notificado 
 - poderá cadastrar modelos de carros, nesse cadastro deverá ser informado valor minimo e máximo permitido para o modelo.
 - podera cadastrar vendedor