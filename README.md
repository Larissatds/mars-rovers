# Mars Rovers - Desafio Explorando Marte

Este projeto é uma solução para o desafio técnico de movimentação de sondas da NASA no planalto de Marte, implementado em **C# com .NET 6.0** e arquitetura orientada a objetos.

---

## Sobre o Problema

- As posições no planalto são representadas por coordenadas x-y.
- A direção da sonda é indicada por uma letra que representa um ponto cardeal (N, S, E, W).
- O planalto é definido pelas coordenadas do canto inferior esquerdo (0,0) e do canto superior direito (coordenadas máximas dadas na entrada).
- Sondas (rovers) podem se mover com comandos:
  - `L`: girar 90 graus à esquerda.
  - `R`: girar 90 graus à direita.
  - `M`:  mover um ponto à frente na direção atual.
- Uma sonda deve executar todas as suas instruções antes que a próxima sonda seja processada.

---

## Como Executar

1. Clone o repositório:

  ```bash
  git clone https://github.com/Larissatds/mars-rovers.git
  cd mars-rovers
  ```

2. Compile e rode a aplicação:

  ```bash
  dotnet build
  dotnet run --project MarsRovers.ConsoleApp
  ```

3. Rode os testes:

  ```bash
  dotnet test
  ```

## Design e Arquitetura
### Orientação a Objetos
O projeto é dividido nas seguintes classes principais:
- `Rover`
- `Plateau`
- `Position`
- `Direction`

### Princípios SOLID

- SRP: cada classe tem uma única responsabilidade.

- OCP: comandos podem ser estendidos (Command Pattern).

- ISP/DIP aplicados em interfaces como `ICommand`.

## Design Patterns Utilizados
- Command Pattern: encapsula `M`, `L`, `R` em classes separadas (`MoveCommand`, `TurnLeftCommand` e `TurnRightCommand`).
Vantagem: fácil extensão e separação da lógica de comandos.
- Factory-like Approach: a criação de rovers e comandos está encapsulada no RoverService.

## Debugging no Visual Studio
Para depurar o projeto, utilizei o Visual Studio com os seguintes recursos:
- Adição de breakpoints nos métodos principais (MoveForward, ExecuteCommands, etc.).
- Utilização da janela Autos e Locals para inspecionar variáveis em tempo real.
- Avanço passo a passo com as teclas F10 (Step Over) e F11 (Step Into).
- Verificação de condições específicas com Watch e Conditional Breakpoints.
- Isso permitiu identificar facilmente cenários de falha como tentativas de movimentação fora do planalto ou colisões.

## Testes Automatizados
Testes com xUnit em `MarsRovers.Tests`.
Cobertura de testes:
- Direções e rotação
- Movimento básico
- Limite do planalto
- Tentativa de colisão entre sondas

## CI - Continuous Integration
Configurado com GitHub Actions em `.github/workflows/ci.yml`
- Executa build e testes em cada push ou pull request para main
- Logs disponíveis na aba Actions do repositório GitHub

## Exemplo de Entrada/Saída
### Entrada:
```bash
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```

### Saída Esperada:
```bash
1 3 N
5 1 E
```

## Tecnologias Utilizadas
- .NET 6.0
- C#
- xUnit
- GitHub Actions
