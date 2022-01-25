#language: pt-br
Funcionalidade:
Como administrador do sistema de timesheet da empresa XPTO
Eu quero cadastrar, editar, excluir e consultar categorias de atividades
Para que os colaboradores da empresa possam associá-los ao registro de timesheet

#Regras: A categoria deve possuir um código de identificação e uma descrição
Cenário: 0100 - Cadastrar categorias
	Dados as seguintes informações para cadastro de categoria:
		| Id | Titulo  |
		| 1  | teste01 |
		| 2  | teste02 |
		| 3  | teste03 |
		| 4  |         |
	Quando cadastrar a categoria
	Entao devem existir as categorias cadastradas
		| Id | Titulo  |
		| 1  | teste01 |
		| 2  | teste02 |
		| 3  | teste03 |

Cenário: 0101 - Editar categorias
	Dados as seguintes informações para edição por id:
		| Id | Titulo  |
		| 1  | teste01 |
		| 2  | teste02 |
		| 3  | teste03 |
	Quando editar a categoria por id
		| Id | Titulo   |
		| 1  | teste001 |
	Entao devem existir todas as categorias e a editada
		| Id | Titulo   |
		| 1  | teste001 |
		| 2  | teste02  |
		| 3  | teste03  |

Cenário: 0102 - Excluir categorias
	Dados as seguintes informações para exclusao por id:
		| ID | Titulo   |
		| 1  | teste001 |
		| 2  | teste002 |
		| 3  | teste003 |
	Quando excluir a categoria por id
		| ID | Titulo   |
		| 2  | teste002 |
	Entao devem existir apenas os seguintes retornos
		| ID | Titulo   |
		| 1  | teste001 |
		| 3  | teste003 |

Cenário: 0103 - Consultar todas as categorias
	Dados as seguintes informações para a consulta de todas as categorias:
		| Id | Titulo   |
		| 1  | teste001 |
		| 2  | teste002 |
		| 3  | teste003 |
	Quando consultar todas as categorias cadastradas
	Entao devem existir as categorias consultadas
		| Id | Titulo   |
		| 1  | teste001 |
		| 2  | teste002 |
		| 3  | teste003 |

Cenário: 0104 - Consultar categoria por id
	Dados as seguintes informações para a consulta de categoria por id:
		| Id | Titulo   |
		| 1  | teste001 |
		| 2  | teste002 |
		| 3  | teste003 |
	Quando consultar categoria cadastrada por id
		| Id | Titulo   |
		| 3  | teste003 |
	Entao deve existir a categoria consultada por id
		| Id | Titulo   |
		| 3  | teste003 |