# Gerenciamento Biblioteca

Um sistema de gerenciamento de biblioteca simples desenvolvido em C#. Este aplicativo permite que usuários consultem, emprestem e devolvam livros, enquanto administradores podem cadastrar novos títulos e gerenciar o catálogo.

## Funcionalidades

- **Usuário:**
  - Consultar o catálogo de livros.
  - Pegar livros emprestados (até 4 por vez).
  - Devolver livros emprestados.

- **Administrador:**
  - Login com senha.
  - Cadastrar novos livros.
  - Consultar o catálogo de livros.
  ## Uso

Ao iniciar o aplicativo, você verá um menu inicial onde pode escolher entre as opções:

- **Usuário**
- **Administrador**
- **Sair**

### Login do Administrador

O administrador deve inserir a senha (padrão: `12345`) para acessar as funcionalidades administrativas.

### Consulta de Catálogo

Os usuários podem ver todos os livros disponíveis e suas quantidades.

### Empréstimo e Devolução de Livros

- Os usuários podem emprestar livros, reduzindo a quantidade disponível no catálogo.
- Livros emprestados podem ser devolvidos, aumentando novamente a quantidade disponível.


## Tecnologias Utilizadas

- C#
- .NET Console Application

