
<h1>Cenários</h1>

Os cenários desenvolvidos visam automatizar os seguintes requisitos:
*	Entrar no site dos correios;
*	Procurar pelo CEP 80700000;
*	Confirmar que o CEP não existe;
*	Voltar a tela inicial;
*	Procurar pelo CEP 01013-001
*	Confirmar que o resultado seja em “Rua Quinze de Novembro, São Paulo/SP”
*	Voltar a tela inicial;
*	Procurar no rastreamento de código o número “SS987654321BR”
*	Confirmar que o código não está correto;
*	Fechar o browser;

## Observações

Devido a uma validação de segurança do tipo captcha no site dos correios,
o teste que faz a validação do código de rastreamento teve que ser apenas parcialmente automatizado.
Antes do teste realizar a consulta uma etapa pausa a automação por 15s para que seja digitado o captcha.
Os testes que envolvem pesquisa de CEP válido e inválido foram totalmente automatizados.

