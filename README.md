📌 Sistema de Recarga
🚀 Um sistema para gerenciamento de saldo, transações e recargas, desenvolvido com .NET Core e Entity Framework.

📖 Sobre o Projeto
O Sistema de Recarga é uma API que permite a criação de usuários, gerenciamento de saldo, realização de recargas e débitos, além de registro de transações. Ele pode ser utilizado para diversas aplicações financeiras, como créditos para serviços, pagamentos internos e mais.

⚙️ Funcionalidades
✅ Gerenciamento de Usuários
✅ Saldo e Recarga
✅ Débito e Controle de Gastos
✅ Histórico de Transações
✅ Autenticação e Autorização com JWT
✅ Restrição de Acesso por Permissão (Admin, Usuário)

🛠 Tecnologias Utilizadas
.NET Core 8 - Backend da aplicação
Entity Framework Core - ORM para acesso ao banco de dados
Microsoft SQL Server - Banco de dados relacional
Swagger (Swashbuckle) - Documentação da API
JWT Authentication - Segurança com autenticação baseada em tokens


🔑 Autenticação
O sistema utiliza JWT (JSON Web Token) para autenticação. Para acessar as rotas protegidas, obtenha um token chamando a rota de login:

http
Copiar
Editar
POST /api/Auth/login
Exemplo de corpo da requisição:

json
Copiar
Editar
{
  "email": "admin@exemplo.com",
  "password": "admin123"
}
O token retornado deve ser incluído no header Authorization em todas as requisições protegidas:

makefile
Copiar
Editar
Authorization: Bearer SEU_TOKEN
🔗 Endpoints Principais
🧑 Usuários
POST /api/User/CreateUser - Criar um novo usuário
GET /api/User?id=1 - Buscar um usuário pelo ID
💰 Saldo
GET /api/Balance/usuario/{idUser} - Consultar saldo de um usuário
POST /api/Balance/recarregar - Recarregar saldo
POST /api/Balance/debitar - Debitar do saldo
💳 Transações
GET /api/Transacao/transacoes/usuario/{idUser} - Histórico de transações do usuário
GET /api/Transacao/transacoes - Todas as transações (Somente Admin)
🛡️ Permissões e Roles
O sistema possui controle de acesso por roles:

Admin: Pode visualizar todas as transações e gerenciar usuários.
Usuário: Pode gerenciar seu próprio saldo e visualizar seu histórico.
O controle é feito através do Authorize(Roles = "Admin") em endpoints protegidos.


💡 Desenvolvido por Eldo Marcolino ✨
