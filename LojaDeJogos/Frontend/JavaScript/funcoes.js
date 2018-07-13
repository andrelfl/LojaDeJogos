function getCategorias() {
    var url = "/api/Categorias";

    return fetch(url, { headers: { Accept: 'application/json' } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Erro ao obter categorias"));
            }
        });
}

function getJogosCat(id) {
    var url = "/api/Categorias/" + id;
               
    return fetch(url, { headers: { Accept: 'application/json' } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Erro ao obter Jogos"));
            }
        });
}

function getImg(id) {
    return "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/categories/"+ id +"/image";
}

function getJogImg(id) {
    return "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/drivers/" + id + "/image";
}

function getJogDet(id) {
    var url = "/api/jogos/" + id;

    return fetch(url, { headers: { Accept: 'application/json' } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Erro ao obter detalhes"));
            }
        });
}

function getPilDetImg(idPil, idImg) {
    return "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/drivers/" + idPil + "/multimedia/images/" + idImg + "/image";
}