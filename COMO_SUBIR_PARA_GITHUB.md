# 📤 Como Subir o Projeto para o GitHub

O repositório Git local já foi inicializado e o commit inicial foi feito com sucesso! ✅

Agora você precisa criar um repositório no GitHub e conectar com este projeto local.

## 🔗 Passos para Subir para o GitHub

### 1. Criar Repositório no GitHub

1. Acesse: https://github.com
2. Faça login na sua conta
3. Clique no botão **"New"** (ou ícone +) para criar um novo repositório
4. Configure o repositório:
   - **Repository name:** `Atividade-DSI-Biblioteca` (ou o nome que preferir)
   - **Description:** "Sistema de Biblioteca - Clean Architecture e DDD"
   - **Visibility:** ✅ **PUBLIC** (obrigatório para o professor acessar)
   - ❌ NÃO marque "Add a README file" (já temos um)
   - ❌ NÃO adicione .gitignore (já temos um)
5. Clique em **"Create repository"**

### 2. Conectar o Repositório Local ao GitHub

Após criar o repositório, o GitHub vai mostrar os comandos. Copie a URL do repositório (algo como: `https://github.com/SEU_USUARIO/Atividade-DSI-Biblioteca.git`)

Abra o terminal/PowerShell na pasta do projeto (`D:\Atividade_DSI`) e execute:

```bash
# Adicionar o remote (substitua YOUR_USERNAME e YOUR_REPO pelo seu)
git remote add origin https://github.com/YOUR_USERNAME/YOUR_REPO.git

# Renomear a branch para main (se necessário)
git branch -M main

# Fazer push
git push -u origin main
```

### 3. Exemplo Completo

Substitua `SEU_USUARIO` e `Atividade-DSI-Biblioteca` pelos valores corretos:

```bash
cd D:\Atividade_DSI
git remote add origin https://github.com/SEU_USUARIO/Atividade-DSI-Biblioteca.git
git branch -M main
git push -u origin main
```

Se pedir credenciais, você pode usar um **Personal Access Token**:
1. GitHub → Settings → Developer Settings → Personal Access Tokens → Generate new token
2. Marque a opção `repo`
3. Use o token como senha

### 4. Verificar se Subiu Corretamente

1. Acesse o repositório no GitHub: `https://github.com/SEU_USUARIO/SEU_REPOSITORIO`
2. Verifique se todos os arquivos estão lá
3. Confira se o README.md está sendo exibido
4. ✅ O repositório deve estar **PUBLIC**

### 5. Copiar o Link do Repositório

Após subir, copie o link completo do repositório:
- Exemplo: `https://github.com/SEU_USUARIO/Atividade-DSI-Biblioteca`

Este é o link que você deve colocar na entrega da APS! 📝

## 🚨 Importante para a Entrega

- ✅ O repositório DEVE estar **PÚBLICO**
- ✅ Certifique-se que todos os arquivos foram enviados
- ✅ Verifique se o README.md está visível
- ✅ Cole o link completo do repositório no campo de resposta da APS

## 🔄 Comandos Úteis

### Ver status do repositório
```bash
git status
```

### Ver o remote configurado
```bash
git remote -v
```

### Fazer novos commits (se fizer alterações)
```bash
git add .
git commit -m "Descrição das alterações"
git push
```

### Ver o histórico de commits
```bash
git log --oneline
```

## 💡 Dica

Se você usar **GitHub Desktop** (interface gráfica), o processo fica mais fácil:
1. Baixe: https://desktop.github.com/
2. Abra o GitHub Desktop
3. File → Add Local Repository
4. Selecione a pasta `D:\Atividade_DSI`
5. Clique em "Publish repository"
6. Marque como Public
7. Pronto!

## ✅ Checklist Final

- [ ] Repositório criado no GitHub
- [ ] Repositório configurado como PUBLIC
- [ ] Código foi enviado com `git push`
- [ ] README.md está visível no repositório
- [ ] Link do repositório copiado
- [ ] Link colado no campo de entrega da APS

---

**Qualquer dúvida, consulte a documentação oficial do Git/GitHub:**
- Git: https://git-scm.com/docs
- GitHub: https://docs.github.com

