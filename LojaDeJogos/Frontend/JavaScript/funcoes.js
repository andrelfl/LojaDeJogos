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

function getJogos(id) {
    var url = "/api/jogos?id="+id;
               
    return fetch(url, { headers: { Accept: 'application/json' } })
        .then(function (resposta) {
            if (resposta.status === 200) {
                return resposta.json();
            } else {
                return Promise.reject(new Error("Erro ao obter pilotos"));
            }
        });
}

function getImg(id) {
    return "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/categories/"+ id +"/image";
}

function getPilImg(id) {
    return "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/drivers/" + id + "/image";
}

function getPilDet(id) {
    var url = "http://ipt-ti2-racinglegends-api.eu-gb.mybluemix.net/api/v1/drivers/" + id;

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