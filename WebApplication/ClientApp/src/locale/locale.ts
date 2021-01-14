const messages = {

    api: {
        error: {
            title: 'Erro de comunicação com o servidor',
            message: 'Houve algum problema de comunicação com o servidor. Tente novamente mais tarde ou dentro de alguns instantes.'
        }
    },
    header: {
        title: "CAMPEONATO DE FILMES"
    },
    championship: {
        loading: "Verificando resultados..",
        newRound: "CRIAR NOVO CAMPEONATO",
        title: "Resultado Final",
        message: "Veja o resultado final do Campeonato de filmes de forma simples e rápida"
    },
    home: {
        header: {
            title: 'Fase de Seleção',
            message: 'Selecione {0} filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir.'
        },
        buttons: {
            classify: 'GERAR MEU CAMPEONATO ({0})'
        },
        loading: {
            movies: 'Carregandos filmes...'
        },
        selected: 'Selecionado {0} de {1} filmes',
        errors: {
            title: 'Erro',
            maxSizeReached: 'O limite máximo de {0} filmes já foi atingido. Pressione o botão Gerar Meu Campeonato para prosseguir.'
        }
    },
    format: (str: string, ...val: any[]) => {
        for (let index = 0; index < val.length; index++) {
            str = str.replace(`{${index}}`, String(val[index]));
        }
        return str;
    }
}

export default messages;