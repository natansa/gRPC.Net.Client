# gRPC.Net.Client 🚀

Este repositório contém um cliente **gRPC** desenvolvido em **.NET 9**, que se conecta ao servidor **gRPC.Net.Server** para realizar troca de dados via **Bidirectional Streaming**.

## 📖 Sobre

Este cliente se conecta ao **PersonService**, um serviço gRPC que permite a troca contínua de dados do objeto `Person`, que contém as seguintes propriedades:

- `Name` (string): Nome da pessoa.
- `DateOfBirth` (datetime): Data de nascimento.
- `Age` (int): Idade.
- `Active` (bool): Indica se a pessoa está ativa.

O cliente envia uma lista de pessoas para o servidor e recebe as respostas processadas em tempo real.

---

## 📌 Requisitos

Antes de rodar o cliente, certifique-se de ter:

✅ **.NET 9** instalado  
✅ **gRPC Server rodando na porta 7192**  
✅ **O arquivo `person.proto` corretamente configurado**  

---

## 📥 Instalação

1️⃣ **Clone o repositório**
```sh
git clone https://github.com/seu-usuario/gRPC.Net.Client.git
cd gRPC.Net.Client

---

## 🙋‍♂️ Autor

Desenvolvido por [Natanael Sa Rodrigues](https://github.com/natansa)