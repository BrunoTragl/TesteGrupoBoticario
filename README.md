Backend Test
======

Esta é uma avaliação básica de código.

O objetivo é conhecer um pouco do seu conhecimento/prática de RESTful, C#.

Recomendamos que você não gaste mais do que 4 - 6 horas.

Faça um fork deste repositório.

Ao finalizar o teste, submeta um pull request para o repositório que nosso time será notificado.

Tarefas
======

Com a seguinte representação de produto:

{
    "sku": 43264,
    "name": "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
    "inventory": {
        "quantity": 15,
        "warehouses": [
            {
                "locality": "SP",
                "quantity": 12,
                "type": "ECOMMERCE"
            },
            {
                "locality": "MOEMA",
                "quantity": 3,
                "type": "PHYSICAL_STORE"
            }
        ]
    },
    "isMarketable": true
}

#### H4 Crie endpoints para as seguintes ações:

> Criação de produto onde o payload será o json informado acima (exceto as propriedades isMarketable e inventory.quantity)

> Edição de produto por sku

> Recuperação de produto por sku

> Deleção de produto por sku

#### H4 Requisitos

> Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: inventory.quantity

> A propriedade inventory.quantity é a soma da quantity dos warehouses

> Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: isMarketable

> Um produto é marketable sempre que seu inventory.quantity for maior que 0

> Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada

> Dois produtos são considerados iguais se os seus skus forem iguais
 
> Ao atualizar um produto, o antigo deve ser sobrescrito com o que esta sendo enviado na requisição

> A requisição deve receber o sku e atualizar com o produto que tbm esta vindo na requisição

Dicas
======

> Os produtos podem ficar em memória, não é necessário persistir os dados

> Testes são sempre bem-vindos 😃
